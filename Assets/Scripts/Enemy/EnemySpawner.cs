using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRate;
    [SerializeField] private float spawnRange;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, spawnRate);
    }
    
    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, RandomStartPosition(), Quaternion.identity);
    }
    
    private Vector3 RandomStartPosition()
    {
        float XPosition = Random.Range(-spawnRange, spawnRange);
        return new Vector3(XPosition, 0, 0);
    }
}
