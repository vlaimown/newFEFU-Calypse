using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    GameObject currentTarget;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask enemyLayers;

    int damage;
    public void playerAttack()
    {
        // if (bottle_attack == true)
        //{
        damage = 20;  // урон от выбранного оружия
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemies>().TakeDamage(damage);
            
            //if (enemy.tag == "Enemy")
            //{
            //    stanEnemyByAttack.stager_enemy.Add(enemy.GetComponent<EnemyStats>());
            //}

            //stanEnemyByAttack.StaggerEnemies();

            //float dist = Mathf.Infinity;
            //var cols = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRange, enemyLayers);
            //Collider2D currentCollider = cols[0];
            //foreach (Collider2D col in cols)
            //{
            //    float currentDist = Vector2.Distance(attackPoint.transform.position, col.transform.position);
            //    if (currentDist < dist)
            //    {
            //        currentCollider = col;
            //        dist = currentDist;
            //    }
            //}
            currentTarget = enemy.gameObject;

            StartCoroutine(RedVersionOfSprite());

            //}
            // bottle_attack = false;
            //}

            //if (bjd_attack == true)
            //{
            //    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackBJD_point.position, attackRange, enemyLayers);
            //    foreach (Collider2D enemy in hitEnemies)
            //    {
            //        enemy.GetComponent<CharacterStats>().TakeDamage(myStats.damage.GetValue());

            //        if (enemy.tag == "Enemy")
            //        {
            //            stanEnemyByAttack.stager_enemy.Add(enemy.GetComponent<EnemyStats>());
            //        }

            //        stanEnemyByAttack.StaggerEnemies();

            //        float dist = Mathf.Infinity;
            //        var cols = Physics2D.OverlapCircleAll(attackBJD_point.position, attackRange, enemyLayers);
            //        Collider2D currentCollider = cols[0];
            //        foreach (Collider2D col in cols)
            //        {
            //            float currentDist = Vector2.Distance(attackBJD_point.position, col.transform.position);
            //            if (currentDist < dist)
            //            {
            //                currentCollider = col;
            //                dist = currentDist;
            //            }
            //        }
            //        currentTarget = currentCollider.gameObject;

            //        StartCoroutine(RedVersionOfSprite());
            //    }
            //    bjd_attack = false;
            //}
        }
    }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
            //Gizmos.DrawWireSphere(attackBJD_point.position, attackRange);
        }

        IEnumerator RedVersionOfSprite()
        {
            currentTarget.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.4f);
            currentTarget.gameObject.GetComponent<SpriteRenderer>().color = Color.white;

            currentTarget = null;
        }
    }
