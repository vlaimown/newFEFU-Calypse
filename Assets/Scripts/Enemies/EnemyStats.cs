using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : CharacterStats
{
    int rnd_sheet = 0;
    [SerializeField] GameObject sheet;
    public override void Die()
    {
        base.Die();

        player.GetComponent<SpriteRenderer>().color = Color.white;
        Destroy(gameObject);
        healthBar.fillAmount = 1f;
        //SpawnSheet();
    }

    public void SpawnSheet()
    {
        rnd_sheet = Random.Range(1, 2);
        if (rnd_sheet == 1)
        {
            Instantiate(sheet, new Vector2(transform.position.x - 1, transform.position.y), Quaternion.identity);
        }
    }
}
