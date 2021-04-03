using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour 
{
    //if you want to block a tile use this
    public bool walkable = true;
    public bool current = false;
    public bool target = false;
    public bool selectable = false;

    //this is the list of the neighbouring tiles
    public List<Tile> adjacencyList = new List<Tile>();

    //needed for breadth first search
    public bool visited = false;
    //used to calculate and find the path using parent
    public Tile parent = null;
    public int distance = 0;

    //for ASTAR 
    public float f = 0; //G + H
    public float g = 0; //parent to current tile
    public float h = 0; //processed tile to desination

    public Color currentTile;
    public Color targetTile;
    public Color selectableTile;
    public Color nonSelectableTile;

    Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update () 
	{
        //where the character currently resides
        if (current)
        {
            renderer.material.color = currentTile;
        }
        //where you want to go
        else if (target)
        {
            renderer.material.color = targetTile;
        }
        //range to where you can move
        else if (selectable)
        {
            renderer.material.color = selectableTile;
        }
        //non selectable
        else
        {
            renderer.material.color = nonSelectableTile;
        }
	}

    //every turn we need to check for all variables
    public void Reset()
    {
        adjacencyList.Clear();

        current = false;
        target = false;
        selectable = false;

        visited = false;
        parent = null;
        distance = 0;

        //for astar
        f = g = h = 0;
    }

    //cleares the tiles of colours and checks distance taking into account the jump height
    public void FindNeighbors(float jumpHeight, Tile target)
    {
        Reset();

        CheckTile(Vector3.forward, jumpHeight, target);
        CheckTile(-Vector3.forward, jumpHeight, target);
        CheckTile(Vector3.right, jumpHeight, target);
        CheckTile(-Vector3.right, jumpHeight, target);
    }

    //half extence is the center of the tile
    public void CheckTile(Vector3 direction, float jumpHeight, Tile target)
    {
        //check to see if the tile is there, taking into account the height of the jump ability
        Vector3 halfExtents = new Vector3(0.25f, (1 + jumpHeight) / 2.0f, 0.25f);
        Collider[] colliders = Physics.OverlapBox(transform.position + direction, halfExtents);

        foreach (Collider item in colliders)
        {
            //check if this is a tile, null if character or no tile there
            Tile tile = item.GetComponent<Tile>();
            if (tile != null && tile.walkable)
            {
                //raycast to confirm if something is in the way
                RaycastHit hit;

                if (!Physics.Raycast(tile.transform.position, Vector3.up, out hit, 1) || (tile == target))
                {
                    //as long as it dosnt hit anything add to adjency list
                    adjacencyList.Add(tile);
                }
            }
        }
    }
}
