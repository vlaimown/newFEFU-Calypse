using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour 
{
    public static Inventory instance;
    //public InventorySlot inventorySlot;
    [SerializeField] GameObject newGameObject;
    PlayerController playerController;
    [SerializeField] GameController gameController;

    public List<Item> itemList = new List<Item>();

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    Item item;

    public GameObject windowInventory;
    public bool inventoryOpened = false;

    public int space;

    private void Awake()
    {
        instance = this;
        windowInventory.SetActive(true);
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (inventoryOpened == false) 
        { 
            if (Input.GetKeyUp("i") && gameController.inventoryEnable == true)
            {
                windowInventory.SetActive(true);
                inventoryOpened = true;
            }
        }

        else if (inventoryOpened == true)
        {
            playerController.attackEnable = false;
            if (Input.GetKeyUp("i"))
            {
                windowInventory.SetActive(false);
                inventoryOpened = false;
                playerController.attackEnable = true;
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

                /*if (item.name == "Slavda Bottle (1)" || item.name == "Slavda Bottle (1)(Clone)")
                {
                    gameController.bottle.SetActive(true);
                }*/
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
