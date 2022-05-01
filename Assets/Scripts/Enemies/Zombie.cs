using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] AudioSource classicZombie;

    public PlayerController playerController;

    public float distnce;
    public bool zombieAttackFlag;

    CharacterCombat combat;
    [SerializeField] Transform target;

    [SerializeField] float triggerZone;
    [SerializeField] float zombieAttackZone;
    public float speed;
    public float maxspeed;
    [SerializeField] bool zombieFacingRight;

    [SerializeField] Animator anim;

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
        distnce = Vector2.Distance(playerController.hitBoxPoint.transform.position, zombieAttackArea.transform.position);

        if ((Vector2.Distance(playerController.hero.transform.position, transform.position) <= triggerZone))
        {
            anim.SetBool("IsAttacking", false);
            anim.SetBool("IsRunning", true);
            transform.position = Vector2.MoveTowards(transform.position, playerController.hero.position, speed * Time.deltaTime);
            speed = maxspeed;
        }

        if (Mathf.Abs(distnce) <= zombieAttackZone)
        {
            CharacterStats targetStats = target.GetComponent<CharacterStats>();
            anim.SetBool("IsAttacking", true);
            zombieAttackFlag = true;
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