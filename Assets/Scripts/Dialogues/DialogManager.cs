using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public int dialogueNumber;

    public int counter;
    public string newName;

    public Image characterIcon;
    public Sprite heroIcon;
    public Sprite ZagumIcon;
    public Sprite HelloWorldIcon;
    public Sprite DeveloperIcon;
    public Sprite SecurityIcon;
    public Sprite Raider;

    public GameObject dialogueWindow;

    [SerializeField] private PlayerController Hero;

    public Text nameText,
                dialogueText;

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

        nameText.text = dialog.name;
        if (dialog.name == "Главный герой")
        {
            nameText.color = new Color(0, 1, 150);
            characterIcon.sprite = heroIcon;
        }

        if (sentences != null)
        {
            sentences.Clear();
        }

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
        if (dialogueNumber == 3 && (counter == 2 || counter == 4 || counter == 7 || counter == 8 || counter == 9) && SceneManager.GetActiveScene().buildIndex != 4)
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
        else if (dialogueNumber == 5 && (counter == 1 || counter == 3 || counter == 4))
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
            nameText.text = "Алексей Андреевич Загумённов";
            nameText.color = Color.yellow;
            characterIcon.sprite = ZagumIcon;
        }
        #endregion

        #region
        else if (dialogueNumber == 8 && (counter == 1 || counter == 2 || counter == 3))
        {
            nameText.text = "Алексей Андреевич Загумённов";
            nameText.color = Color.yellow;
            characterIcon.sprite = ZagumIcon;
        }
        #endregion

        #region
        else if (dialogueNumber == 9 && (counter == 3 || counter == 5 || counter == 6 || counter == 8 || counter == 12 || counter == 14))
        {
            nameText.text = "Алексей Андреевич Загумённов";
            nameText.color = Color.yellow;
            characterIcon.sprite = ZagumIcon;
        }
        #endregion

        #region
        else if (dialogueNumber == 1 && (counter == 1 || counter == 3) && SceneManager.GetActiveScene().buildIndex == 3)
        {
            nameText.text = "Охранник";
            nameText.color = Color.red;
            characterIcon.sprite = SecurityIcon;
        }

        else if (dialogueNumber == 1 && (counter == 5 || counter == 7) && SceneManager.GetActiveScene().buildIndex == 3)
        {
            nameText.text = "Алексей Андреевич Загумённов";
            nameText.color = Color.yellow;
            characterIcon.sprite = ZagumIcon;
        }
        #endregion

        #region
        else if (dialogueNumber == 1 && SceneManager.GetActiveScene().buildIndex == 4)
        {
            nameText.text = "Алексей Андреевич Загумённов";
            nameText.color = Color.yellow;
            characterIcon.sprite = ZagumIcon;
        }
        #endregion

        #region
        else if ((dialogueNumber == 2) && (counter == 2 || counter == 3 || counter == 6 || counter == 8) && (SceneManager.GetActiveScene().buildIndex == 4))
        {
            nameText.text = "Алексей Андреевич Загумённов";
            nameText.color = Color.yellow;
            characterIcon.sprite = ZagumIcon;
        }
        #endregion

        #region
        else if ((dialogueNumber == 3) && (counter == 3 || counter == 6) && (SceneManager.GetActiveScene().buildIndex == 4))
        {
            nameText.text = "Алексей Андреевич Загумённов";
            nameText.color = Color.yellow;
            characterIcon.sprite = ZagumIcon;
        }

        else if ((dialogueNumber == 3) && (counter == 4) && (SceneManager.GetActiveScene().buildIndex == 4))
        {
            nameText.text = "Разработчик";
            nameText.color = Color.green;
            characterIcon.sprite = DeveloperIcon;
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
    }
}
