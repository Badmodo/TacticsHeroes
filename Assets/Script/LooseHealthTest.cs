using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseHealthTest : HealthBar
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(1);
        }
    }
}
