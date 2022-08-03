using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    [SerializeField] Transform weapons_array_parent;
    public GameObject[] weapons_array;
    PlayerController playerController;
    int count = 0;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        //count = weapons_array_parent.childCount;
        //weapons_array = new GameObject[count];
    }

    private void Update()
    {
        if (playerController.attackEnable == true) {
            if (Input.GetKeyDown("q"))
            {
                for (int i = 0; i < weapons_array.Length; i++)
                {
                    if (weapons_array[i].activeSelf == true)
                    {
                        weapons_array[i].SetActive(false);

                        if (i == weapons_array.Length - 1)
                        {
                            weapons_array[0].SetActive(true);
                            i = 0;
                            break;
                        }
                        else
                        {
                            weapons_array[i + 1].SetActive(true);
                        }
                        break;
                    }
                }
            }
        }
    }
}
