using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject Enemy;
    public Transform[] EnemySpawnerPosition;
    private int _randomSpawnPoints;
    public float RepeatRate = 3f;
    public int DestroySpawner  ;
    public int MaxEnenyInScene = 5;
    [SerializeField] private int count = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.gameObject.tag  == "Player")
        {
            
                if (count != MaxEnenyInScene)
                {
                    InvokeRepeating("EnemySpawner", 1f, RepeatRate);
                }  
          // Destroy(gameObject, DestroySpawner);
            gameObject.GetComponent<CircleCollider2D>().enabled = false;  
        }
    }

    private void EnemySpawner()
    {
        if (count == MaxEnenyInScene -1)
        {
            CancelInvoke("EnemySpawner");
        }
        count++;
        _randomSpawnPoints = Random.Range(0, EnemySpawnerPosition.Length);
        Instantiate(Enemy, EnemySpawnerPosition[_randomSpawnPoints].position, Quaternion.identity);       
    }
}
