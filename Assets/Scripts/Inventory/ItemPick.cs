using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPick : MonoBehaviour
{
    public Inventory inventory;
    public Item item;

    [SerializeField] GameController gameController;

    public PlayerController character;
    [SerializeField] float radius;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        character = FindObjectOfType<PlayerController>();
        gameController = FindObjectOfType<GameController>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.F.gameObject.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gameController.F.gameObject.SetActive(false);
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
    }
}
