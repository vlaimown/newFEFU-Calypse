using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField] Image god_paper_cutscene;
    [SerializeField] Image background_god_paper_cutscene;
    public float gameWillStartIn;
    [SerializeField] Image fade;

    [SerializeField] Image attack_button;
    public Image interactive_with_inventory_button;

    private void Awake()
    {
        inventory.windowInventory.SetActive(true);
    }

    private void Start()
    {
        gameWillStartIn = 3.25f;
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            playerController.speed = 0;
            fade.gameObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (gameWillStartIn > 0)
            {
                gameWillStartIn -= Time.fixedDeltaTime;
                if (gameWillStartIn < 2.5f && dialoguesController.PrayFlag == 0)
                {
                    dialoguesController.dialogueManager.dialogueWindow.SetActive(true);
                    dialoguesController.firstDialogue.TriggerDialog();
                    dialoguesController.PrayFlag = 1;
                }
                else if (dialoguesController.PrayFlag == 1 && gameWillStartIn < 1.75f)
                {
                    god_paper_cutscene.gameObject.SetActive(true);
                    background_god_paper_cutscene.gameObject.SetActive(true);
                }
            }
            else if (gameWillStartIn < 0 && dialoguesController.PrayFlag == 1)
            {
                god_paper_cutscene.gameObject.SetActive(false);
                background_god_paper_cutscene.gameObject.SetActive(false);
                dialogManager.dialogueWindow.SetActive(true);
                dialoguesController.secondDialogue.TriggerDialog();
                dialoguesController.PrayFlag = 2;
            }

            if (dialogManager.dialogueNumber == 3 && gameWillStartIn < 0 && dialoguesController.PrayFlag == 2)
            {
                firstQuest.gameObject.SetActive(true);
                backgroundQuest.gameObject.SetActive(true);
                questText.gameObject.SetActive(true);
            }

            if (dialogManager.dialogueNumber == 4 && dialoguesController.fourthDialogueFlag != 1)
            {
                firstQuest.gameObject.SetActive(false);

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
                playerController.attackEnable = true;
                dialoguesController.fourthDialogueFlag = 2;
                thirdQuest.gameObject.SetActive(false);
                backgroundQuest.gameObject.SetActive(false);
                questText.gameObject.SetActive(false);
                Instantiate(zombie_1, new Vector2(-8, -2), Quaternion.identity);
                newZombie = GameObject.Find("Zombie(Clone)");
                anim.SetBool("BottleAttack", true);

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

                attack_button.gameObject.SetActive(true);
            }

            if (newZombie == null && dialogManager.dialogueNumber == 6)
            {
                attack_button.gameObject.SetActive(false);

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

                interactive_with_inventory_button.gameObject.SetActive(true);
            }

            if (dialogManager.dialogueNumber == 9 && read_next_flag == false)
            {
                read_next_flag = true;
                inventory.pointer_BJD.SetActive(false);
                read_next.gameObject.SetActive(true);
                hotelScene.hotelSceneEnable = true;

                inventory.windowInventory.gameObject.SetActive(false);
                playerController.attackEnable = true;
            }

            if (SceneManager.GetActiveScene().buildIndex == 4 && dialogManager.dialogueNumber == 1)
            {
                // будет 11
                dialogManager.dialogueWindow.SetActive(true);
                dialoguesController.eleventhDialogue.TriggerDialog();
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
}
