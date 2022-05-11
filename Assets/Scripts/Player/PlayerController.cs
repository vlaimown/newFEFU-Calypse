using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    [SerializeField] public static bool pass_flag = false;

    float waittime;
    bool attacking = false;

    public Rigidbody2D hero;
    public Transform hitBoxPoint;
    public Animator animator;

    public Vector2 direction;

    #region AttackPoints & AttackRange

    [SerializeField] Transform attackBottlePoint;
    [SerializeField] Transform attackBJD_point;

    public float attackRange;
    #endregion

    public float maxspeed,
                 speed;

    public int moveToHotelFlag;

    bool wait_attack_flag;

    public LayerMask enemyLayers;

     public bool attackEnable, 
                 facingRight;

    public float cooldown,
                 maxcooldown;

    public CharacterStats myStats;

    GameObject currentTarget = null;

    #region Weapons
    public GameObject bottle_weapon;
    public GameObject BJD_weapon;
    public GameObject student_pass;

    [SerializeField] GameObject student_pass_prefab;
    #endregion

    #region Attack Flags
    bool bottle_attack = false;
    bool bjd_attack = false;
    #endregion

    #region Skills
    public bool avaible_skills = false;
    #endregion


    private void Start()
    {
        currentTarget = null;
        hero = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        facingRight = true;

        attackEnable = true;

        moveToHotelFlag = 0;

        maxcooldown = 0.05f;
        cooldown = maxcooldown;

        myStats = GetComponent<CharacterStats>();

        if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            animator.SetBool("ReadyToGo", true);
        }
    }

    private void FixedUpdate()
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

        /*if (Input.GetKey("x") && student_pass.activeSelf == true)
        {
            student_pass.SetActive(false);
            Instantiate(student_pass_prefab, new Vector2(student_pass.transform.position.x + 0.05f * transform.localScale.normalized.x, student_pass.transform.position.y), Quaternion.identity);
        }*/

    #region Attack
        if (Input.GetKey("x") 
        && (attackEnable == true) 
        && (cooldown == maxcooldown)
        && (bottle_weapon.activeSelf == true))
        {
            bottle_attack = true;
            attacking = true;
            AttackAnimation();
        }

        if (Input.GetKey("x")
        && (attackEnable == true)
        && (cooldown == maxcooldown)
        && (BJD_weapon.activeSelf == true))
        {
            bjd_attack = true;
            attacking = true;
            AttackAnimation();
        }
    #endregion

        /* if (Input.GetKey("x") && (attackEnable == true) && (student_pass.activeSelf == true))
         {
             StudentPassAttackMoveToward();
         }

         if (current_student_pass != null) 
         {
             float distance = Vector2.Distance(current_student_pass.transform.position, last_student_point.transform.position);
             float distance_hero_pass = Vector2.Distance(hero.transform.position, current_student_pass.transform.position);

             if (student_pass_attack == true)
             {
                 current_student_pass.transform.position = Vector2.MoveTowards(hero.transform.position, last_student_point.transform.position, Time.deltaTime);
             }
             if (distance <= 0.05f)
             {
                 student_pass_attack = false;
                 current_student_pass.transform.position = Vector2.MoveTowards(last_student_point.transform.position, hero.transform.position, Time.deltaTime);
             }
             if (student_pass_attack = false && (distance_hero_pass <= 0.05f))
             {
                 student_pass.SetActive(true);
             }
         }*/
    }

    /*private void StudentPassAttackMoveToward()
    {
        student_pass_attack = true;
        student_pass.SetActive(false);
        Instantiate(student_pass_prefab, new Vector2(hero.position.x + 2f, hero.position.y), Quaternion.identity);
        current_student_pass = GameObject.Find("пропуск(Clone)");
    }*/

    private void AttackAnimation()
    {
        attackEnable = false;
        speed = 0;
        animator.SetTrigger("IsAttackingDefault");
    }

    public void playerAttack()
    {
        if (bottle_attack == true)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackBottlePoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<CharacterStats>().TakeDamage(myStats.damage.GetValue());

                float dist = Mathf.Infinity;
                var cols = Physics2D.OverlapCircleAll(attackBottlePoint.position, attackRange, enemyLayers);
                Collider2D currentCollider = cols[0];
                foreach (Collider2D col in cols)
                {
                    float currentDist = Vector2.Distance(attackBottlePoint.position, col.transform.position);
                    if (currentDist < dist)
                    {
                        currentCollider = col;
                        dist = currentDist;
                    }
                }
                currentTarget = currentCollider.gameObject;

                StartCoroutine(RedVersionOfSprite());
            }
            bottle_attack = false;
        }

        if (bjd_attack == true)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackBJD_point.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<CharacterStats>().TakeDamage(myStats.damage.GetValue());

                float dist = Mathf.Infinity;
                var cols = Physics2D.OverlapCircleAll(attackBJD_point.position, attackRange, enemyLayers);
                Collider2D currentCollider = cols[0];
                foreach (Collider2D col in cols)
                {
                    float currentDist = Vector2.Distance(attackBJD_point.position, col.transform.position);
                    if (currentDist < dist)
                    {
                        currentCollider = col;
                        dist = currentDist;
                    }
                }
                currentTarget = currentCollider.gameObject;

                StartCoroutine(RedVersionOfSprite());
            }
            bjd_attack = false;
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
        speed = maxspeed;
        wait_attack_flag = true;
        attacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackBottlePoint.position, attackRange);
        Gizmos.DrawWireSphere(attackBJD_point.position, attackRange);
    }

    public void Flip()
    {
        if (attacking == false) {
            if (animator.GetBool("ReadyToGo") == true) {
                facingRight = !facingRight;
                Vector3 scaler = transform.localScale;
                scaler.x *= -1;

                transform.localScale = scaler;
            }
        }
    }

    public void StopPray()
    {
        animator.SetBool("IsPraying", false);
        speed = maxspeed;
    }

    public void functionInvise()
    {
        if (animator.GetBool("BottleAttack") == true)
        {
            if (bottle_weapon.activeSelf == true)
            {
                bottle_weapon.SetActive(false);
            }

            else if (bottle_weapon.activeSelf == false)
            {
                bottle_weapon.SetActive(true);
            }
        }

        else if (animator.GetBool("BJDAttack") == true)
        {
            if (BJD_weapon.activeSelf == true)
            {
                BJD_weapon.SetActive(false);
            }

            else if (BJD_weapon.activeSelf == false)
            {
                BJD_weapon.SetActive(true);
            }
        }
    }
}