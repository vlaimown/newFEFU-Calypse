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

    //[SerializeField] RedCat redCat;
    [SerializeField] int randomRedCatSpawnPoint;
    [SerializeField] Transform[] arrayRedCatSpawnPoint = new Transform[4];
    [SerializeField] GameObject redCatPrefab;

    [SerializeField] GameObject yourScore;

    public GameObject Enemy;
    public Transform[] EnemySpawnerPosition;
    private int _randomSpawnPoints;
    public int MaxEnenyInScene = 5;
    public int count = 0;

    [SerializeField] float nextWaveWillBeginTime;
    [SerializeField] float currentWaveTime;

    public bool spawnEnemyFlag = false;
    public float minTimeToSpawn;
    public float timeToSpawn;
    public float maxTimeToSpawn;

    [SerializeField] Image bottleSkillIcon;

    [SerializeField] Skill skill;

    [SerializeField] CameraFollow cameraFollow;

    bool redCatSpawned = false;

    #region Score
    public int maxScore;
    [SerializeField] Text maxScoreCount;

    public int diedZombieCount = 0;
    [SerializeField] Text diedZombie;

    public int pointsForClassicZombie = 10;
    #endregion

    private void Awake()
    {
        redCatSpawned = false;

        diedZombieCount = 0;
        playerController.speed = 0;
        inventory.windowInventory.SetActive(true);
        fade.gameObject.SetActive(true);

        count = MaxEnenyInScene;
        playerController.avaible_skills = true;
        bottleSkillIcon.gameObject.SetActive(true);
    }

    private void Start()
    {
        currentWaveTime = nextWaveWillBeginTime;
        count = 0;
    }

    private void FixedUpdate()
    {
       if (spawnEnemyFlag == true)
        {
            currentWaveTime -= Time.deltaTime;
            if (count < MaxEnenyInScene)
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
                        count++;
                        timeToSpawn = maxTimeToSpawn;
                    }
                }
            }

            if (currentWaveTime <= 0)
            {
                waveCounter++;
                waveCounterImg.gameObject.SetActive(true);
                waveCounterTxt.text = $"{waveCounter}";
                MaxEnenyInScene++;
                if (waveCounter % 4 == 0)
                {
                    MaxEnenyInScene += 1;
                }
                if (waveCounter % 10 == 0 && (maxTimeToSpawn - 0.4f >= minTimeToSpawn))
                {
                    maxTimeToSpawn -= 0.2f;
                }
                currentWaveTime = nextWaveWillBeginTime;
                redCatSpawned = false;
            }
        }

        if (waveCounter % 5 == 0 && redCatSpawned == false)
        {
            randomRedCatSpawnPoint = Random.Range(0, 4);
            Instantiate(redCatPrefab, arrayRedCatSpawnPoint[randomRedCatSpawnPoint].position, Quaternion.identity);
            redCatSpawned = true;
        }

       if (playerStat.currentHealth <= 0)
       {
            Time.timeScale = 0;

            diedZombie.text = $"{diedZombieCount}";
            maxScoreCount.text = $"{maxScore}";
            yourScore.SetActive(true);
       }
    }
}
