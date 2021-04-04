using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : TacticsMove 
{
    //find nearest player tag unit
    GameObject target;

	void Start () 
	{
        //computes tiles and whatnot to turnmanager
        Init();
	}
	
   

	void Update () 
	{
        Debug.DrawRay(transform.position, transform.forward);

        if (state == States.Standby)
        {
            return;
        }

        if (state == States.MoveCalculation)
        {
            FindNearestTarget();
            CalculatePath();
            FindSelectableTiles();
            actualTargetTile.target = true;
            GoToState(States.Move);
        }
        else if (state == States.Move)
        {
            Move();
        }
    }

    void CalculatePath()
    {
        //could add a ninja move to the NPC cant see your ninja
        Tile targetTile = GetTargetTile(target);
        //ASTAR
        FindPath(targetTile);
    }

    void FindNearestTarget()
    {
        //so ninja skill will remove player tag for a turn
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");

        GameObject nearest = null;
        float distance = Mathf.Infinity;

        //targets is our array
        foreach (GameObject obj in targets)
        {
            float d = Vector3.Distance(transform.position, obj.transform.position);

            //the nearest from the infinity check
            if (d < distance)
            {
                distance = d;
                nearest = obj;
            }
        }

        target = nearest;
    }

    protected override void Attacks()
    {
        StartCoroutine(NPCAttack());
    }

    IEnumerator NPCAttack ()
    {
        GoToState(States.Combat);
        yield return new WaitForSeconds(0.5f);
        GoToState(States.Standby);
        TurnManager.EndTurn();
    }
}
