using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float waittime;

    [SerializeField] GameController gameController;

    [SerializeField] DialogManager dialoguesManager;
    [SerializeField] DialoguesController dialoguesController;

    public Rigidbody2D hero;
    public Transform character;
    [SerializeField] private Animator animator;

    public Vector2 direction;

    public Transform attackPoint;
    public float attackRange;

    public float maxspeed,
                 speed;

    public int moveToHotelFlag;

    [SerializeField] bool wait_attack_flag;
                

    public LayerMask enemyLayers;

     public bool attackEnable, 
                 facingRight;

    public float cooldown,
                  maxcooldown;

    public CharacterStats myStats;

    public SpriteRenderer zombie;

    [SerializeField] GameObject currentTarget = null;

    private void Start()
    {
        currentTarget = null;
        hero = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        facingRight = true;

        speed = maxspeed;
        attackEnable = true;

        moveToHotelFlag = 0;

        maxcooldown = 0.3f;
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

        if (wait_attack_flag == true)
        {
            cooldown -= Time.deltaTime;
        }
        if (cooldown <= 0 && wait_attack_flag == true)
        {
            cooldown = maxcooldown;
            wait_attack_flag = false;
            attackEnable = true;
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

        if (Input.GetKey("h") && (attackEnable == true) && (cooldown == maxcooldown) && animator.GetBool("BottleAttack") == true)
        {
           AttackAnimation();
        }
    }
}

    private void AttackAnimation()
    {
        attackEnable = false;
        speed = 0;
        animator.SetTrigger("IsAttackingDefault");
    }

    public void playerAttack()
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
    }

    IEnumerator RedVersionOfSprite()
    {
        currentTarget.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.35f);
        currentTarget.gameObject.GetComponent<SpriteRenderer>().color = Color.white;

        currentTarget = null;
    }

    private void ReturnAttack()
    {
        //attackEnable = true;
        speed = maxspeed;
        wait_attack_flag = true;
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
        //attackEnable = true;
        dialoguesManager.dialogueWindow.SetActive(true);
        gameController.firstQuest.gameObject.SetActive(false);
        gameController.backgroundQuest.gameObject.SetActive(false);
        gameController.questText.gameObject.SetActive(false);
        dialoguesController.thirdDialogue.TriggerDialog();
    }

    public void functionForBottleAttack()
    {
        if (gameController.bottle.activeSelf == true)
        {
            gameController.bottle.SetActive(false);
        }

        else if (gameController.bottle.activeSelf == false)
        {
            gameController.bottle.SetActive(true);
        }
    }
}