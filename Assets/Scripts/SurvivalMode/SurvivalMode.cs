using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvivalMode : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] PlayerStat playerStat;
    [SerializeField] Inventory inventory;
    [SerializeField] Image fade;
    [SerializeField] Text waveCounterTxt;
    [SerializeField] Image waveCounterImg;
    [SerializeField] int waveCounter = 1;

    [SerializeField] int randomRedCatSpawnPoint;
    [SerializeField] Transform[] arrayRedCatSpawnPoint = new Transform[4];
    [SerializeField] GameObject redCatPrefab;

    [SerializeField] GameObject yourScore;

    public GameObject Enemy;
    public Transform[] EnemySpawnerPosition;
    private int _randomSpawnPoints;
    public int SpawnInWave = 1;
    public int count = 0;

    [SerializeField] float nextWaveWillBeginTime = 10f;
    [SerializeField] float currentWaveTime;

    public bool spawnEnemyFlag = false;
    public float minTimeToSpawn;
    public float timeToSpawn;
    public float maxTimeToSpawn;

    [SerializeField] Image bottleSkillIcon;

    [SerializeField] Skill skill;

    [SerializeField] CameraFollow cameraFollow;

    public int i = 0;

    bool redCatSpawned = false;

    #region Score
    public int maxScore;
    [SerializeField] Text maxScoreCount;

    [SerializeField] Text wavesSurvived;
    [SerializeField] int pointsForWaves = 100;

    public int diedZombieCount = 0;
    [SerializeField] Text diedZombie;
    public int pointsForClassicZombie = 10;

    [SerializeField] Text drunkEnergy;
    public int pointsForEnergy = 2;
    public int energyCount = 0;
    #endregion

    private void Awake()
    {
        energyCount = 0;
        redCatSpawned = false;

        diedZombieCount = 0;
        playerController.speed = 0;
        inventory.windowInventory.SetActive(true);
        fade.gameObject.SetActive(true);

        count = SpawnInWave;
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
            timeToSpawn -= Time.deltaTime;
            if (timeToSpawn < 0)
                {

                _randomSpawnPoints = Random.Range(0, EnemySpawnerPosition.Length);
                if ((EnemySpawnerPosition[_randomSpawnPoints].position.x > cameraFollow.maxValue.x) && (EnemySpawnerPosition[_randomSpawnPoints].position.x < cameraFollow.minValues.x))
                {
                    _randomSpawnPoints = Random.Range(0, EnemySpawnerPosition.Length);
                }
                else if ((EnemySpawnerPosition[_randomSpawnPoints].position.x < cameraFollow.maxValue.x) && (EnemySpawnerPosition[_randomSpawnPoints].position.x > cameraFollow.minValues.x))
                {
                    for (int i = 0; i < SpawnInWave; i++)
                    {
                        Instantiate(Enemy, EnemySpawnerPosition[_randomSpawnPoints].position, Quaternion.identity);
                        count++;
                    }
                    timeToSpawn = maxTimeToSpawn;
                }
            //StartCoroutine(SpawnClassicZombie());
            }

            if (currentWaveTime <= 0)
            {
                waveCounter++;
                maxScore += pointsForWaves;
                waveCounterImg.gameObject.SetActive(true);
                waveCounterTxt.text = $"{waveCounter}";
                if (waveCounter % 5 == 0)
                {
                    SpawnInWave += 1;
                }
                if (waveCounter % 10 == 0 && (maxTimeToSpawn - 0.4f >= minTimeToSpawn))
                {
                    maxTimeToSpawn -= 0.2f;
                }

                nextWaveWillBeginTime += 0.5f;
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
            wavesSurvived.text = $"{waveCounter}";
            drunkEnergy.text = $"{energyCount}";

            yourScore.SetActive(true);
       }
    }

    /*IEnumerator SpawnClassicZombie()
    {
        for (int i = 0; i < MaxEnenyInScene; i++)
        {
            _randomSpawnPoints = Random.Range(0, EnemySpawnerPosition.Length);
            if ((EnemySpawnerPosition[_randomSpawnPoints].position.x > cameraFollow.maxValue.x) && (EnemySpawnerPosition[_randomSpawnPoints].position.x < cameraFollow.minValues.x))
            {
                //StopAllCoroutines();
                //yield return null;
                StartCoroutine(SpawnClassicZombie());
            }
            if ((EnemySpawnerPosition[_randomSpawnPoints].position.x < cameraFollow.maxValue.x) && (EnemySpawnerPosition[_randomSpawnPoints].position.x > cameraFollow.minValues.x))
            {
                Instantiate(Enemy, EnemySpawnerPosition[_randomSpawnPoints].position, Quaternion.identity);
                count++;
            }
        }
        yield return null;
        timeToSpawn = maxTimeToSpawn;
    }*/
}
