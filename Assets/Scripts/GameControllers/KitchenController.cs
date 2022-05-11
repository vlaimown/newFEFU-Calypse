using UnityEngine;
using UnityEngine.UI;

public class KitchenController : MonoBehaviour
{
    public static bool indianQuest = false;

    private DialogManager dialogManager;
    private DialoguesController dialoguesController;

    [SerializeField] PlayerController playerController;

    [SerializeField] Image fade;
    [SerializeField] Image blackout;

    [SerializeField] GameObject inventoryUI;

    [SerializeField] GameObject door;
    [SerializeField] float interactiveWithDoor;

    [SerializeField] Image interativeButton;
    [SerializeField] Inventory inventory;

    [SerializeField] Item student_pass;

    private void Awake()
    {
        inventoryUI.SetActive(true);
        playerController = FindObjectOfType<PlayerController>();
        fade.gameObject.SetActive(true);

        HoleController.quest_with_security_finished = true;
        GoToKitchen.to_hole = true;
    }

    private void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
        dialoguesController = FindObjectOfType<DialoguesController>();
        HoleController.quest_with_security_finished = true;
    }

    private void FixedUpdate()
    {

        if (Vector2.Distance(door.transform.position, playerController.hero.position) <= interactiveWithDoor)
        {
            interativeButton.gameObject.SetActive(true);
            if (Input.GetKey("e"))
            {
                blackout.gameObject.SetActive(true);
                //KitchenController.goFromKitchen = true;
            }
        }
        else
        {
            interativeButton.gameObject.SetActive(false);
        }

        if (KitchenController.indianQuest == true)
        {
            Inventory.itemList.Remove(student_pass);
            //inventoryUI.UpdateUI();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(door.transform.position, interactiveWithDoor);
    }
}
