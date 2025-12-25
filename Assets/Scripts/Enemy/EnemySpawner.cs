using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRate;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, spawnRate);
    }
    
    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
    }
}
