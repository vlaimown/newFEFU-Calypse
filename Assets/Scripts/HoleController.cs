using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoleController : MonoBehaviour
{
    [SerializeField] float maxHoleWaitTime;
    [SerializeField] float currentHoleWaitTime;

    public static bool goInFlag = true;

    [SerializeField] DialogManager dialogManager;
    [SerializeField] DialoguesController dialoguesController;

    [SerializeField] InventoryUI inventoryUI;

    [SerializeField] Image fade;
    [SerializeField] Image blackout;

    [SerializeField] PlayerController playerController;

    [SerializeField] GameObject nextDoor;
    [SerializeField] float interactiveWithTheDoor;

    [SerializeField] Image interactiveButton;
    [SerializeField] BoxCollider2D block;

    [SerializeField] static bool first_dialogue_with_security_complete = false;
    public static bool quest_with_security_finished = false;
    //public static bool security_quetion = false;

    private void Awake()
    {
        fade.gameObject.SetActive(true);
        inventoryUI.gameObject.SetActive(true);

        playerController = FindObjectOfType<PlayerController>();
        if (GoToKitchen.to_hole == true)
        {
            playerController.hero.transform.position = new Vector2(12.67f, 6.29f);
        }
    }

    private void Start()
    {
        if (PlayerController.pass_flag == true || quest_with_security_finished == true) // тут другая проверка нужна (после кухни)
        {
            playerController.avaible_skills = true;
        }

        if (first_dialogue_with_security_complete == false)
        {
            currentHoleWaitTime = maxHoleWaitTime;
        }
        GoToKitchen.to_hole = false;
    }

    private void FixedUpdate()
    {
        if (quest_with_security_finished == true)
        {
            block.gameObject.SetActive(false);
        }

        if (quest_with_security_finished == false)
        {
            if (currentHoleWaitTime > 0)
            {
                currentHoleWaitTime -= Time.deltaTime;
            }

            if (currentHoleWaitTime <= 0 && dialogManager.dialogueNumber == 1 && PlayerController.pass_flag == false)
            {
                dialogManager.dialogueWindow.SetActive(true);
                dialoguesController.tenthDialogue.TriggerDialog();
                first_dialogue_with_security_complete = true;
            }

            if (playerController.student_pass.activeSelf == true && dialogManager.dialogueNumber == 2)
            {
                dialogManager.dialogueWindow.SetActive(true);
                dialoguesController.fifteenthDialogue.TriggerDialog();
                block.gameObject.SetActive(false);
                quest_with_security_finished = true;
            }
        }

        if (Vector2.Distance(playerController.hero.position, nextDoor.transform.position) <= interactiveWithTheDoor)
        {
            if (Input.GetKey("e"))
            {
                blackout.gameObject.SetActive(true);
                goInFlag = true;
            }
        }
        else
        {
            goInFlag = false;
         }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactiveButton.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactiveButton.gameObject.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(nextDoor.transform.position, interactiveWithTheDoor);
    }
}
