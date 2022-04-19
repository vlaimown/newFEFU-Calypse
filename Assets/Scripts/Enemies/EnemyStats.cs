using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : CharacterStats
{
    public override void Die()
    {
        base.Die();

        player.GetComponent<SpriteRenderer>().color = Color.white;
        Destroy(gameObject);
        healthBar.fillAmount = 1f;
    }
}
