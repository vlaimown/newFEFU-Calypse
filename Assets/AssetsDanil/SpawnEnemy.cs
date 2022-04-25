using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject Enemy;
    public Transform[] EnemySpawnerPosition;
    private int _randomSpawnPoints;
    //public float RepeatRate;
    //public int DestroySpawner;
    public int MaxEnenyInScene = 5;
    public int count = 0;

    public bool spawnEnemyFlag;
    public float timeToSpawn;
    public float maxTimeToSpawn;

    [SerializeField] CameraFollow cameraFollow;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.gameObject.tag  == "Player")
        {
            //StartCoroutine(EnemySpawner());
            spawnEnemyFlag = true;
                /*if (count < MaxEnenyInScene)
                {
                    InvokeRepeating("EnemySpawner", 1f, RepeatRate);
                }*/
          // Destroy(gameObject, DestroySpawner);
            gameObject.GetComponent<CircleCollider2D>().enabled = false;  
        }
    }

    /*IEnumerator EnemySpawner()
    {
        if (count < MaxEnenyInScene)
        {
            _randomSpawnPoints = Random.Range(0, EnemySpawnerPosition.Length);
            if ((EnemySpawnerPosition[_randomSpawnPoints].position.x > cameraFollow.maxValue.x) && (EnemySpawnerPosition[_randomSpawnPoints].position.x < cameraFollow.minValues.x))
            {
                while ((EnemySpawnerPosition[_randomSpawnPoints].position.x > cameraFollow.maxValue.x) && (EnemySpawnerPosition[_randomSpawnPoints].position.x < cameraFollow.minValues.x))
                {
                    Debug.Log("let's go");
                    _randomSpawnPoints = Random.Range(0, EnemySpawnerPosition.Length);
                }
            }
            if ((EnemySpawnerPosition[_randomSpawnPoints].position.x < cameraFollow.maxValue.x) && (EnemySpawnerPosition[_randomSpawnPoints].position.x > cameraFollow.minValues.x))
            {
                Instantiate(Enemy, EnemySpawnerPosition[_randomSpawnPoints].position, Quaternion.identity);
                count++;
            }
        }
        yield return new WaitForSeconds(5f);
        StartCoroutine(EnemySpawner());
    }*/

    /*private void EnemySpawner()
    {
        if (count == MaxEnenyInScene -1)
        {
            CancelInvoke("EnemySpawner");
        }
        _randomSpawnPoints = Random.Range(0, EnemySpawnerPosition.Length);
        if ((EnemySpawnerPosition[_randomSpawnPoints].position.x > cameraFollow.maxValue.x) && (EnemySpawnerPosition[_randomSpawnPoints].position.x < cameraFollow.minValues.x))
        {
            _randomSpawnPoints = Random.Range(0, EnemySpawnerPosition.Length);
        }
        if ((EnemySpawnerPosition[_randomSpawnPoints].position.x < cameraFollow.maxValue.x) && (EnemySpawnerPosition[_randomSpawnPoints].position.x > cameraFollow.minValues.x))
        {
            Instantiate(Enemy, EnemySpawnerPosition[_randomSpawnPoints].position, Quaternion.identity);
            count++;
        }
    }*/

    private void Start()
    {
        spawnEnemyFlag = false;
        timeToSpawn = maxTimeToSpawn;
    }
    private void FixedUpdate()
    {
        if (spawnEnemyFlag == true)
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
        }
    }
}
