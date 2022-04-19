using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    public float maxAttackCooldown = 1f;
    public float attackCooldown = 0f;
    public float attackDelay;

    [SerializeField] Zombie zombie;

    public CharacterStats myStats;

    private void Start()
    {
        attackCooldown = maxAttackCooldown;
        myStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        if (attackCooldown > 0 && zombie.zombieAttackFlag == true){
            attackCooldown -= Time.deltaTime;
        }
    }

    public void Attack (CharacterStats targetStats)
    {
        if (attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));
            targetStats.TakeDamage(myStats.damage.GetValue());
            attackCooldown = maxAttackCooldown;
        }
    }

    IEnumerator DoDamage (CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds (delay);

        stats.TakeDamage(myStats.damage.GetValue());
    }
}
