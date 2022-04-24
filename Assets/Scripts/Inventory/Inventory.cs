using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour 
{
    public static Inventory instance;
    [SerializeField] GameObject newGameObject;
    PlayerController playerController;
    [SerializeField] GameController gameController;
    [SerializeField] DialogManager dialogManager;
    public GameObject pointer_BJD;

    public List<Item> itemList = new List<Item>();

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    Item item;

    public GameObject windowInventory;

    public int space;

    private void Awake()
    {
        instance = this;
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (windowInventory.gameObject.activeSelf == false) 
        { 
            if (Input.GetKeyUp("i") && gameController.inventoryEnable == true)
            {
                windowInventory.gameObject.SetActive(true);
                playerController.attackEnable = false;
                
                if (dialogManager.dialogueNumber == 8)
                {
                    gameController.interactive_with_inventory_button.gameObject.SetActive(false);
                    pointer_BJD.gameObject.SetActive(true);
                }
            }
        }

        else if (windowInventory.gameObject.activeSelf == true)
        {
            playerController.attackEnable = false;
            if (Input.GetKeyUp("i"))
            {
                windowInventory.gameObject.SetActive(false);
                playerController.attackEnable = true;

                if (dialogManager.dialogueNumber == 8)
                {
                    gameController.interactive_with_inventory_button.gameObject.SetActive(true);
                    pointer_BJD.gameObject.SetActive(false);
                }
            }
        }
    }

    public void Add (Item item)
    {
        if (!item.isDefaultItem)
        {
            if (itemList.Count < space)
            {
                itemList.Add(item);
            }

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }
    }

    public void Remove(Item item)
    {
        SpawnItem(item);
        itemList.Remove(item);

        if (item.name == "Slavda Bottle (1)")
        {
            gameController.bottle.SetActive(false);
        }

        if (item.name == "ÁÆÄ")
        {
            gameController.BJD_notebook.SetActive(false);
        }

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public void SpawnItem(Item item)
    {
        newGameObject = Resources.Load(item.name) as GameObject;
        Instantiate(newGameObject, new Vector2(playerController.hero.transform.position.x + 1, playerController.hero.transform.position.y), Quaternion.identity);
    }
}
