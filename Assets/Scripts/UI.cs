using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] Image read_next;
    [SerializeField] Canvas helloWorldCanvas;
    [SerializeField] PlayerController playerController;

    [SerializeField] Inventory inventory;
    [SerializeField] Image fade;
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
    }
}
