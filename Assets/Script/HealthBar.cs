using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Image healthBar;
    public float maxHealth;
    public static float health;

    private void Start()
    {
        healthBar = GetComponent<Image>();
        health = maxHealth;
    }

    private void Update()
    {
        healthBar.fillAmount = health / maxHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
