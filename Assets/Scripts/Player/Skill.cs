using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skill : MonoBehaviour
{
    [SerializeField] GameObject water;
    [SerializeField] float waterRange;
    [SerializeField] PlayerController playerController;

    [SerializeField] bool damageFlag;
    [SerializeField] bool healFlag;

    [SerializeField] GameObject hero;
    [SerializeField] PlayerStat playerStat;

    public List<Collider2D> waterTargets;
    [SerializeField] int enemy_counter;

    [SerializeField] float currentSkillTime;
    [SerializeField] float maxSkillTime;


    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        playerStat = FindObjectOfType<PlayerStat>();
        currentSkillTime = maxSkillTime;
    }

    private void FixedUpdate()
    {
        if (water.gameObject != null)
        {
            currentSkillTime -= Time.deltaTime;
        }
        if (currentSkillTime < 0)
        {
            Destroy(water.gameObject);
            currentSkillTime = maxSkillTime;
            playerController.water_count = 0;

            playerController.skillCoolDownTime = playerController.maxSkillCoolDownTime;
        }

        if (healFlag == true && (playerStat.currentHealth < playerStat.maxHealth))
        {
            playerController.hero.GetComponent<PlayerStat>().TakeDamage(-0.15f);
        }

        foreach (Collider2D enemy in waterTargets)
        {
             enemy.GetComponent<EnemyStats>().TakeDamage(0.2f);
        }
    }

    /*IEnumerator RedVersionOfSprite()
    {
        for (int i = 0; i < 10; i++)
        {
            currentTarget[i].gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        yield return new WaitForSeconds(0.35f);
        for (int i = 0; i < 10; i++)
        {
            currentTarget[i].gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }

        currentTarget = null;
    }*/

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            healFlag = true;
        }

        if (collision.tag == "Enemy")
        {

            collision.GetComponent<EnemyStats>();
            waterTargets.Add(collision);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            healFlag = false;
        }

        if (collision.tag == "Enemy")
        {
            waterTargets.Remove(collision);
        }
    }
}