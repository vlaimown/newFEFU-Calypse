using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private DialoguesController dialoguesController;

    [SerializeField] private Rigidbody2D hero;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed;

    [SerializeField] private Vector2 direction;

    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 0.5f;
    public float damage = 0.5f;

    public GameObject firstDialogue;

    public float maxspeed;

    public int flag;

    public LayerMask enemyLayers;

    public bool attackEnable;
    public float cooldown;
    public float maxcooldown;

    private bool facingRight = true;

    private void Start()
    {

        speed = maxspeed;
        attackEnable = true;

        flag = 0;

        maxcooldown = 1f;
        cooldown = maxcooldown;
    }

    private void FixedUpdate()
    {
        if (dialoguesController.startFlag == 1)
        {

            direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
            animator.SetFloat("Speed", direction.sqrMagnitude);

            if (cooldown > 0 && flag == 1)
            {
                cooldown -= Time.deltaTime;
                attackEnable = false;
            }
            else if (cooldown <= 0)
            {
                attackEnable = true;
                cooldown = maxcooldown;
                flag = 0;
            }

            hero.MovePosition(hero.position + direction * speed * Time.deltaTime);

            if (facingRight == true && direction.x < 0)
            {
                Flip();
            }

            else if (facingRight == false && direction.x > 0)
            {
                Flip();
            }

            if (Input.GetButtonDown("Fire1") && (attackEnable == true) && (cooldown == 1) && flag == 0)
            {
                Attack();
            }
        }
    }

    private void Attack()
    {
        speed = 0;

        animator.SetBool("IsAttacking", true);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            GetComponent<EnemyHP>().DamageEnemy(damage);
            Debug.Log("We hit " + enemy.name);
        }
    }

    private void ReturnAttack()
    {
        animator.SetBool("IsAttacking", false);
        attackEnable = false;
        speed = maxspeed;
        flag = 1;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;

        transform.localScale = scaler;
    }
}