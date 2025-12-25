using UnityEngine;
public class CameraShake : MonoBehaviour
{
    [SerializeField] private float intensity = 0.05f;
    [SerializeField] private float speed = 20f;

    private Vector3 initialPosition;

    private void Awake()
    {
        initialPosition = transform.localPosition;
    }

    private void Update()
    {
        float offsetX = Mathf.PerlinNoise(Time.time * speed, 0f) - 0.5f;
        float offsetY = Mathf.PerlinNoise(0f, Time.time * speed) - 0.5f;

        Vector3 shakeOffset = new Vector3(offsetX, offsetY, 0f) * intensity;
        transform.localPosition = initialPosition + shakeOffset;
    }

}
