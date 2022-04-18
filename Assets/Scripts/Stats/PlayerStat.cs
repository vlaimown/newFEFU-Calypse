using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : CharacterStats
{
    public override void Die()
    {
        base.Die();
        PlayerManager.instance.KillPlayer();
        Debug.Log("Вы отчислены");
    }
}
