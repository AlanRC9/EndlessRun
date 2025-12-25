using UnityEngine;

public class Cannon : MonoBehaviour
{

    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float fireRate;
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
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            fireTimer = fireRate;
        }

    }



}
