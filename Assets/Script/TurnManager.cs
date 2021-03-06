using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnManager : MonoBehaviour 
{
    //all the units in the game, string will be the tags and this will be player and Npc
    static Dictionary<string, List<TacticsMove>> units = new Dictionary<string, List<TacticsMove>>();
    //this is setting whos turn is active. Key is whos turn it is
    static Queue<string> turnKey = new Queue<string>();
    //queue for the team whos turn it is, so one team goes at a time
    static Queue<TacticsMove> turnTeam = new Queue<TacticsMove>();

    public Animator animator;

    public TurnManager instance { get; private set; }

    //this turn manager is designed to be team based, one at a time

    void Update () 
	{
        //for the first turn
        if (turnTeam.Count == 0)
        {
            InitTeamTurnQueue();
        }
	}

    private void OnGUI()
    {
        for (int t = 0; t < units.Count; t++) //For each team
        {
            float x = 20 + 400 * t;
            string k = units.ElementAt(t).Key;
            GUI.Label(new Rect(x, 20, 400, 20), "===" + k);
            for (int u = 0; u < units[k].Count; u++) //For each unit in team
            {
                TacticsMove unit = units[k][u];
                float y = 40 + 20 * u;
                GUI.Label(new Rect(x, y, 200, 20), unit.ToString());
                GUI.Label(new Rect(x  + 200f, y, 200, 20), unit.state.ToString());
            }
        }
    }

    static void InitTeamTurnQueue()
    {
        //picking player or NPCs turn
        List<TacticsMove> teamList = units[turnKey.Peek()];

        foreach (TacticsMove unit in teamList)
        {
            //add them to the queue
            turnTeam.Enqueue(unit);
        }

        //initilises the next team
        StartTurn();
    }

    public static void StartTurn()
    {
        if (turnTeam.Count > 0)
        {
            turnTeam.Peek().BeginTurn();
        }
    }

    public static void EndTurn()
    {
        //each unit takes itself out of the queue
        TacticsMove unit = turnTeam.Dequeue();

        //check if anyother team members have yet to play
        if (turnTeam.Count > 0)
        {
            StartTurn();
        }
        else
        {
            //each team is added to the queue in an everlasting queue
            string team = turnKey.Dequeue();
            turnKey.Enqueue(team);
            InitTeamTurnQueue();
        }
    }

    //this makes the unit adds itself to that teams list in the dictionary
    public static void AddUnit(TacticsMove unit)
    {
        List<TacticsMove> list;

        //check the tag is not already in the dictionary
        if (!units.ContainsKey(unit.tag))
        {
            list = new List<TacticsMove>();
            units[unit.tag] = list;

            if (!turnKey.Contains(unit.tag))
            {
                turnKey.Enqueue(unit.tag);
            }
        }
        else
        {
            //find tag and assign it
            list = units[unit.tag];
        }

        //add to the list discionary
        list.Add(unit);
    }

    //add remove from queue 
    //public static void RemoveUnit(TacticsMove unit)
    //{
        
    //}
    //add remove turn key(team) once all memebers have been removed
}
