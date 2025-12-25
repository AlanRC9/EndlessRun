using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float enemySpeed;
    [SerializeField] private float spawnRate;
    [SerializeField] private float spawnRange;
    [SerializeField] private float timeToIncreaseSpawnRate;
    [SerializeField] private float spawnRateSpeedIncreasePercentage = 1.1f;
    [SerializeField] private float minSpawnRate;
    private float fireTimer = 0;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, spawnRate);
    }

    private void Update() {
        fireTimer += Time.deltaTime;
        
        // Enemies spawner based on timer.
        if (fireTimer >= timeToIncreaseSpawnRate)
        {
            spawnRate /= spawnRateSpeedIncreasePercentage;
            fireTimer = 0;
        }
    }
    
    private void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, RandomStartPosition(), Quaternion.identity);
        newEnemy.GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, -enemySpeed);
    }
    
    private Vector3 RandomStartPosition()
    {
        float XPosition = Random.Range(-spawnRange, spawnRange);
        return new Vector3(XPosition, 0, transform.position.z);
    }
}
