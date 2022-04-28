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

    private void Awake()
    {
        fade.gameObject.SetActive(true);
        inventoryUI.gameObject.SetActive(true);

        playerController = FindObjectOfType<PlayerController>();
    }

    private void Start()
    {
        if (PlayerController.pass_flag == true) // тут другая проверка нужна (после кухни)
        {
            playerController.avaible_skills = true;
        }

        if (PlayerController.pass_flag == true) // тут другая проверка нужна (после кухни)
        {
            block.gameObject.SetActive(false);
        }

        if (PlayerController.pass_flag == false)
        {
            currentHoleWaitTime = maxHoleWaitTime;
        }
    }

    private void FixedUpdate()
    {
        if (currentHoleWaitTime > 0)
        {
            currentHoleWaitTime -= Time.deltaTime;
        }

        if (currentHoleWaitTime <= 0 && dialogManager.dialogueNumber == 1 && PlayerController.pass_flag == false)
        {
            dialogManager.dialogueWindow.SetActive(true);
            dialoguesController.tenthDialogue.TriggerDialog();
        }

        /*if (dialogManager.dialogueNumber == 1 && PlayerController.pass_flag == true)
        {
            dialogManager.dialogueWindow.SetActive(true);
            dialoguesController.fourteenthDialogue.TriggerDialog();
        }*/

        if (playerController.student_pass.activeSelf == true && dialogManager.dialogueNumber == 2)
        {
            dialogManager.dialogueWindow.SetActive(true);
            dialoguesController.fifteenthDialogue.TriggerDialog();
        }

        if (Vector2.Distance(playerController.hero.position, nextDoor.transform.position) <= interactiveWithTheDoor)
        {
            interactiveButton.gameObject.SetActive(true);
            if (Input.GetKey("e"))
            {
                blackout.gameObject.SetActive(true);
                goInFlag = true;
            }
        }
        else
        {
            interactiveButton.gameObject.SetActive(false);
            goInFlag = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(nextDoor.transform.position, interactiveWithTheDoor);
    }
}
