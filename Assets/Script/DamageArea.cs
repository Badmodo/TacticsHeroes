using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TacticsMove tactics = other.gameObject.GetComponent<TacticsMove>();
            tactics.healthBar.health -= 1f;            
        }
    }
}
