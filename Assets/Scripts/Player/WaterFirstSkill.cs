using System.Collections.Generic;
using UnityEngine;

public class WaterFirstSkill : MonoBehaviour
{
    #region Sounds
    [SerializeField] GameObject water_splash;
    #endregion

    PlayerController playerController;
    [SerializeField] SkillsUI skillUI;
    BottleWeapon bottleWeapon;

    bool damageFlag;
    bool healFlag;

    PlayerStat playerStat;

    public List<Collider2D> waterTargets;
    int enemy_counter;

    [SerializeField]float currentSkillTime;
    [SerializeField]float maxSkillTime;

    [SerializeField] AudioSource water_splash_sound;

    private void Start()
    {
        skillUI = FindObjectOfType<SkillsUI>();
        playerController = FindObjectOfType<PlayerController>();
        playerStat = FindObjectOfType<PlayerStat>();
        bottleWeapon = FindObjectOfType<BottleWeapon>();
        currentSkillTime = maxSkillTime;
        Instantiate(water_splash_sound, transform.position, Quaternion.identity);
    }

    private void FixedUpdate()
    {
        if (gameObject != null)
        {
            currentSkillTime -= Time.fixedDeltaTime;
            skillUI.avaibleBottle.gameObject.SetActive(false);
            skillUI.coolDownBottle.gameObject.SetActive(true);
            skillUI.coolDownBottle.fillAmount = currentSkillTime / maxSkillTime;
        }
        if (currentSkillTime < 0)
        {
            skillUI.coolDownBottle.gameObject.SetActive(false);
            skillUI.notAvaibleBottle.gameObject.SetActive(true);
            Destroy(gameObject);
            currentSkillTime = maxSkillTime;
            bottleWeapon.water_count = 0;

            bottleWeapon.skillCoolDownTime = bottleWeapon.maxSkillCoolDownTime;
        }

        if (healFlag == true && (playerStat.currentHealth < playerStat.maxHealth))
        {
            playerController.hero.GetComponent<PlayerStat>().TakeDamage(-0.25f);
        }

        foreach (Collider2D enemy in waterTargets)
        {
            enemy.GetComponent<EnemyStats>().TakeDamage(0.4f);
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
