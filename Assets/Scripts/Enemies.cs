using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemies : MonoBehaviour
{
    [SerializeField] int maxHealth = 100,
        currentHealth;

    [SerializeField] float maxspeed,
        speed;

    public int damage;

    [SerializeField] float attackZone;
    [SerializeField] float triggerZone;

    bool facingRight = false;

    [SerializeField] PlayerController playerController;
    [SerializeField] Transform attackArea;
    [SerializeField] Animator anim;
    [SerializeField] Image healthBar;

    [SerializeField] LayerMask hero;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        anim = GetComponent<Animator>();
        speed = maxspeed;
    }

    protected void Move()
    {
        float distance = Vector2.Distance(playerController.hitBoxPoint.transform.position, attackArea.transform.position);

        //if (enemyStats.staggered == false)
        //{

        if ((Vector2.Distance(playerController.hero.transform.position, transform.position) <= triggerZone))
        {
            anim.SetBool("IsAttacking", false);
            anim.SetBool("IsRunning", true);
            transform.position = Vector2.MoveTowards(transform.position, playerController.hero.position, speed * Time.deltaTime);
            speed = maxspeed;
        }

        if (Mathf.Abs(distance) <= attackZone)
        {
            //CharacterStats targetStats = target.GetComponent<CharacterStats>();
            anim.SetBool("IsAttacking", true);
           // zombieAttackFlag = true;
            speed = 0;
        }

        if (Vector2.Distance(playerController.hero.transform.position, transform.position) > triggerZone)
        {
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsAttacking", false);
            anim.Play("Idle");
        }

        if (facingRight == true && playerController.hero.transform.position.x < transform.position.x)
        {
            Flip();
        }

        else if (facingRight == false && playerController.hero.transform.position.x > transform.position.x)
        {
            Flip();
        }
        //}
    }


    public void Attack()
    {
        if (gameObject != null)
        {
            Collider2D[] hitHeroes = Physics2D.OverlapCircleAll(attackArea.position, attackZone, hero);

            foreach (Collider2D hero in hitHeroes)
            {
                //hero.GetComponent<>().TakeDamage(/*myStats.damage.GetValue()*/damage);
                if (gameObject != null)
                {
                    StartCoroutine(RedVersionOfSprite());
                }
            }
        }
        else
        {
            playerController.hero.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount -= damage / maxHealth;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;

        transform.localScale = scaler;
    }

    IEnumerator RedVersionOfSprite()
    {
        if (gameObject != null)
        {
            playerController.hero.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.35f);
            playerController.hero.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            playerController.hero.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackArea == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackArea.position, attackZone);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, triggerZone);
    }
}
