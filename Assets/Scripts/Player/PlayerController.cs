using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    [SerializeField] public static bool pass_flag = false;
    public float waittime;

    [SerializeField] WaterFirstSkill water_first_skill;

    [SerializeField] DialogManager dialoguesManager;
    [SerializeField] DialoguesController dialoguesController;

    public Rigidbody2D hero;
    //public Transform character;
    public Transform hitBoxPoint;
    public Animator animator;

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

    #region Weapons
    public GameObject bottle_weapon;
    public GameObject BJD_weapon;
    public GameObject student_pass;

    [SerializeField] GameObject student_pass_prefab;
    #endregion

    #region Skills
    public float skillCoolDownTime;
    public float maxSkillCoolDownTime;

    public Image notAvaibleBottle;
    public Image avaibleBottle;
    public Image coolDownBottle;

    [SerializeField] GameObject water;
    public int water_count = 0;
    public bool avaible_skills = false;


    public bool act = false;
    public GameObject BJD;


    public Image notAvaibleBJD;
    public Image avaibleBJD;
    public Image coolDownBJD;

    public float skillCoolDownTime_BJD;
    public float maxSkillCoolDownTime_BJD;
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

        if (avaible_skills == true) 
        {
            if (skillCoolDownTime > 0)
            {
                notAvaibleBottle.gameObject.SetActive(true);
                skillCoolDownTime -= Time.fixedDeltaTime;
                notAvaibleBottle.fillAmount = skillCoolDownTime / maxSkillCoolDownTime;
            }

            if (skillCoolDownTime <= 0)
            {
                notAvaibleBottle.gameObject.SetActive(false);
                avaibleBottle.gameObject.SetActive(true);
                if (Input.GetKey("z") && bottle_weapon.activeSelf == true && water_count == 0)
                {
                    avaibleBottle.gameObject.SetActive(false);
                    water_count = 1;

                    if (facingRight == true)
                    {
                        Instantiate(water, new Vector2(hero.transform.position.x + 3.5f, hero.position.y), Quaternion.identity);
                    }
                    else if (facingRight == false)
                    {
                        Instantiate(water, new Vector2(hero.transform.position.x + 3.5f * -1f, hero.position.y), Quaternion.identity);
                    }
                }
            }
        }



        if (avaible_skills == true && SceneManager.GetActiveScene().buildIndex == 6)
        {

            if (skillCoolDownTime_BJD > 0)
            {
                notAvaibleBJD.gameObject.SetActive(true);
                skillCoolDownTime_BJD -= Time.fixedDeltaTime;
                notAvaibleBJD.fillAmount = skillCoolDownTime_BJD / maxSkillCoolDownTime_BJD;
            }


            if (skillCoolDownTime_BJD <= 0)
            {
                notAvaibleBJD.gameObject.SetActive(false);
                avaibleBJD.gameObject.SetActive(true);
                if (Input.GetKey("z") && BJD_weapon.activeSelf == true && act == false)
                {
                    if (facingRight == true)
                    {
                        Instantiate(BJD, new Vector2(hero.transform.position.x + 1f, hero.position.y), Quaternion.identity);
                    }
                    else if (facingRight == false)
                    {
                        Instantiate(BJD, new Vector2(hero.transform.position.x + 1f * -1f, hero.position.y), Quaternion.identity);
                    }
                    BJD_weapon.SetActive(false);
                    act = true;
                }
            }
        }

        if (Input.GetKey("x") && student_pass.activeSelf == true)
        {
            student_pass.SetActive(false);
            Instantiate(student_pass_prefab, new Vector2(student_pass.transform.position.x + 0.05f * transform.localScale.normalized.x, student_pass.transform.position.y), Quaternion.identity);
        }

        if (Input.GetKey("x") 
        && (attackEnable == true) 
        && (cooldown == maxcooldown) 
        && ((animator.GetBool("BottleAttack") == true) || (animator.GetBool("BJDAttack") == true))
        && (bottle_weapon.activeSelf == true || BJD_weapon.activeSelf == true))
        {
            AttackAnimation();
        }

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
        dialoguesManager.dialogueWindow.SetActive(true);
        dialoguesController.thirdDialogue.TriggerDialog();
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