using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BulletBehaviour : MonoBehaviour
{
    private int damage;

    private void Start()
    {
        damage = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            gameObject.SetActive(false);
        }
        if (other.CompareTag("BulletDeadLine"))
        {
            gameObject.SetActive(false);
        }
    }

    public void setDamage(int newDamage)
    {
        damage = newDamage;
    }

}
