using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SurvivalModeFuncs : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject survivalModePreview;
    [SerializeField] Image waveCounterImg;
    [SerializeField] Text waveCounterTxt;

    [SerializeField] SurvivalMode survivalMode;

    public void SurvivalModeStart()
    {
        Time.timeScale = 1;
        playerController.speed = playerController.maxspeed;
        survivalModePreview.gameObject.SetActive(false);

        waveCounterTxt.text = "1";
        waveCounterImg.gameObject.SetActive(true);
        survivalMode.spawnEnemyFlag = true;
    }

    public void ReturnInToGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void ReturnInToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
