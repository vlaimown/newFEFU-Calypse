using UnityEngine.UI;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public Image healthBar;
    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public Stat damage;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage (int damage)
    {
        currentHealth -= damage;
        //healthBar.fillAmount -= (maxHealth - currentHealth) / maxHealth;
        //healthBar.fillAmount -= /*currentHealth / maxHealth;*/ 0.1f;
        //Debug.Log(transform.name + " take " + damage + " damage.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log(transform.name + " died");
    }
}
