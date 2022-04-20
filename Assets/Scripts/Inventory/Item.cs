using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    //[SerializeField]

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use(/*Item item*/)
    {
        /*if (item.name == "Slavda Bottle (1)")
        {
            
        }*/
        Debug.Log("You are using " + name);
    }
}
