using UnityEngine;

public class Cannon : MonoBehaviour
{

    [SerializeField] private float fireRate;
    [SerializeField] private float bulletSpeed;
    private float fireTimer;
    
    private void Start()
    {
        fireTimer = fireRate;
    }

    private void Update()
    {
        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0)
        {
            Shoot();
            ScoreManager.Instance.AddPoints(10);
            fireTimer = fireRate;
        }

    }

    private void Shoot()
    {
        GameObject newBullet = PoolManager.Instance.GetFirstAvailableObject("Bullet");
        newBullet.transform.position = transform.position;
        newBullet.GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, bulletSpeed);
    }

}
