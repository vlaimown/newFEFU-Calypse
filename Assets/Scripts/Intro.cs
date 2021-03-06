using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public int firstCutscene;
    public PlayerController player;

    public int flagIntro = 0;
    public GameObject windowIntro;
    public Image[] opening;
    public Transform openingParent;
    int i = 0;
    [SerializeField] int N = 0;

    public float gameWillStartIn;

    private void Start()
    {
        i = 0;
        firstCutscene = 0;
        opening[0].gameObject.SetActive(true);
    }

    public void NextImg()
    {
        if (i < N && i != (N-1))
        {
            i++;
            opening[i].gameObject.SetActive(true);
        }
        else if (i == (N - 1))
        {
            SceneManager.LoadScene(2);

            return;
        }
    }
}
