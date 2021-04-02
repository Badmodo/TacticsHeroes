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

        if (!turn)
        {
            return;
        }

        if (!moving)
        {
            FindNearestTarget();
            CalculatePath();
            FindSelectableTiles();
            actualTargetTile.target = true;
            //possibly add in combat here, choose random moves of the 2

            //if(enemy in range random attack)
            //TurnManager.EndTurn();
        }
        else
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
}
