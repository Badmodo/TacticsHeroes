using System.Collections;
using UnityEngine;

[DefaultExecutionOrder(-10000)]
public class TileManager : MonoBehaviour
{
    public static TileManager Instance { get; private set; }
    public GameObject[] Tiles { get; private set; }

    void Awake()
    {
        Instance = this;
        Tiles = GameObject.FindGameObjectsWithTag("Tile");
    }
}