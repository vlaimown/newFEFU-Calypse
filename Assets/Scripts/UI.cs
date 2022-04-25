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
    [SerializeField] InventoryUI inventoryUI;
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
    }

    public void InventoryInvise()
    {
        inventory.windowInventory.SetActive(false);

        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            inventory.itemList.Add(bottle);
            inventory.itemList.Add(BJD);
            inventoryUI.UpdateUI();
        }
    }

    public void GoToKitchenFunction()
    {
        SceneManager.LoadScene(4);
    }
}
