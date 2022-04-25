using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] PlayerController playerController;
    Item item;
    public Button removeButton;
    public Image icon;
    [SerializeField] Animator anim;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        //anim = FindObjectOfType<Animator>();
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
                playerController.BJD_weapon.SetActive(false);
                playerController.bottle_weapon.SetActive(true);
                anim.SetBool("BottleAttack", true);
                anim.SetBool("BJDAttack", false);
            }

            if (item.name == "ÁÆÄ")
            {
                playerController.bottle_weapon.SetActive(false);
                playerController.BJD_weapon.SetActive(true);
                anim.SetBool("BottleAttack", false);
                anim.SetBool("BJDAttack", true);

                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    if (gameController.dialogManager.dialogueNumber == 8)
                    {
                        gameController.dialogManager.dialogueWindow.SetActive(true);
                        gameController.dialoguesController.eighthDialogue.TriggerDialog();
                    }
                }
            }
        }
    }
}
