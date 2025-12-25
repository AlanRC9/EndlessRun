using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float enemySpeed;
    [SerializeField] private float spawnRate;
    [SerializeField] private float spawnRange;
    private float fireTimer;
    private float timeSinceLastSpawnRateChange;
    private float initialSpawnRate;

    private void Start()
    {
        fireTimer = spawnRate;
        InvokeRepeating("SpawnEnemy", 0, spawnRate);
        // initialSpawnRate = spawnRate;
        // timeSinceLastSpawnRateChange = 0f;
    }

    private void Update() {
        fireTimer -= Time.deltaTime;
        // timeSinceLastSpawnRateChange += Time.deltaTime;
        
        // // Every 30 seconds, reduce the spawnRate by 10% (make it 10% faster)
        // if (timeSinceLastSpawnRateChange >= 30f)
        // {
        //     spawnRate = Mathf.Max(0.1f, spawnRate * 0.9f); // Reduce the spawnRate by 10% (multiply by 0.9)
        //     timeSinceLastSpawnRateChange = 0f;
        // }
        
        // Enemies spawner based on timer.
        if (fireTimer <= 0f)
        {
            spawnRate = Mathf.Max(0.1f, spawnRate * 0.9f); // Increase enemies spawnRate in 10% every 30 seconds.
            fireTimer = spawnRate;
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
