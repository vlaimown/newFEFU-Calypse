using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguesController : MonoBehaviour
{
    //public Dialogue dialogue;
    public DialogManager dialogueManager;
    public DialogTrigger dialogueTrigger;
    public PlayerController playerController;

    public int startFlag;
    public int coun = 0;
    public GameObject Intro;

    [SerializeField] private float gameWillStartIn;

    private void Start()
    {

        startFlag = 0;
        gameWillStartIn = 3f;

        Intro.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (gameWillStartIn > 0)
        {
            gameWillStartIn -= Time.deltaTime;
        }
        if (gameWillStartIn <= 0)
        {
            if (startFlag == 0)
            {
                Intro.SetActive(false);

                dialogueManager.dialogueWindow.SetActive(true);
                if (dialogueManager.dialogueWindow == true)
                {
                    dialogueTrigger.TriggerDialog();
                }
                startFlag = 1;
            }
        }
    }
}
