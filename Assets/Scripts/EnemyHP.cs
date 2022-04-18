using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    private  float health = 1f;
    private float damage = 0.25f;

    public  void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag( "Player"))
        {
            other.GetComponent<HealthBar>().TakeDamage(damage);
            Debug.Log("damage");
       }
    }

       public  void DamageEnemy(float amount)
        {
            health -= amount;
             if (health  <= 0f )
            {
                Die();
            }
        }


        void Die()
        {
            Destroy(gameObject);
        }
    
}
