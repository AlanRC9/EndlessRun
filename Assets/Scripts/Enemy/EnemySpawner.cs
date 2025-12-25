using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float enemySpeed;
    [SerializeField] private float spawnRate;
    [SerializeField] private float spawnRange;
    [SerializeField] private float timeToIncreaseSpawnRate;
    private float fireTimer = 0;
    // private float timeSinceLastSpawnRateChange;
    // private float initialSpawnRate;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, spawnRate);
        // initialSpawnRate = spawnRate;
        // timeSinceLastSpawnRateChange = 0;
    }

    private void Update() {
        fireTimer += Time.deltaTime;
        // timeSinceLastSpawnRateChange += Time.deltaTime;
        
        // // Every 30 seconds, reduce the spawnRate by 10% (make it 10% faster)
        // if (timeSinceLastSpawnRateChange >= 30)
        // {
        //     spawnRate = Mathf.Max(0.1, spawnRate * 0.9); // Reduce the spawnRate by 10% (multiply by 0.9)
        //     timeSinceLastSpawnRateChange = 0;
        // }
        
        // Enemies spawner based on timer.
        if (fireTimer >= timeToIncreaseSpawnRate)
        {
            spawnRate = Mathf.Max(0.1, spawnRate * 0.9); // Increase enemies spawnRate in 10% every 30 seconds.
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
