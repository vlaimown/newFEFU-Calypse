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

    public float distance;

    private void Awake()
    {
        anim.SetBool("ReadyToGo" ,true);
        inventory.windowInventory.SetActive(true);
        fade.gameObject.SetActive(true);

        playerController.attackEnable = true;
        gameController.inventoryEnable = true;
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

        if (dialoguesController.twelfthDialogue != null)
        {
            distance = Vector2.Distance(dialoguesController.twelfthDialogue.transform.position, playerController.hero.transform.position);
            if (distance <= dialoguesController.twelfthDialogue.radius)
            {
                dialoguesController.dialogueManager.dialogueWindow.SetActive(true);
                dialoguesController.twelfthDialogue.TriggerDialog();
                Destroy(dialoguesController.twelfthDialogue.gameObject);
            }
        }
    }
}
