using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KitchenController : MonoBehaviour
{
    public static bool indianQuest = false;

    [SerializeField] DialogManager dialogManager;
    [SerializeField] DialoguesController dialoguesController;

    [SerializeField] PlayerController playerController;

    [SerializeField] Image fade;
    [SerializeField] Image blackout;

    [SerializeField] GameObject inventoryUI;

    [SerializeField] GameObject door;
    [SerializeField] float interactiveWithDoor;

    [SerializeField] Image interativeButton;

    private void Awake()
    {
        inventoryUI.SetActive(true);
        playerController = FindObjectOfType<PlayerController>();
        fade.gameObject.SetActive(true);

        HoleController.quest_with_security_finished = true;
        GoToKitchen.to_hole = true;
    }

    private void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
        dialoguesController = FindObjectOfType<DialoguesController>();
        HoleController.quest_with_security_finished = true;
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(door.transform.position, playerController.hero.position) <= interactiveWithDoor)
        {
            interativeButton.gameObject.SetActive(true);
            if (Input.GetKey("e"))
            {
                blackout.gameObject.SetActive(true);
            }
        }
        else
        {
            interativeButton.gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(door.transform.position, interactiveWithDoor);
    }
}
