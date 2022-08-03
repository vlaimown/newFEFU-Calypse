using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    //public float attackSpeed = 1f;
    //public float maxAttackCooldown = 1f;
    //public float attackCooldown = 0f;
    //public float attackDelay;

    //[SerializeField] Zombie zombie;

    //public CharacterStats myStats;

    //private void Start()
    //{
    //    myStats = GetComponent<CharacterStats>();
    //}

    //public void Attack (CharacterStats targetStats)
    //{
    //    StartCoroutine(DoDamage(targetStats, attackDelay));
    //    targetStats.TakeDamage(myStats.damage.GetValue());
    //}

    //IEnumerator DoDamage (CharacterStats stats, float delay)
    //{
    //    yield return new WaitForSeconds (delay);

    //    stats.TakeDamage(myStats.damage.GetValue());
    //}
}
