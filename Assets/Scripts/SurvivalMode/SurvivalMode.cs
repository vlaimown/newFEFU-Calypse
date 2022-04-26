using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SurvivalMode : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] Inventory inventory;
    [SerializeField] Image fade;

    public GameObject Enemy;
    public Transform[] EnemySpawnerPosition;
    private int _randomSpawnPoints;
    public int MaxEnenyInScene = 5;
    public int count = 0;

    public bool spawnEnemyFlag = false;
    public float timeToSpawn;
    public float maxTimeToSpawn;

    [SerializeField] CameraFollow cameraFollow;
    private void Awake()
    {
        playerController.speed = 0;
        inventory.windowInventory.SetActive(true);
        fade.gameObject.SetActive(true);
    }

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
       /* if (spawnEnemyFlag == true)
        {
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
        }*/
    }
}
