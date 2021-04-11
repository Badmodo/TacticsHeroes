using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Image healthBar;
    public static float health;
    private float MaxHealth;

    private void Start()
    {
        healthBar = GetComponent<Image>();
        health = MaxHealth;
    }

    private void Update()
    {
        healthBar.fillAmount = health / MaxHealth;
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
