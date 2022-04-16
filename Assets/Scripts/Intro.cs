using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public int firstCutscene;
    public PlayerController player;
    public Inventory windowINV;

    //public Queue<Image> opening;
    //public GameObject introCanvas;
    //public Image[] introImgs;
    //Image image;
    public int flagIntro = 0;
    public GameObject windowIntro;
    public Image[] opening;
    public Transform openingParent;
    int i = 0;
    [SerializeField] int N = 0;

    public float gameWillStartIn;
    //public int counter = 0;

    private void Start()
    {
        Time.timeScale = 0;
        i = 0;
        firstCutscene = 0;
        //opening = new Queue<Image>();
        //counter = 0;
        //opening = openingParent.GetComponentsInChildren<Image>();
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
            windowINV.windowInventory.SetActive(false);
            windowIntro.gameObject.SetActive(false);
            gameWillStartIn = 0.65f;
            flagIntro = 1;
            firstCutscene = 1;
            player.waittime = 2.5f;
            Time.timeScale = 1;

            return;
        }
    }

    /*public void StartDialogue()
    {
        opening.Clear();

        foreach (Image img in introImgs)
        {
            opening.Enqueue(img);
        }

        NextImage();
    }

    public void NextImage()
    {
        counter++;

        if (opening.Count == 0)
        {
            EndIntro();
            return;
        }

        Image image = opening.Dequeue();
        image.gameObject.SetActive(true);
    }

    public void EndIntro()
    {
        introCanvas.SetActive(false);
        counter = 0;
    }*/
}
