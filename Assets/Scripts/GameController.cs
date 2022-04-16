using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{


    public DialoguesController dialoguesController;
    public DialogManager dialogManager;
    public Inventory inventory;

    public Animator anim;
    private int bottleFlag = 0;

    public Text firstQuest;
    public Text secondQuest;
    public Text thirdQuest;
    public Text fourthQuest;

    public GameObject zombie_1;

    public Image backgroundQuest;
    public Text questText;

    private void FixedUpdate()
    {
        if (dialogManager.PrayFlag == 1)
        {
            firstQuest.gameObject.SetActive(true);
            backgroundQuest.gameObject.SetActive(true);
            questText.gameObject.SetActive(true);
        }

        if (dialogManager.dialogueNumber == 4 && dialoguesController.fourthDialogueFlag != 1)
        {
            secondQuest.gameObject.SetActive(true);
            backgroundQuest.gameObject.SetActive(true);
            questText.gameObject.SetActive(true);
        }

        if (dialoguesController.fourthDialogueFlag == 1)
        {
            secondQuest.gameObject.SetActive(false);
            backgroundQuest.gameObject.SetActive(false);
            questText.gameObject.SetActive(false);
            if (dialogManager.dialogueNumber == 5)
            {
                thirdQuest.gameObject.SetActive(true);
                backgroundQuest.gameObject.SetActive(true);
                questText.gameObject.SetActive(true);
                //Destroy(dialoguesController.fourthDialogue.gameObject);
            }
        }

        if (inventory.itemList.Exists(item => item.name == "Slavda Bottle (1)") && bottleFlag == 0)
        {
            dialoguesController.fourthDialogueFlag = 2;
            thirdQuest.gameObject.SetActive(false);
            backgroundQuest.gameObject.SetActive(false);
            questText.gameObject.SetActive(false);
            Instantiate(zombie_1, new Vector2(-7, -2), Quaternion.identity);
            bottleFlag = 1;
        }

        
        if (dialoguesController.fourthDialogueFlag == 1)
        {

        }
    }
}
