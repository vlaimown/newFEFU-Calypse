using UnityEngine;
using UnityEngine.UI;

public class OutsideGameController : MonoBehaviour
{
    [SerializeField] Image fade;
    [SerializeField] Inventory inventory;

    [SerializeField] DialoguesController dialoguesController;
    [SerializeField] DialogManager dialogManager;
    [SerializeField] PlayerController playerController;

    [SerializeField] Animator anim;
    [SerializeField] GameController gameController;
    [SerializeField] DialogTrigger eleventhDialogue;

    [SerializeField] Item bottle;

    public float distance;

    private void Awake()
    {
        anim.SetBool("ReadyToGo" ,true);
        inventory.windowInventory.SetActive(true);
        fade.gameObject.SetActive(true);

        inventory.itemList.Add(gameController.BJD);
        inventory.itemList.Add(bottle);
        gameController.inventoryUI.UpdateUI();
    }
    private void FixedUpdate()
    {
        if (dialoguesController.eleventhDialogue != null) { 
        distance = Vector2.Distance(dialoguesController.eleventhDialogue.transform.position, playerController.hero.transform.position);
        if (distance <= dialoguesController.eleventhDialogue.radius)
            {
                Debug.Log("dada");
                dialoguesController.dialogueManager.dialogueWindow.SetActive(true);
                dialoguesController.eleventhDialogue.TriggerDialog();
                Destroy(dialoguesController.eleventhDialogue.gameObject);
            }
        }
    }
}
