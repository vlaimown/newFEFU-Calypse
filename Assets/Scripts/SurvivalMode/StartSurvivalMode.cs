using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSurvivalMode : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject survivalModePreview;

    public void SurvivalModeStart()
    {
        Time.timeScale = 1;
        playerController.speed = playerController.maxspeed;
        survivalModePreview.gameObject.SetActive(false);
    }
}
