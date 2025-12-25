using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] private int lifePoints;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeadLine"))
        {
            Debug.Log("Enemy reached deadline");
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        lifePoints -= damage;
        Debug.Log("Enemy life points: " + lifePoints);
        if (lifePoints <= 0)
        {
            OnDie();
        }
    }

    private void OnDie()
    {
        Debug.Log("Enemy died");
        Destroy(gameObject);
    }
}
