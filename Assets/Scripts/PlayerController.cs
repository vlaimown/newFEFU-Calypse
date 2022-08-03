using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    #region Vars
    public Rigidbody2D hero;
    public Animator animator;
    public Vector2 direction;

    public float maxspeed,
             speed;

    public bool attackEnable,
                facingRight;

    PlayerCombat playerCombat;

    public Transform hitBoxPoint;
    #endregion

    //public static bool pass_flag = false;

    //bool attacking = false;

    //#region AttackPoints & AttackRange

    //[SerializeField] Transform attackBottlePoint;
    //[SerializeField] Transform attackBJD_point;

    //public float attackRange;
    //#endregion

    //public int moveToHotelFlag;

    //bool wait_attack_flag;

    //public LayerMask enemyLayers;

    //public float cooldown,
    //             maxcooldown;


    //GameObject current_student_pass;
    //GameObject last_student_point;
    //bool student_pass_attack = false;

    //public CharacterStats myStats;

    //GameObject currentTarget = null;
    //[SerializeField] StanEnemyByAttack stanEnemyByAttack;
    //#region Weapons
    //public GameObject bottle_weapon;
    //public GameObject BJD_weapon;
    //public GameObject student_pass;

    //[SerializeField] GameObject student_pass_prefab;
    //#endregion

    //#region Attack Flags
    //bool bottle_attack = false;
    //bool bjd_attack = false;
    //#endregion

    //#region Skills
    //public bool avaible_skills = false;
    //#endregion


    private void Start()
    {
        hero = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerCombat = GetComponent<PlayerCombat>();
        facingRight = true;

        // currentTarget = null;
        // attackEnable = true;

        // moveToHotelFlag = 0;

        // maxcooldown = 0.05f;
        // cooldown = maxcooldown;

        //myStats = GetComponent<CharacterStats>();

        //if (SceneManager.GetActiveScene().buildIndex != 2)
        //{
        //    animator.SetBool("ReadyToGo", true);
        //}
    }

    private void Update()
    {
        if (Input.GetButtonDown(GlobalStringVars.ATTACK))
        {
            playerCombat.playerAttack();
        }
    }
    private void FixedUpdate()
    {
        // moveToHotelFlag = 1;

        //if (wait_attack_flag == true)
        //{
        //    cooldown -= Time.deltaTime;
        //}
        //if (cooldown <= 0 && wait_attack_flag == true)
        //{
        //    cooldown = maxcooldown;
        //    wait_attack_flag = false;
        //    attackEnable = true;
        //}

        MoveCharacter();
    }

    void MoveCharacter()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);

        if (facingRight == true && direction.x < 0)
        {
            Flip();
        }

        else if (facingRight == false && direction.x > 0)
        {
            Flip();
        }

        hero.MovePosition(hero.position + direction * speed * Time.deltaTime);
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;

        transform.localScale = scaler;
        // if (attacking == false)
        //{
        //if (animator.GetBool("ReadyToGo") == true)
        // {
        //}
        //}
    }

    private void ReturnAttack()
    {
        speed = maxspeed;
        //wait_attack_flag = true;
        //attacking = false;
    }
}

/*if (Input.GetKey("x") && student_pass.activeSelf == true)
{
    student_pass.SetActive(false);
    Instantiate(student_pass_prefab, new Vector2(student_pass.transform.position.x + 0.05f * transform.localScale.normalized.x, student_pass.transform.position.y), Quaternion.identity);
}*/

//    #region Attack
//        if (Input.GetKey("x") 
//        && (attackEnable == true) 
//        && (cooldown == maxcooldown)
//        && (bottle_weapon.activeSelf == true))
//        {
//            bottle_attack = true;
//            attacking = true;
//            AttackAnimation();
//        }

//        if (Input.GetKey("x")
//        && (attackEnable == true)
//        && (cooldown == maxcooldown)
//        && (BJD_weapon.activeSelf == true))
//        {
//            bjd_attack = true;
//            attacking = true;
//            AttackAnimation();
//        }
//    #endregion

//         if (Input.GetKey("x") && (attackEnable == true) && (student_pass.activeSelf == true))
//         {
//             StudentPassAttackMoveToward();
//         }

//         if (current_student_pass != null) 
//         {
//             float distance = Vector2.Distance(current_student_pass.transform.position, last_student_point.transform.position);
//             float distance_hero_pass = Vector2.Distance(hero.transform.position, current_student_pass.transform.position);

//             if (student_pass_attack == true)
//             {
//                 current_student_pass.transform.position = Vector2.MoveTowards(hero.transform.position, last_student_point.transform.position, Time.deltaTime);
//             }
//             if (distance <= 0.05f)
//             {
//                 student_pass_attack = false;
//                 current_student_pass.transform.position = Vector2.MoveTowards(last_student_point.transform.position, hero.transform.position, Time.deltaTime);
//             }
//             if (student_pass_attack = false && (distance_hero_pass <= 0.05f))
//             {
//                 student_pass.SetActive(true);
//             }
//         }
//    }

//    private void StudentPassAttackMoveToward()
//    {
//        student_pass_attack = true;
//        student_pass.SetActive(false);
//        Instantiate(student_pass_prefab, new Vector2(hero.position.x + 2f, hero.position.y), Quaternion.identity);
//        current_student_pass = GameObject.Find("пропуск(Clone)");
//    }

//    private void AttackAnimation()
//    {
//        attackEnable = false;
//        speed = 0;
//        animator.SetTrigger("IsAttackingDefault");
//    }

//    public void StopPray()
//    {
//        animator.SetBool("IsPraying", false);
//        speed = maxspeed;
//    }

//    public void functionInvise()
//    {
//        if (animator.GetBool("BottleAttack") == true)
//        {
//            if (bottle_weapon.activeSelf == true)
//            {
//                bottle_weapon.SetActive(false);
//            }

//            else if (bottle_weapon.activeSelf == false)
//            {
//                bottle_weapon.SetActive(true);
//            }
//        }

//        else if (animator.GetBool("BJDAttack") == true)
//        {
//            if (BJD_weapon.activeSelf == true)
//            {
//                BJD_weapon.SetActive(false);
//            }

//            else if (BJD_weapon.activeSelf == false)
//            {
//                BJD_weapon.SetActive(true);
//            }
//        }
//    }
//}