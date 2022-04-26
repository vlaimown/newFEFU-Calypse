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
    [SerializeField] Collider2D/*[]*/ currentTarget;
    [SerializeField] int enemy_counter;

    [SerializeField] float currentSkillTime;
    [SerializeField] float maxSkillTime;
    [SerializeField] float skillCoolDownTime;
    [SerializeField] float maxSkillCoolDownTime;

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

        }

        if (healFlag == true && (playerStat.currentHealth < playerStat.maxHealth))
        {
            playerController.hero.GetComponent<PlayerStat>().TakeDamage(-0.2f);
        }

        if (damageFlag == true)
        {
            currentTarget/*[enemy_counter]*/.GetComponent<EnemyStats>().TakeDamage(0.2f);
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
            //for (int i = 0; i < currentTarget.Length; i++)
            //{

            collision.GetComponent<EnemyStats>();
            currentTarget/*[enemy_counter]*/ = collision;
            damageFlag = true;
            //enemy_counter++;
            //currentTarget.GetComponent<Collider2D>();
            //}
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
            damageFlag = false;
        }
    }


    /*if (damageFlag == true)
    {
         Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

         foreach (Collider2D enemy in hitEnemies)
         {
             enemy.GetComponent<CharacterStats>().TakeDamage(myStats.damage.GetValue());

             float dist = Mathf.Infinity;
             var cols = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
             Collider2D currentCollider = cols[0];
             foreach (Collider2D col in cols)
             {
                 float currentDist = Vector2.Distance(attackPoint.position, col.transform.position);
                 if (currentDist < dist)
                 {
                     currentCollider = col;
                     dist = currentDist;
                 }
             }
             currentTarget = currentCollider.gameObject;

             StartCoroutine(RedVersionOfSprite());
         }
    }/*
     //if (water.gameObject != null)
     //{
         //currenttime -= Time.deltaTime;
         //if (currenttime < 0)
         //{
             //Destroy(water.gameObject);
         //}
    // }
 }

 public void OnTriggerExit2D(Collider2D collision)
 {
     if (collision.tag == "Hero")
     {
         healFlag = false;
     }
 }
 /*
 [SerializeField] private PlayerController playerController;
 public GameObject Enemy;
 [SerializeField] private float timeWater = 50f;



 private void Start()
 {
     playerController = FindObjectOfType<PlayerController>();
 }


 public void FixedUpdate()
 {
     timeWater -= Time.deltaTime;
     if (timeWater < 0)
     {
         Destroy(gameObject);
     }
 }

 public void OnTriggerEnter2D(Collider2D other)
 {
     if (other.gameObject.tag == "Player")
     {
         InvokeRepeating("Heal", 0.1f, 0.5f);
     }

     if (other.gameObject.tag == "Enemy")
     {
         InvokeRepeating("Dam", 0.1f, 0.5f);
     }
 }


 public void Heal()
 {
     if (timeWater > 0)
     {
         playerController.hero.GetComponent<CharacterStats>().TakeDamage(-1);
     }
 }

 public void Dam()
 {
     if (timeWater > 0)
     {
         Enemy.GetComponent<CharacterStats>().TakeDamage(5);
     }
 }*/

    /*private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(water.transform.position, waterRange);
    }*/
}