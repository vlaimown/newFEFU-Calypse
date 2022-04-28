using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToOutside : MonoBehaviour
{
    [SerializeField] float interactive_distance;
    [SerializeField] PlayerController playerController;

    [SerializeField] Image interactive_button;
    [SerializeField] Image blackout;

    private void FixedUpdate()
    {
        if (Vector2.Distance(playerController.hero.position, transform.position) <= interactive_distance)
        {
            //interactive_button.gameObject.SetActive(true);
            if (Input.GetKey("e"))
            {
                blackout.gameObject.SetActive(true);
            }
        }
        //else
        //{
            //interactive_button.gameObject.SetActive(false);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactive_button.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactive_button.gameObject.SetActive(false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, interactive_distance);
    }
}
