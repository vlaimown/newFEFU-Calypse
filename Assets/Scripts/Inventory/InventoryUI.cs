using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    public InventorySlot[] slots;

    [SerializeField] private Inventory inventory;

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        //inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < Inventory.itemList.Count)
            {
                slots[i].AddItem(Inventory.itemList[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

    }
}
