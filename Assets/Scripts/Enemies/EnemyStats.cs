using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : CharacterStats
{
    int rnd_sheet = 0;
    [SerializeField] GameObject sheet;
    [SerializeField] SpawnEnemy spawnEnemy;

    [SerializeField] Skill skill;
    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
        player.GetComponent<SpriteRenderer>().color = Color.white;
        healthBar.fillAmount = 1f;

        //if ()
        //{
        spawnEnemy = FindObjectOfType<SpawnEnemy>();
        spawnEnemy.count = spawnEnemy.count - 1;
        //}

        skill = FindObjectOfType<Skill>();

        //if (skill.waterTargets.Count > 1)
        //{
            //skill.waterTargets.Remove(gameObject.GetComponent<Collider2D>());
        //}
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
