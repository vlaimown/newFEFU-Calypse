using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPick : MonoBehaviour
{
    public Inventory inventory;
    public Item item;

    public PlayerController character;
    public Image IconButton;
    [SerializeField] float radius;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IconButton.gameObject.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IconButton.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(character.hero.transform.position, transform.position) <= radius)
        {
            if (Input.GetKey("f"))
            {
                if (inventory.itemList.Count < inventory.space)
                {
                    Destroy(gameObject);
                    Inventory.instance.Add(item);
                }
                else
                {
                    Debug.Log("Инвентарь переполнен");
                }
            }
        }
        /*else
        {
            IconButton.gameObject.SetActive(false);
        }*/
    }
}
