using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] float distance;
    [SerializeField] float stopDistance;

    [SerializeField] float speed = 3f;
    [SerializeField] GameObject attackPoint;

    Animator anim;
    bool mouseFacingRight = false;
    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void FixedUpdate()
    {
        distance = Vector2.Distance(transform.position, playerController.hero.position);
        if (distance > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerController.hero.position, speed * Time.deltaTime);
        }
        else if (distance <= stopDistance)
        {
            anim.Play("Attack");
        }

        if (mouseFacingRight == true && playerController.hero.transform.position.x < transform.position.x)
        {
            Flip();
        }

        else if (mouseFacingRight == false && playerController.hero.transform.position.x > transform.position.x)
        {
            Flip();
        }
    }

    public void Flip()
    {
        mouseFacingRight = !mouseFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;

        transform.localScale = scaler;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, stopDistance);
    }
}
