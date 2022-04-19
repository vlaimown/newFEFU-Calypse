using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public PlayerController playerController;

    public bool zombieAttackFlag;

    CharacterCombat combat;
    Transform target;

    [SerializeField] float triggerZone;
    [SerializeField] float zombieAttackZone;
    [SerializeField] float speed;
    [SerializeField] float maxspeed;
    [SerializeField] bool zombieFacingRight;

    [SerializeField] Animator anim;

    /*[SerializeField]*/
    public Transform zombiePosition;
    [SerializeField] Transform zombieAttackArea;
    [SerializeField] LayerMask hero;

    [SerializeField] CharacterStats myStats;

    public Rigidbody2D zombieBody;

    private void Start()
    {
        zombieBody = GetComponent<Rigidbody2D>();
        zombieAttackFlag = false;

        target = PlayerManager.instance.player.transform;

        playerController = FindObjectOfType<PlayerController>();
        zombiePosition = GetComponent<Transform>();
        combat = GetComponent<CharacterCombat>();

        zombieFacingRight = false;
        myStats = GetComponent<CharacterStats>();
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(playerController.hero.transform.position, transform.position) <= triggerZone && (Vector2.Distance(playerController.hero.transform.position, transform.position) > zombieAttackZone))
        {
            anim.SetBool("IsAttacking", false);
            anim.SetBool("IsRunning", true);
            transform.position = Vector2.MoveTowards(transform.position, playerController.hero.transform.position, speed * Time.deltaTime);
            speed = maxspeed;
        }

        if (Vector2.Distance(playerController.hero.transform.position, transform.position) < zombieAttackZone)
        {
            CharacterStats targetStats = target.GetComponent<CharacterStats>();
            anim.SetBool("IsAttacking", true);
            zombieAttackFlag = true;
            /*if (targetStats != null)
            {
                zombieAttackFlag = true;
                combat.Attack(targetStats);
            }*/
            speed = 0;
        }

        if (Vector2.Distance(playerController.hero.transform.position, transform.position) > triggerZone)
        {
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsAttacking", false);
            anim.Play("ZombieIdle");
        }

        if (zombieFacingRight == true && playerController.hero.transform.position.x < transform.position.x)
        {
            Flip();
        }

        else if (zombieFacingRight == false && playerController.hero.transform.position.x > transform.position.x)
        {
            Flip();
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetBool("IsAttacking", true);
        anim.SetBool("IsRunnning", false);
        speed = 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetBool("IsAttacking", false);
        anim.SetBool("IsRunning", true);
        speed = maxspeed;
    }*/

    public void Flip()
    {
        zombieFacingRight = !zombieFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;

        transform.localScale = scaler;
    }

    void ZombieAttack()
    {
        if (gameObject != null)
        {
            Collider2D[] hitHeroes = Physics2D.OverlapCircleAll(zombieAttackArea.position, zombieAttackZone, hero);

            foreach (Collider2D hero in hitHeroes)
            {
                hero.GetComponent<CharacterStats>().TakeDamage(myStats.damage.GetValue());
                //hero.GetComponent<SpriteRenderer>().color = Color.red;
                StartCoroutine(RedVersionOfSprite());
            }
        }
        else
        {
            playerController.hero.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, triggerZone);
    }

    private void OnDrawGizmosSelected()
    {
        if (zombieAttackArea == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(zombieAttackArea.position, zombieAttackZone);
    }

    IEnumerator RedVersionOfSprite()
    {
        if (gameObject != null)
        {
            playerController.hero.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.35f);
            playerController.hero.GetComponent<SpriteRenderer>().color = Color.white;
        } else
        {
            playerController.hero.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}