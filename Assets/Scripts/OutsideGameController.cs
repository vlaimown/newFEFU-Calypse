using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OutsideGameController : MonoBehaviour
{
    [SerializeField] Image fade;
    [SerializeField] Inventory inventory;
    [SerializeField] InventoryUI inventoryUI;

    [SerializeField] DialoguesController dialoguesController;
    [SerializeField] DialogManager dialogManager;
    [SerializeField] PlayerController playerController;

    [SerializeField] Animator anim;
    [SerializeField] GameController gameController;
    [SerializeField] DialogTrigger eleventhDialogue;

    [SerializeField] Image special_attack_button;
    //[SerializeField] Image interactive_button;

    [SerializeField] GameObject bottle_pointer;
    [SerializeField] GameObject triggerPassQuestPoint;
    [SerializeField] float triggerPassQuestRadius;

    [SerializeField] Item student_pass;
    public float distance;

    public int skillsFlag = 0;
    [SerializeField] GameObject water;

    [SerializeField] GoToHotel goToHotel;

    [SerializeField]
    Image backgroundMainQuest;

    [SerializeField] float waittimeoutside;
    [SerializeField] bool waittimeflag;

    [SerializeField] Image bottleSkillIcon;

    [SerializeField]
    Text mainQuest,
         neMainQuest,
         sixQuest,
         seventhQuest;
         //mainQuestText;

    private void Awake()
    {
        anim.SetBool("ReadyToGo" ,true);
        inventory.windowInventory.SetActive(true);
        fade.gameObject.SetActive(true);

        playerController.attackEnable = true;
        gameController.inventoryEnable = true;

        playerController.moveToHotelFlag = 1;
        goToHotel.hotelSceneEnable = true;

        backgroundMainQuest.gameObject.SetActive(true);
        mainQuest.gameObject.SetActive(true);

        neMainQuest.gameObject.SetActive(true);
        sixQuest.gameObject.SetActive(true);
        gameController.CATScounter.gameObject.SetActive(true);
        gameController.CATScounter.text = $"(1/3)";

        waittimeoutside = 0;
        waittimeflag = false;
    }
    private void FixedUpdate()
    {
        if (dialoguesController.eleventhDialogue != null) { 
        distance = Vector2.Distance(dialoguesController.eleventhDialogue.transform.position, playerController.hero.transform.position);
        if (distance <= dialoguesController.eleventhDialogue.radius)
            {
                dialoguesController.dialogueManager.dialogueWindow.SetActive(true);
                dialoguesController.eleventhDialogue.TriggerDialog();
                Destroy(dialoguesController.eleventhDialogue.gameObject);
            }
        }

        if (dialogManager.dialogueNumber == 2 && SceneManager.GetActiveScene().buildIndex == 4 && waittimeoutside == 0)
        {
            skillsFlag = 1;

            if (inventory.windowInventory.gameObject.activeSelf == false)
            {
                gameController.interactive_with_inventory_button.gameObject.SetActive(true);
            }
            if ((inventory.windowInventory.gameObject.activeSelf == true) || (gameController.bottle.activeSelf == true))
            {
                gameController.interactive_with_inventory_button.gameObject.SetActive(false);
            }


            if (gameController.bottle.activeSelf == true) 
            { 
                special_attack_button.gameObject.SetActive(true);
            }
            else
            {
                special_attack_button.gameObject.SetActive(false);
            }


            playerController.speed = 0;
            playerController.animator.SetBool("ReadyToGo", false);
            if (inventory.windowInventory.gameObject.activeSelf == true)
            {
                bottle_pointer.gameObject.SetActive(true);
            }
            if (inventory.windowInventory.gameObject.activeSelf == false)
            {
                bottle_pointer.gameObject.SetActive(false);
            }
        }

        if (Input.GetKey("z") && gameController.bottle.activeSelf == true && dialogManager.dialogueNumber == 2 && skillsFlag == 1)
        {
            waittimeoutside = 1f;
            bottleSkillIcon.gameObject.SetActive(true);
            playerController.avaible_skills = true;
            //dialoguesController.dialogueManager.dialogueWindow.SetActive(true);
            special_attack_button.gameObject.SetActive(false);
            playerController.attackEnable = true;
            inventory.windowInventory.gameObject.SetActive(false);
            //dialoguesController.twelfthDialogue.TriggerDialog();

            bottle_pointer.gameObject.SetActive(false);
            waittimeflag = true;
        }

        if (waittimeoutside > 0)
        {
            waittimeoutside -= Time.deltaTime;
        }
        else if (waittimeoutside <= 0 && skillsFlag == 1 && dialogManager.dialogueNumber == 2 && waittimeflag == true)
        {
            dialoguesController.dialogueManager.dialogueWindow.SetActive(true);
            dialoguesController.twelfthDialogue.TriggerDialog();
        }

        if (dialogManager.dialogueNumber == 3 && SceneManager.GetActiveScene().buildIndex == 4)
        {
            bottle_pointer.gameObject.SetActive(false);
            playerController.speed = playerController.maxspeed;
            playerController.animator.SetBool("ReadyToGo", true);
        }

        if (dialogManager.dialogueNumber == 3 && SceneManager.GetActiveScene().buildIndex == 4 
            && Vector2.Distance(triggerPassQuestPoint.transform.position, playerController.hero.transform.position) <= triggerPassQuestRadius)
        {
            gameController.F.gameObject.SetActive(true);
            if (Input.GetKey("f"))
            {
                inventory.itemList.Add(student_pass);
                inventoryUI.UpdateUI();
                dialogManager.dialogueWindow.SetActive(true);
                sixQuest.gameObject.SetActive(false);
                dialoguesController.thirteenthDialogue.TriggerDialog();
            }
        }
        else
        {
            gameController.F.gameObject.SetActive(false);
        }

        if (dialogManager.dialogueNumber == 4 && SceneManager.GetActiveScene().buildIndex == 4)
        {
            seventhQuest.gameObject.SetActive(true);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(triggerPassQuestPoint.transform.position, triggerPassQuestRadius);
    }
}
