using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public float maxhealth = 1f;

    [SerializeField] private Image healthImg;
    [SerializeField] private float currenthealth  = 1f;

     

   

    public void TakeDamage( float  value)
    {
        currenthealth -= value;
        healthImg.fillAmount = currenthealth / maxhealth;

        if (currenthealth <= 0f)
        {
            Debug.Log("Вы отчислены");
            Die();
        }  
    }

     public void Die()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
