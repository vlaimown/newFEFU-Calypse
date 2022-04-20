using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguesController : MonoBehaviour
{
    public Animator anim;

    public Image buttonF;

    public DialogManager dialogueManager;
    public DialogTrigger dialogueTrigger;
    public PlayerController playerController;

    public DialogTrigger thirdDialogue,
                         fourthDialogue,
                         fifthDialogue,
                         sixDialogue,
                         seventhDialogue;

    public int fourthDialogueFlag = 0;
    public float radius;

    public int startFlag;
    public int coun = 0;
    public GameObject Intro;

    public Intro gameWillStart;

    private void Start()
    {
        startFlag = 0;

        Intro.SetActive(true);
    }

    private void FixedUpdate()
    {

        if (gameWillStart.gameWillStartIn > 0 && gameWillStart.flagIntro == 1)
        {
            playerController.speed = 0;
            playerController.attackEnable = false;
            gameWillStart.gameWillStartIn -= Time.deltaTime;
        }


        if (gameWillStart.gameWillStartIn <= 0 && gameWillStart.flagIntro == 1)
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

        if (dialogueManager.PrayFlag == 1)
        {
            buttonF.gameObject.SetActive(true);
            if (Input.GetKey("f"))
            {
                anim.SetBool("IsPraying", true);
                dialogueManager.PrayFlag = 0;
                buttonF.gameObject.SetActive(false);
                anim.SetBool("ReadyToGo", true);
            }
        }

        if (Vector2.Distance(playerController.hero.transform.position, fourthDialogue.transform.position) < fourthDialogue.radius && fourthDialogueFlag == 0)
        {
            dialogueManager.dialogueWindow.SetActive(true);
            fourthDialogue.TriggerDialog();
            fourthDialogueFlag = 1;
        }
    }
}
