using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public PlayerController player;
    public Image healthBar;
    public float maxHealth = 100;
    public float currentHealth { get; private set; }

    public Stat damage;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        currentHealth = maxHealth;
    }

    public void TakeDamage (float damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount -= damage / maxHealth;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth - (currentHealth - maxHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //Debug.Log(transform.name + " died");
    }
}
