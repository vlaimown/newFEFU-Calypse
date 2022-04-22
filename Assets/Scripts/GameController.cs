using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject bottle;
    public GameObject BJD_notebook;
    public Item BJD;
    private bool BJD_flag = false;

    public InventoryUI inventoryUI;
    [SerializeField] Image read_next;
    private bool read_next_flag = false;

    [SerializeField] Zombie zombie;
    [SerializeField] GameObject arrow_pointer;
    [SerializeField] Image WASD_animation;

    public Image F;

    public PlayerController playerController;
    public DialoguesController dialoguesController;
    public DialogManager dialogManager;
    public Inventory inventory;

    public Animator anim;
    private int bottleFlag = 0;
    public bool inventoryEnable = false;

    public Text firstQuest,
                secondQuest,
                thirdQuest,
                fourthQuest,
                fifthQuest;

    public Text CATScounter;
    public int catsCount = 0;
    public GameObject HelloWorldCat;

    [SerializeField] GoToHotel hotelScene;

    public GameObject zombie_1;
    public GameObject newZombie = null;

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

            arrow_pointer.SetActive(true);
            WASD_animation.gameObject.SetActive(true);
        }

        if (dialoguesController.fourthDialogueFlag == 1)
        {
            secondQuest.gameObject.SetActive(false);
            backgroundQuest.gameObject.SetActive(false);
            questText.gameObject.SetActive(false);

            arrow_pointer.SetActive(false);
            WASD_animation.gameObject.SetActive(false);

            if (dialogManager.dialogueNumber == 5)
            {
                thirdQuest.gameObject.SetActive(true);
                backgroundQuest.gameObject.SetActive(true);
                questText.gameObject.SetActive(true);
            }
        }

        if (inventory.itemList.Exists(item => item.name == "Slavda Bottle (1)") && bottleFlag == 0)
        {
            dialoguesController.fourthDialogueFlag = 2;
            thirdQuest.gameObject.SetActive(false);
            backgroundQuest.gameObject.SetActive(false);
            questText.gameObject.SetActive(false);
            Instantiate(zombie_1, new Vector2(-8, -2), Quaternion.identity);
            newZombie = GameObject.Find("Zombie(Clone)");

            bottleFlag = 1;
            bottle.SetActive(true);
        }

        if (newZombie != null)
        {
            if (dialogManager.dialogueNumber == 5 && Vector2.Distance(newZombie.transform.position, playerController.hero.position) <= 5.7f)
            {
                dialoguesController.fifthDialogue.TriggerDialog();
                dialogManager.dialogueWindow.SetActive(true);
            }
        }

        if (dialogManager.dialogueNumber == 6)
        {
            fourthQuest.gameObject.SetActive(true);
            backgroundQuest.gameObject.SetActive(true);
            questText.gameObject.SetActive(true);
        }

        if (newZombie == null && dialogManager.dialogueNumber == 6)
        {
            fourthQuest.gameObject.SetActive(false);
            backgroundQuest.gameObject.SetActive(false);
            questText.gameObject.SetActive(false);
            dialoguesController.sixDialogue.TriggerDialog();
            dialogManager.dialogueWindow.SetActive(true);
        }

        if (dialogManager.dialogueNumber == 7)
        {
            fifthQuest.gameObject.SetActive(true);
            CATScounter.gameObject.SetActive(true);
            CATScounter.text = $"({catsCount}/3)";
            backgroundQuest.gameObject.SetActive(true);
            questText.gameObject.SetActive(true);
        }

        if (dialogManager.dialogueNumber == 7 && Vector2.Distance(dialoguesController.seventhDialogue.transform.position, playerController.hero.position) < dialoguesController.seventhDialogue.radius)
        {
            dialogManager.dialogueWindow.SetActive(true);
            dialoguesController.seventhDialogue.TriggerDialog();
            Destroy(dialoguesController.seventhDialogue.gameObject);
            BJD_flag = true;
        }

        if (dialogManager.dialogueNumber == 8 && BJD_flag == true)
        {
            BJD_flag = false;
            inventoryEnable = true;
            inventory.itemList.Add(BJD);
            inventoryUI.UpdateUI();
        }

        if (dialogManager.dialogueNumber == 9 && read_next_flag == false)
        {
            read_next_flag = true;
            inventory.windowInventory.SetActive(false);
            read_next.gameObject.SetActive(true);
            hotelScene.hotelSceneEnable = true;
        }
    }

    /*IEnumerator HelloWorldBubble()
    {
        HelloWorldText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        HelloWorldText.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        StartCoroutine(HelloWorldBubble());
    }*/
}
