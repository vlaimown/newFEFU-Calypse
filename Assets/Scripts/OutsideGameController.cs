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

    private void Awake()
    {
        anim.SetBool("ReadyToGo" ,true);
        inventory.windowInventory.SetActive(true);
        fade.gameObject.SetActive(true);

        playerController.attackEnable = true;
        gameController.inventoryEnable = true;

        playerController.moveToHotelFlag = 1;
        goToHotel.hotelSceneEnable = true;
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

        if (dialogManager.dialogueNumber == 2 && SceneManager.GetActiveScene().buildIndex == 4)
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
            dialoguesController.dialogueManager.dialogueWindow.SetActive(true);
            dialoguesController.twelfthDialogue.TriggerDialog();
        }

        if (dialogManager.dialogueNumber == 3 && SceneManager.GetActiveScene().buildIndex == 4)
        {
            special_attack_button.gameObject.SetActive(false);
            bottle_pointer.gameObject.SetActive(false);
            playerController.speed = playerController.maxspeed;
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
                dialoguesController.thirteenthDialogue.TriggerDialog();
            }
        }
        else
        {
            gameController.F.gameObject.SetActive(false);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(triggerPassQuestPoint.transform.position, triggerPassQuestRadius);
    }
}
