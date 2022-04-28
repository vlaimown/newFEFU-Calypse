using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] Image read_next;
    [SerializeField] Canvas helloWorldCanvas;
    [SerializeField] PlayerController playerController;

    [SerializeField] Inventory inventory;
    [SerializeField] Image fade;

    [SerializeField] Item bottle;
    [SerializeField] Item BJD;
    [SerializeField] Item student_pass;
    [SerializeField] InventoryUI inventoryUI;

    [SerializeField] GoToKitchen goToKitchen;
    [SerializeField] GameObject survivalModePreview;
    [SerializeField] OutsideGameController outsideGameController;

    [SerializeField] DialogManager dialogManager;
    [SerializeField] DialoguesController dialoguesController;

    [SerializeField] SurvivalMode survivalMode;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        dialogManager = FindObjectOfType<DialogManager>();
        dialoguesController = FindObjectOfType<DialoguesController>();
    }

    public void CloseReadNext()
    {
        read_next.gameObject.SetActive(false);
        helloWorldCanvas.gameObject.SetActive(false);
        gameController.dialoguesController.ninthDialogue.TriggerDialog();
        gameController.dialogManager.dialogueWindow.SetActive(true);
        playerController.attackEnable = true;
        gameController.HelloWorldCat.gameObject.SetActive(false);
        gameController.catsCount = 1;
        gameController.CATScounter.text = $"({gameController.catsCount}/3)";
    }

    public void Fade()
    {
        fade.gameObject.SetActive(false);
        if (SceneManager.GetActiveScene().buildIndex == 3) {
            if (HoleController.quest_with_security_finished == false)
            {
                if (dialogManager.dialogueNumber == 1 && PlayerController.pass_flag == true && SceneManager.GetActiveScene().buildIndex == 3 && KitchenController.indianQuest == false)
                {
                    dialogManager.dialogueWindow.SetActive(true);
                    dialoguesController.fourteenthDialogue.TriggerDialog();
                }
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            if (KitchenController.indianQuest == false) 
            {
                dialogManager.dialogueWindow.SetActive(true);
                dialoguesController.sixteenthDialogue.TriggerDialog();
                KitchenController.indianQuest = true;
            }
        }
    }

    public void InventoryInvise()
    {
        inventory.windowInventory.SetActive(false);

        if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            inventory.itemList.Add(bottle);
            inventory.itemList.Add(BJD);
            if (PlayerController.pass_flag == true)
            {
                inventory.itemList.Add(student_pass);
            }
            if (KitchenController.indianQuest == true)
            {
                inventory.itemList.Remove(student_pass);
            }
            inventoryUI.UpdateUI();
        }
    }

    public void GoTo()
    {
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            if (goToKitchen.door == 2)
            {
                SceneManager.LoadScene("KitchenScene");
            }
            if (goToKitchen.door == 1)
            {
                SceneManager.LoadScene("HostelScene");
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            SceneManager.LoadScene(7);
        }

        if (SceneManager.GetActiveScene().buildIndex == 3 && HoleController.goInFlag == false)
        {
            SceneManager.LoadScene("OutsideScene");
        }

        else if (SceneManager.GetActiveScene().buildIndex == 3 && HoleController.goInFlag == true)
        {
            SceneManager.LoadScene(7);
        }
    }

    public void SurvivalMode()
    {
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            Time.timeScale = 0;
            survivalModePreview.SetActive(true);
            survivalMode.spawnEnemyFlag = true;
        }
    }
}
