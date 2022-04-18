using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
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
        SceneManager.LoadScene(2);
    }

    public static void ReturnMenu()
    {
        SceneManager.LoadScene(0);
         
    }

    

}
