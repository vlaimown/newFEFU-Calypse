using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float waittime;

    [SerializeField] GameController gameController;

    [SerializeField] private DialogManager dialoguesManager;
    [SerializeField] private DialoguesController dialoguesController;

    public Rigidbody2D hero;
    public Transform character;
    [SerializeField] private Animator animator;

    public Vector2 direction;

    public Transform attackPoint;
    public float attackRange;

    public float maxspeed;
    public float speed;

    public int flag,
               moveToHotelFlag;
                

    public LayerMask enemyLayers;

     public bool attackEnable;

     public float cooldown,
                  maxcooldown;

     public bool facingRight;

    public CharacterStats myStats;

    private void Start()
    { 
        hero = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        facingRight = true;

        speed = maxspeed;
        attackEnable = true;

        flag = 0;
        moveToHotelFlag = 0;

        maxcooldown = 1f;
        cooldown = maxcooldown;

        myStats = GetComponent<CharacterStats>();
    }

    private void FixedUpdate()
    {
        if (dialoguesController.startFlag == 1)
        {
        
        moveToHotelFlag = 1;

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

        if (Input.GetKey("h") && (attackEnable == true) && (cooldown == 1) && flag == 0)
        {
           //Attack(myStats);
           AttackAnimation();
        }
    }
}

    private void AttackAnimation()
    {
        speed = 0;
        animator.SetBool("IsAttacking", true);
    }

    public void playerAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<CharacterStats>().TakeDamage(myStats.damage.GetValue());
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

    public void Flip()
    {
        if (animator.GetBool("ReadyToGo") == true) {
            facingRight = !facingRight;
            Vector3 scaler = transform.localScale;
            scaler.x *= -1;

            transform.localScale = scaler;
        }
    }

    public void StopPray()
    {
        animator.SetBool("IsPraying", false);
        speed = maxspeed;
        attackEnable = true;
        dialoguesManager.dialogueWindow.SetActive(true);
        gameController.firstQuest.gameObject.SetActive(false);
        gameController.backgroundQuest.gameObject.SetActive(false);
        gameController.questText.gameObject.SetActive(false);
        dialoguesController.thirdDialogue.TriggerDialog();
    }
}