using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    [SerializeField] private float bulletVelocity;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = new Vector3(0,0,bulletVelocity);
    }

}
