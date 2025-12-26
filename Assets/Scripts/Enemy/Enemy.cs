using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI lifePointsText;

    [SerializeField] private int MinLifePoints;
    [SerializeField] private int MaxLifePoints;
    private int lifePoints;

    private void Start()
    {
        lifePoints = Random.Range(MinLifePoints, MaxLifePoints + 1);
        lifePointsText.text = lifePoints.ToString();
    }

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
        lifePointsText.text = lifePoints.ToString();
        if (lifePoints <= 0)
        {
            OnDie();
        }
    }

    private void OnDie()
    {
        Destroy(gameObject);
    }
}
