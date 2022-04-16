using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthImg;
    [SerializeField] private float currenthealth;
    [SerializeField] private float maxhealth;

    private void Start()
    {
        currenthealth = maxhealth;
    }

    public void LoseHealth(int value)
    {
        if (currenthealth <= 0)
        {
            return;
        }
        currenthealth -= value;
        healthImg.fillAmount = currenthealth / maxhealth;

        if (currenthealth <= 0)
        {
            Debug.Log("Вы отчислены");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            LoseHealth(25);
        if (currenthealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
