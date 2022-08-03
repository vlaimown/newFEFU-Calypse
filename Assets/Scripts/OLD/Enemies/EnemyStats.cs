using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyStats : CharacterStats
{
    //int rnd_sheet = 0;
    //[SerializeField] GameObject sheet;
    //[SerializeField] SpawnEnemy spawnEnemy;
    //[SerializeField] SurvivalMode survivalMode;

    //[SerializeField] float waitTime;
    //public bool staggered = false;

    ////[SerializeField] WaterFirstSkill water_first_skill;

    ////[SerializeField] BJD_skill bjd_Skill;
    //public override void Die()
    //{
    //    player.GetComponent<SpriteRenderer>().color = Color.white;

    //    //if (SceneManager.GetActiveScene().buildIndex != 6)
    //    //{
    //    //    spawnEnemy = FindObjectOfType<SpawnEnemy>();
    //    //    spawnEnemy.count = spawnEnemy.count - 1;
    //    //}

    //    if (SceneManager.GetActiveScene().buildIndex == 6)
    //    {
    //        survivalMode = FindObjectOfType<SurvivalMode>();
    //        survivalMode.count = survivalMode.count - 1;
    //        survivalMode.diedZombieCount++;
    //        survivalMode.maxScore += survivalMode.pointsForClassicZombie;
    //    }

    //    base.Die();
    //    Destroy(gameObject);
    //    healthBar.fillAmount = 1f;

    //   // water_first_skill = FindObjectOfType<WaterFirstSkill>();

    //    //if (skill.waterTargets.Count > 1)
    //    //{
    //        //skill.waterTargets.Remove(gameObject.GetComponent<Collider2D>());
    //    //}
    //    //SpawnSheet();
    //}

    //public void SpawnSheet()
    //{
    //    rnd_sheet = Random.Range(1, 2);
    //    if (rnd_sheet == 1)
    //    {
    //        Instantiate(sheet, new Vector2(transform.position.x - 1, transform.position.y), Quaternion.identity);
    //    }
    //}
}
