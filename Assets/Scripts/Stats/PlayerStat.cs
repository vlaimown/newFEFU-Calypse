using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerStat : CharacterStats
{
    public override void Die()
    {
        base.Die();

        if (SceneManager.GetActiveScene().buildIndex != 6) 
        { 
        PlayerManager.instance.KillPlayer();
        Debug.Log("Вы отчислены");
        }
    }
}
