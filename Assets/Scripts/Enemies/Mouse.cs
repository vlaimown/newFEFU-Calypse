using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] PlayerController playerController;
    [SerializeField] float distance;
    [SerializeField] float stopDistance;

    [SerializeField] float speed = 3f;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //distance = Vector2.Distance(transform.position, playerController.hero.position);
       // if (distance > stopDistance)
        //{
            transform.position = Vector2.MoveTowards(transform.position, playerController.hero.position, speed * Time.deltaTime);
        //}
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }
}
