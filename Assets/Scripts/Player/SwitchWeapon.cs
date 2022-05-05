using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] weapons_array;

    private void Update()
    {
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
