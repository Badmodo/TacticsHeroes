using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseHealthTest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("-Health");
            HealthBar.health -= 1f;
        }
    }
}
