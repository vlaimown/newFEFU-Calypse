using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] GameController gameController;
    Item item;
    public Button removeButton;
    public Image icon;
    [SerializeField] Animator anim;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled =  false;
        removeButton.interactable = false;
    }

    public void onRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            //item.Use(item);
            if (item.name == "Slavda Bottle (1)")
            {
                gameController.BJD_notebook.SetActive(false);
                gameController.bottle.SetActive(true);
                anim.SetBool("BottleAttack", true);
                anim.SetBool("BJDAttack", false);
            }

            if (item.name == "ÁÆÄ")
            {
                gameController.bottle.SetActive(false);
                gameController.BJD_notebook.SetActive(true);
                anim.SetBool("BottleAttack", false);
                anim.SetBool("BJDAttack", true);

                if (gameController.dialogManager.dialogueNumber == 8)
                {
                    gameController.dialogManager.dialogueWindow.SetActive(true);
                    gameController.dialoguesController.eighthDialogue.TriggerDialog();
                }
            }
        }
    }
}
