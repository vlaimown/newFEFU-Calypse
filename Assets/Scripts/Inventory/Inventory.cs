using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour 
{
    public static Inventory instance;

    public List<Item> itemList = new List<Item>();

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public GameObject windowInventory;
    public bool inventoryOpened = false;

    public int space;

    private void Awake()
    {
        instance = this;
        windowInventory.SetActive(true);
    }

    private void Update()
    {
        if (inventoryOpened == false) 
        { 
            if (Input.GetKeyUp("i"))
            {
                windowInventory.SetActive(true);
                inventoryOpened = true;
            }
        }

        else if (inventoryOpened == true)
        {
            if (Input.GetKeyUp("i"))
            {
                windowInventory.SetActive(false);
                inventoryOpened = false;
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
        itemList.Remove(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
