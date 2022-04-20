using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public int PrayFlag;
    public int dialogueNumber;

    public Intro introLink;
    [SerializeField] private Image firstCutsceneImage;
    [SerializeField] private Image cutsceneBackgroundImage;

    public int counter;
    public string newName;

    public Image characterIcon;
    public Sprite heroIcon;
    public Sprite ZagumIcon;
    public Sprite HelloWorldIcon;

    public GameObject dialogueWindow;
    private DialoguesController dialoguesController;

    [SerializeField] DialogTrigger secondDialogue;

    [SerializeField] private PlayerController Hero;

    public Text nameText,
                dialogueText;

    public Queue<string> sentences;

    private void Start()
    {
        dialogueNumber = 1;
        PrayFlag = 0;
        counter = 0;
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialog)
    {
        Time.timeScale = 0;

        nameText.text = dialog.name;
        if (dialog.name == "Главный герой")
        {
            nameText.color = new Color(0, 1, 150);
            characterIcon.sprite = heroIcon;
        }

        if (dialog.name == "Алексей Андреевич Загумённов")
        {
            nameText.color = Color.yellow;
            characterIcon.sprite = ZagumIcon;
        }

        sentences.Clear();

        foreach (string sentence in dialog.sentenses) { 
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        counter++;

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        #region
        if (dialogueNumber == 3 && (counter == 2 || counter == 4 || counter == 7 || counter == 8))
        {
            nameText.text = "Алексей Андреевич Загумённов";
            nameText.color = Color.yellow;
            characterIcon.sprite = ZagumIcon;
        }
        #endregion

        #region
        else if (dialogueNumber == 4 && (counter == 1 || counter == 3 || counter == 5))
        {
            nameText.text = "Алексей Андреевич Загумённов";
            nameText.color = Color.yellow;
            characterIcon.sprite = ZagumIcon;
        }
        #endregion

        #region
        else if (dialogueNumber == 5)
        {
            nameText.text = "Алексей Андреевич Загумённов";
            nameText.color = Color.yellow;
            characterIcon.sprite = ZagumIcon;
        }
        #endregion

        #region
        else if (dialogueNumber == 6 && (counter == 1 || counter == 3 || counter == 5 || counter == 6 || counter == 7))
        {
            nameText.text = "Алексей Андреевич Загумённов";
            nameText.color = Color.yellow;
            characterIcon.sprite = ZagumIcon;
        }
        #endregion

        #region
        else if (dialogueNumber == 7 && (counter == 1))
        {
            nameText.text = "Hello World Cat";
            nameText.color = Color.green;
            characterIcon.sprite = HelloWorldIcon;
        }

        else if (dialogueNumber == 7 && (counter == 4 || counter == 5 || counter == 6))
        {
            nameText.text = "Загумённов";
            nameText.color = Color.yellow;
            characterIcon.sprite = ZagumIcon;
        }
        #endregion

        else
        {
            nameText.text = "Главный герой";
            nameText.color = new Color(0, 1, 150);
            characterIcon.sprite = heroIcon;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }


    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        dialogueNumber++;
        dialogueWindow.SetActive(false);
        Time.timeScale = 1;
        counter = 0;

        if (introLink.firstCutscene == 1)
        {
            firstCutsceneImage.gameObject.SetActive(true);
            cutsceneBackgroundImage.gameObject.SetActive(true);
        }

        //dialoguesController.diffFlag = 0;
    }

    private void Update()
    {
        if (Hero.waittime > 0 && introLink.firstCutscene == 1 && counter == 0 && introLink.gameWillStartIn < 0)
        {
            Hero.waittime -= Time.deltaTime;
            if (Hero.waittime < 0)
            {
                introLink.firstCutscene = 0;
                firstCutsceneImage.gameObject.SetActive(false);
                cutsceneBackgroundImage.gameObject.SetActive(false);
                dialogueWindow.SetActive(true);

                secondDialogue.TriggerDialog();
                PrayFlag = 1;
            }
        }
    }
}
