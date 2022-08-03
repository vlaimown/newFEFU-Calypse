using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour 
{
    //public static Inventory instance;
    //[SerializeField] GameObject newGameObject;
    //PlayerController playerController;
    //[SerializeField] GameController gameController;
    //[SerializeField] DialogManager dialogManager;
    //public GameObject pointer_BJD;

    //public static List<Item> itemList = new List<Item>();

    //public delegate void OnItemChanged();
    //public OnItemChanged onItemChangedCallback;

    //Item item;
    //[SerializeField] Item student_pass;

    //public GameObject windowInventory;

    //[SerializeField]InventoryUI inventoryUI;
    ////int j = 0;
    //[SerializeField] int count_in_the_line;

    //public int space;

    //private void Start()
    //{
    //    instance = this;
    //    playerController = FindObjectOfType<PlayerController>();
    //    gameController = FindObjectOfType<GameController>();

    //    inventoryUI = FindObjectOfType<InventoryUI>();
    //    //j = 0;
    //}

    //private void Update()
    //{
    //    if (SceneManager.GetActiveScene().buildIndex == 2) 
    //    {
    //        if (windowInventory.gameObject.activeSelf == false)
    //        {
    //            if (Input.GetKeyUp("i") && gameController.inventoryEnable == true)
    //            {
    //                windowInventory.gameObject.SetActive(true);
    //                playerController.attackEnable = false;

    //                if (dialogManager.dialogueNumber == 8)
    //                {
    //                    gameController.interactive_with_inventory_button.gameObject.SetActive(false);
    //                    pointer_BJD.gameObject.SetActive(true);
    //                }
    //            }
    //        }
    //        else if (windowInventory.gameObject.activeSelf == true)
    //        {
    //            playerController.attackEnable = false;
    //            if (Input.GetKeyUp("i"))
    //            {
    //                windowInventory.gameObject.SetActive(false);
    //                playerController.attackEnable = true;

    //                if (dialogManager.dialogueNumber == 8)
    //                {
    //                    gameController.interactive_with_inventory_button.gameObject.SetActive(true);
    //                    pointer_BJD.gameObject.SetActive(false);
    //                }
    //            }
    //        }
    //    }

    //    if (SceneManager.GetActiveScene().buildIndex != 2)
    //    {
    //        if (windowInventory.gameObject.activeSelf == false)
    //        {
    //            if (Input.GetKeyUp("i"))
    //            {
    //                windowInventory.gameObject.SetActive(true);
    //                playerController.attackEnable = false;
    //            }
    //        }
    //        else if (windowInventory.gameObject.activeSelf == true)
    //        {
    //            playerController.attackEnable = false;
    //            if (Input.GetKeyUp("i"))
    //            {
    //                windowInventory.gameObject.SetActive(false);
    //                playerController.attackEnable = true;
    //                //j = 0;
    //            }
    //        }
    //    }



    //   /* if (windowInventory.gameObject.activeSelf == true)
    //    {
    //        if (Input.GetKey("d"))
    //        {
    //            j++;
    //            inventoryUI.slots[0].GetComponent<Image>().color = Color.green;
    //        }

    //        else if (Input.GetKey("s"))
    //        {
    //            j += count_in_the_line;
    //            inventoryUI.slots[0].GetComponent<Image>().color = Color.green;
    //        }
    //    }*/

    //    if (KitchenController.indianQuest == true)
    //    {
    //        itemList.Remove(student_pass);
    //    }
    //}

    //public void Add (Item item)
    //{
    //    if (!item.isDefaultItem)
    //    {
    //        if (itemList.Count < space)
    //        {
    //            itemList.Add(item);
    //        }

    //        if (onItemChangedCallback != null)
    //        {
    //            onItemChangedCallback.Invoke();
    //        }
    //    }
    //}

    //public void Remove(Item item)
    //{
    //    SpawnItem(item);
    //    itemList.Remove(item);

    //    if (item.name == "Slavda Bottle (1)")
    //    {
    //        gameController.bottle.SetActive(false);
    //    }

    //    if (item.name == "ÁÆÄ")
    //    {
    //        gameController.BJD_notebook.SetActive(false);
    //    }

    //    if (onItemChangedCallback != null)
    //    {
    //        onItemChangedCallback.Invoke();
    //    }
    //}

    //public void SpawnItem(Item item)
    //{
    //    newGameObject = Resources.Load(item.name) as GameObject;
    //    Instantiate(newGameObject, new Vector2(playerController.hero.transform.position.x + 1, playerController.hero.transform.position.y), Quaternion.identity);
    //}
}
