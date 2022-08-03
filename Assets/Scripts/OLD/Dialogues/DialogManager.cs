using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public int dialogueNumber;
    public int counter;

    public GameObject dialogueWindow;
    public Button nextSentenceButton;

    private Dialogue dialogue;

    #region Phrase
    public Text nameText,
                dialogueText;
    public Image characterIcon;
    #endregion

    public Queue<string> sentences;

    private void Start()
    {
        dialogueNumber = 1;
        counter = 0;
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialog)
    {
        Time.timeScale = 0;

        dialogue = dialog;

        if (sentences != null)
        {
            sentences.Clear();
        }

        foreach (string sentence in dialog.sentenses) { 
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    private void Update()
    {
        if (dialogueWindow.activeSelf == true)
        {
            if (Input.GetKeyDown("space"))
            {
                nextSentenceButton.onClick.Invoke();
                
            }
        }
    }

    public void DisplayNextSentence()
    {
        counter++;

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        UpdateIcon(dialogue);
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

    public void UpdateIcon(Dialogue dialogue)
    {
        nameText.text = dialogue.name[counter - 1];
        characterIcon.sprite = dialogue.icons[counter - 1];

        if (dialogue.name[counter-1] == "Главный герой")
        {
            nameText.color = new Color(0, 1, 150);
        }

        if (dialogue.name[counter-1] == "Бог программирования")
        {
            nameText.color = Color.yellow;
        }

        if (dialogue.name[counter - 1] == "«Hello, World!» Cat")
        {
            nameText.color = Color.green;
        }

        if (dialogue.name[counter - 1] == "Разработчик")
        {
            nameText.color = Color.green;
        }

        if (dialogue.name[counter - 1] == "Охранник")
        {
            nameText.color = Color.red;
        }

        if (dialogue.name[counter - 1] == "Рейдер")
        {
            nameText.color = Color.red;
        }
    }


    public void EndDialogue()
    {
        dialogueNumber++;
        dialogueWindow.SetActive(false);
        Time.timeScale = 1;
        counter = 0;
    }
}
