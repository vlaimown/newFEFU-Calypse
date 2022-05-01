using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToKitchen : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] Image E;
    [SerializeField] Transform go_to_kitchen_point;
    [SerializeField] float go_to_kitchen_zone;

    [SerializeField] Transform go_to_hole_point;
    [SerializeField] float go_to_hole_zone;

    [SerializeField] Image blackout;

    [SerializeField] Inventory inventory;
    [SerializeField] Image fade;
    public int door;

    public static bool to_hole = false;

    private void Awake()
    {
        if (GoToKitchen.to_hole == true)
        {
            playerController.hero.transform.position = new Vector2(16.4f, -1.8f);
            GoToKitchen.to_hole = false;
        }
        inventory.windowInventory.SetActive(true);
        fade.gameObject.SetActive(true);

        playerController.attackEnable = true;
    }

    private void Start()
    {
        playerController.speed = playerController.maxspeed * 1.5f;
    }

    void Update()
    {
        to_hole = true;
        if (Vector2.Distance(playerController.hero.transform.position, go_to_kitchen_point.transform.position) <= go_to_kitchen_zone)
        {
            E.gameObject.SetActive(true);
            if (Input.GetKey("e"))
            {
                door = 2;
                blackout.gameObject.SetActive(true);
            }
        }

        else if (Vector2.Distance(playerController.hero.transform.position, go_to_hole_point.transform.position) <= go_to_hole_zone)
        {
            E.gameObject.SetActive(true);
            if (Input.GetKey("e"))
            {
                door = 1;
                blackout.gameObject.SetActive(true);
            }
        }

        else
        {
            E.gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(go_to_kitchen_point.position, go_to_kitchen_zone);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(go_to_hole_point.position, go_to_hole_zone);
    }
}
