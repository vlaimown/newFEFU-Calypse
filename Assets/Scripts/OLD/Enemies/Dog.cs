using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField] GameObject patrolPoint;
    [SerializeField] GameObject dog;

    Animator anim;

    PlayerController playerController;

    [SerializeField] float triggerRange;
    [SerializeField] float attackRange;
    [SerializeField] float speed;
    [SerializeField] float maxspeed;

    bool go_left, go_right;

    bool dogFacingRight = false;

    [SerializeField] float dash_range;

    Vector2 point1;
    Vector2 point2;

    [SerializeField] GameObject attackPoint;

    private void Start()
    {
        go_left = false;
        go_right = false;

        speed = maxspeed;

        playerController = FindObjectOfType<PlayerController>();
        anim = GetComponent<Animator>();

        point1 = new Vector2(transform.position.x - 5f, transform.position.y);
        point2 = new Vector2(transform.position.x + 5f, transform.position.y);
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(dog.transform.position, playerController.hero.position) > triggerRange)
        {
            if (go_right == false && go_left == false)
            {
                dog.transform.position = Vector2.MoveTowards(dog.transform.position, patrolPoint.transform.position, speed * Time.deltaTime);
                if ((dog.transform.position.x < patrolPoint.transform.position.x) && (dog.transform.localScale.normalized.x > 0))
                {
                    Flip();
                }
                else if ((dog.transform.position.x > patrolPoint.transform.position.x) && (dog.transform.localScale.normalized.x < 0))
                {
                    Flip();
                }
            }

            if (Vector2.Distance(dog.transform.position, patrolPoint.transform.position) <= 0.1f && go_left == false && go_right == false)
            {
                if (dog.transform.localScale.normalized.x > 0)
                {
                    go_left = true;
                    go_right = false;
                }
                else if (dog.transform.localScale.normalized.x < 0)
                {
                    go_left = false;
                    go_right = true;
                }
            }

            if (Vector2.Distance(dog.transform.position, point1) <= 0.1f)
            {
                go_left = false;
                go_right = true;
            }

            else if (Vector2.Distance(dog.transform.position, point2) <= 0.1f)
            {
                go_left = true;
                go_right = false;
            }

            if (go_left == true)
            {
                dog.transform.position = Vector2.MoveTowards(dog.transform.position, point1, speed * Time.deltaTime);
                if (dog.transform.localScale.normalized.x < 0)
                {
                    Flip();
                }
            }

            else if (go_right == true)
            {
                dog.transform.position = Vector2.MoveTowards(dog.transform.position, point2, speed * Time.deltaTime);
                if (dog.transform.localScale.normalized.x > 0)
                {
                    Flip();
                }
            }
        }

        else if (Vector2.Distance(dog.transform.position, playerController.hero.position) <= triggerRange 
            && (Vector2.Distance(playerController.hero.position, dog.transform.position) > attackRange) 
            && (Vector2.Distance(playerController.hero.position, dog.transform.position) > dash_range))
        {
            go_left = false;
            go_right = false;
            dog.transform.position = Vector2.MoveTowards(dog.transform.position, playerController.hero.position, speed * Time.deltaTime);

            if (Vector2.Distance(playerController.hero.position, dog.transform.position) <= attackRange)
            {
                anim.Play("Attack");
                speed = 0;
            }
            else
            {
                speed = maxspeed;
            }


            if (dogFacingRight == true && playerController.hero.transform.position.x < transform.position.x)
            {
                Flip();
            }

            else if (dogFacingRight == false && playerController.hero.transform.position.x > transform.position.x)
            {
                Flip();
            }
        }

        if (Vector2.Distance(attackPoint.transform.position, playerController.hero.position) <= dash_range && Vector2.Distance(attackPoint.transform.position, playerController.hero.position) > attackRange)
        {
            dog.transform.position = Vector2.MoveTowards(dog.transform.position, playerController.hero.position, speed * Time.deltaTime);
            speed *= 2;
            //anim.Play("Dash");
        }
    }

    //void DogAttack()
    //{
    //    playerController.GetComponent<PlayerStat>().TakeDamage(20f);
    //}

    //void EndOfDash()
    //{
    //    playerController.GetComponent<PlayerStat>().TakeDamage(40f);
    //    speed = maxspeed;
    //}

    public void Flip()
    {
        dogFacingRight = !dogFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;

        transform.localScale = scaler;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, triggerRange);
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
        Gizmos.DrawWireSphere(attackPoint.transform.position, dash_range);
    }
}
