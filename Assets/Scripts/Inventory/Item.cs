using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    //[SerializeField] GameController gameController;

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    /*public virtual void Use(Item item)
    {
        if (item.name == "Slavda Bottle (1)")
        {
            gameController.bottle.SetActive(true);
        }
        Debug.Log("You are using " + name);
    }*/
}
