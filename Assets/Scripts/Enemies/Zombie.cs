using UnityEngine;

public class Zombie : MonoBehaviour
{
    public PlayerController playerController;

    [SerializeField] float triggerZone;
    [SerializeField] float zombieAttackZone;
    [SerializeField] float speed;
    [SerializeField] float maxspeed;
    [SerializeField] bool zombieFacingRight;

    [SerializeField] Animator anim;

    [SerializeField] Transform zombiePosition;
    [SerializeField] Transform zombieAttackArea;

    private void Start()
    { 
        playerController = FindObjectOfType<PlayerController>();
        zombiePosition = GetComponent<Transform>();

        zombieFacingRight = false;
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
            anim.SetBool("IsAttacking", true);
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

}
