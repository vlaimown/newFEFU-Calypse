using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject Info;
    public void NewGame()
    {
        SceneManager.LoadScene(1);  
    } 
    public void ExitGame()
    {
        Application.Quit();  
    }

    public void InfoGame()
    {
        Info.SetActive(true);
    }

    public void ReturnMenu()
    {
        Info.SetActive(false);
    }

    public void SurvivalMode()
    {
        SceneManager.LoadScene(6);
    }
}
