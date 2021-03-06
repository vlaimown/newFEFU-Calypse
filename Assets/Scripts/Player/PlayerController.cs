using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    [SerializeField] public static bool pass_flag = false;

    [SerializeField] AudioSource water_splash;
    public float waittime;

    [SerializeField] GameController gameController;
    [SerializeField] Skill waterSkill;

    [SerializeField] DialogManager dialoguesManager;
    [SerializeField] DialoguesController dialoguesController;

    public Rigidbody2D hero;
    public Transform character;
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
    #endregion


    private void Start()
    {
        currentTarget = null;
        hero = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        facingRight = true;

        attackEnable = true;

        moveToHotelFlag = 0;

        maxcooldown = 0.25f;
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
                    Instantiate(water_splash, transform.position, Quaternion.identity);
                    avaibleBottle.gameObject.SetActive(false);
                    water_count = 1;

                    if (facingRight == true)
                    {
                        Instantiate(water, new Vector2(character.transform.position.x + 3.5f, character.position.y), Quaternion.identity);
                    }
                    else if (facingRight == false)
                    {
                        Instantiate(water, new Vector2(character.transform.position.x + 3.5f * -1f, character.position.y), Quaternion.identity);
                    }
                }
            }
        }

        if (Input.GetKey("x") 
        && (attackEnable == true) 
        && (cooldown == maxcooldown) 
        && ((animator.GetBool("BottleAttack") == true) || (animator.GetBool("BJDAttack") == true))
        && (bottle_weapon.activeSelf == true || BJD_weapon.activeSelf == true))
        {
            AttackAnimation();
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