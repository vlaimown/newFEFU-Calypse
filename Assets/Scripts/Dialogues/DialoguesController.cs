using UnityEngine;
using UnityEngine.UI;

public class DialoguesController : MonoBehaviour
{
    public Animator anim;

    public Image buttonF;

    public DialogManager dialogueManager;
    public int PrayFlag = 0;
    public PlayerController playerController;


    #region AllDialogues
    public DialogTrigger firstDialogue,
                         secondDialogue,
                         thirdDialogue,
                         fourthDialogue,
                         fifthDialogue,
                         sixDialogue,
                         seventhDialogue,
                         eighthDialogue,
                         ninthDialogue,
                         tenthDialogue,
                         eleventhDialogue,
                         twelfthDialogue,
                         thirteenthDialogue,
                         fourteenthDialogue,
                         fifteenthDialogue,
                         sixteenthDialogue,
                         seventeenthDialogue;
    #endregion

    public int fourthDialogueFlag = 0;
    public float radius;

    public int startFlag;
    public int coun = 0;
    private void FixedUpdate()
    {
        if (PrayFlag == 2 && dialogueManager.dialogueNumber == 3)
        {
            buttonF.gameObject.SetActive(true);
            if (Input.GetKey("f"))
            {
                anim.SetBool("IsPraying", true);
                buttonF.gameObject.SetActive(false);
                anim.SetBool("ReadyToGo", true);
                PrayFlag = 3;
            }
        }

        if (fourthDialogue != null)
        {
            if (Vector2.Distance(playerController.hero.transform.position, fourthDialogue.transform.position) < fourthDialogue.radius && fourthDialogueFlag == 0)
            {
                dialogueManager.dialogueWindow.SetActive(true);
                fourthDialogue.TriggerDialog();
                fourthDialogueFlag = 1;
            }
        }
    }
}
