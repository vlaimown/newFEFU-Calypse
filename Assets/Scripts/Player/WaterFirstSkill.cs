using System.Collections.Generic;
using UnityEngine;

public class WaterFirstSkill : MonoBehaviour
{
    #region Sounds
    [SerializeField] GameObject water_splash;
    #endregion

    [SerializeField] PlayerController playerController;

    [SerializeField] bool damageFlag;
    [SerializeField] bool healFlag;

    [SerializeField] PlayerStat playerStat;

    public List<Collider2D> waterTargets;
    [SerializeField] int enemy_counter;

    [SerializeField] float currentSkillTime;
    [SerializeField] float maxSkillTime;

    [SerializeField] AudioSource water_splash_sound;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        playerStat = FindObjectOfType<PlayerStat>();
        currentSkillTime = maxSkillTime;
        Instantiate(water_splash_sound, transform.position, Quaternion.identity);
    }

    private void FixedUpdate()
    {
        if (gameObject != null)
        {
            currentSkillTime -= Time.fixedDeltaTime;
            playerController.avaibleBottle.gameObject.SetActive(false);
            playerController.coolDownBottle.gameObject.SetActive(true);
            playerController.coolDownBottle.fillAmount = currentSkillTime / maxSkillTime;
        }
        if (currentSkillTime < 0)
        {
            playerController.coolDownBottle.gameObject.SetActive(false);
            playerController.notAvaibleBottle.gameObject.SetActive(true);
            Destroy(gameObject);
            currentSkillTime = maxSkillTime;
            playerController.water_count = 0;

            playerController.skillCoolDownTime = playerController.maxSkillCoolDownTime;
        }

        if (healFlag == true && (playerStat.currentHealth < playerStat.maxHealth))
        {
            playerController.hero.GetComponent<PlayerStat>().TakeDamage(-0.25f);
        }

        foreach (Collider2D enemy in waterTargets)
        {
            enemy.GetComponent<EnemyStats>().TakeDamage(0.35f);
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
