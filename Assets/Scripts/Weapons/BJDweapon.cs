using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BJDweapon : MonoBehaviour
{
    PlayerController playerController;

    public bool act = false;

    public GameObject BJD;

    public float skillCoolDownTime_BJD;
    public float maxSkillCoolDownTime_BJD;
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    void Update()
    {

        if (playerController.avaible_skills == true)
        {
            if (skillCoolDownTime_BJD <= 0)
            {
                if (Input.GetKey("z") && playerController.BJD_weapon.activeSelf == true && act == false)
                {
                    if (playerController.facingRight == true)
                    {
                        Instantiate(BJD, new Vector2(playerController.hero.transform.position.x + 1f, playerController.hero.position.y), Quaternion.identity);
                    }
                    else if (playerController.facingRight == false)
                    {
                        Instantiate(BJD, new Vector2(playerController.hero.transform.position.x + 1f * -1f, playerController.hero.position.y), Quaternion.identity);
                    }
                    playerController.BJD_weapon.SetActive(false);
                    act = true;
                }
            }
        }
    }
}
