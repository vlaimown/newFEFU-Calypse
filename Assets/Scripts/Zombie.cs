using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemies
{
   // [SerializeField] AudioSource classicZombie;

   // public PlayerController playerController;

   // public bool zombieAttackFlag;

   // CharacterCombat combat;
   // [SerializeField] Transform target;

   //// public Transform zombiePosition;

   // [SerializeField] CharacterStats myStats;
   // [SerializeField] EnemyStats enemyStats;

    private void Start()
    {
        //zombieAttackFlag = false;

        //target = PlayerManager.instance.player.transform;

        //playerController = FindObjectOfType<PlayerController>();
        ////zombiePosition = GetComponent<Transform>();
        //combat = GetComponent<CharacterCombat>();

        //myStats = GetComponent<CharacterStats>();
        //enemyStats = GetComponent<EnemyStats>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    protected override void Die()
    {
        base.Die();
        //SpawnSheet();
    }

    //public void SpawnSheet()
    //{
    //    rnd_sheet = Random.Range(1, 2);
    //    if (rnd_sheet == 1)
    //    {
    //        Instantiate(sheet, new Vector2(transform.position.x - 1, transform.position.y), Quaternion.identity);
    //    }
    //}
}