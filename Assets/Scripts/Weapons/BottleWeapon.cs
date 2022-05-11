using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleWeapon : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] GameObject water;
    public int water_count = 0;

    public float skillCoolDownTime;
    public float maxSkillCoolDownTime;
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (playerController.avaible_skills == true)
        {
            if (skillCoolDownTime <= 0)
            {
                if (Input.GetKey("z") && playerController.bottle_weapon.activeSelf == true && water_count == 0)
                {
                    water_count = 1;

                    if (playerController.facingRight == true)
                    {
                        Instantiate(water, new Vector2(playerController.hero.transform.position.x + 3.5f, playerController.hero.position.y), Quaternion.identity);
                    }
                    else if (playerController.facingRight == false)
                    {
                        Instantiate(water, new Vector2(playerController.hero.transform.position.x + 3.5f * -1f, playerController.hero.position.y), Quaternion.identity);
                    }
                }
            }
        }
    }
}
