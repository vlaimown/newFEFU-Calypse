using UnityEngine;
using UnityEngine.UI;

public class SkillsUI : MonoBehaviour
{
    #region Bottle_First_Skill_Icon
    public Image notAvaibleBottle;
    public Image avaibleBottle;
    public Image coolDownBottle;
    #endregion

    #region BJD_First_Skill_Icon
    public Image notAvaibleBJD;
    public Image avaibleBJD;
    public Image coolDownBJD;
    #endregion

    [SerializeField] BottleWeapon bottleWeapon;
    [SerializeField] BJDweapon BJDweapon;
    PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (playerController.avaible_skills == true)
        {
            if (bottleWeapon.skillCoolDownTime > 0)
            {
                notAvaibleBottle.gameObject.SetActive(true);
                bottleWeapon.skillCoolDownTime -= Time.fixedDeltaTime;
                notAvaibleBottle.fillAmount = bottleWeapon.skillCoolDownTime / bottleWeapon.maxSkillCoolDownTime;
            }

            if (bottleWeapon.skillCoolDownTime <= 0)
            {
                notAvaibleBottle.gameObject.SetActive(false);
                avaibleBottle.gameObject.SetActive(true);

                if (bottleWeapon.water_count == 1)
                {
                    avaibleBottle.gameObject.SetActive(false);
                }
            }


            if (BJDweapon.skillCoolDownTime_BJD > 0)
            {
                notAvaibleBJD.gameObject.SetActive(true);
                BJDweapon.skillCoolDownTime_BJD -= Time.fixedDeltaTime;
                notAvaibleBJD.fillAmount = BJDweapon.skillCoolDownTime_BJD / BJDweapon.maxSkillCoolDownTime_BJD;
            }

            if (BJDweapon.skillCoolDownTime_BJD <= 0)
            {
                notAvaibleBJD.gameObject.SetActive(false);
                avaibleBJD.gameObject.SetActive(true);
            }
        }
    }
}