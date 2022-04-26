using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SurvivalMode : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] PlayerStat playerStat;
    [SerializeField] Inventory inventory;
    [SerializeField] Image fade;
    [SerializeField] Text waveCounterTxt;
    [SerializeField] Image waveCounterImg;
    [SerializeField] int waveCounter = 1;

    [SerializeField] GameObject yourScore;

    public GameObject Enemy;
    public Transform[] EnemySpawnerPosition;
    private int _randomSpawnPoints;
    public int MaxEnenyInScene = 5;
    public int count = 0;

    public bool spawnEnemyFlag = false;
    public float minTimeToSpawn;
    public float timeToSpawn;
    public float maxTimeToSpawn;

    [SerializeField] Skill skill;

    [SerializeField] CameraFollow cameraFollow;
    private void Awake()
    {
        playerController.speed = 0;
        inventory.windowInventory.SetActive(true);
        fade.gameObject.SetActive(true);

        count = MaxEnenyInScene;
    }

    private void FixedUpdate()
    {
       if (spawnEnemyFlag == true)
        {
            if (count > 0)
            {
                timeToSpawn -= Time.deltaTime;
                if (timeToSpawn < 0)
                {
                    _randomSpawnPoints = Random.Range(0, EnemySpawnerPosition.Length);
                    if ((EnemySpawnerPosition[_randomSpawnPoints].position.x > cameraFollow.maxValue.x) && (EnemySpawnerPosition[_randomSpawnPoints].position.x < cameraFollow.minValues.x))
                    {
                        _randomSpawnPoints = Random.Range(0, EnemySpawnerPosition.Length);
                    }
                    if ((EnemySpawnerPosition[_randomSpawnPoints].position.x < cameraFollow.maxValue.x) && (EnemySpawnerPosition[_randomSpawnPoints].position.x > cameraFollow.minValues.x))
                    {
                        Instantiate(Enemy, EnemySpawnerPosition[_randomSpawnPoints].position, Quaternion.identity);
                        count--;
                        timeToSpawn = maxTimeToSpawn;
                    }
                }
            }

            if (count <= 0 && GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                waveCounter++;
                waveCounterImg.gameObject.SetActive(true);
                waveCounterTxt.text = $"{waveCounter}";
                MaxEnenyInScene++;
                if (waveCounter % 4 == 0)
                {
                    MaxEnenyInScene += 2;
                }
                if (waveCounter % 10 == 0 && (maxTimeToSpawn - 0.4f >= minTimeToSpawn))
                {
                    maxTimeToSpawn -= 0.4f;
                }
                count = MaxEnenyInScene;
            }
        }

       if (playerStat.currentHealth <= 0)
       {
            Time.timeScale = 0;
            yourScore.SetActive(true);
       }
    }
}
