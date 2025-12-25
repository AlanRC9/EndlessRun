using UnityEngine;
public class CameraShake : MonoBehaviour
{
    [SerializeField] private float baseIntensity = 0.05f;
    [SerializeField] private float extraIntensityMultiplicator = 3;
    [SerializeField] private float speed = 20f;
    private float intensity;
    private Vector3 initialPosition;

    private void Awake()
    {
        initialPosition = transform.localPosition;
    }

    private void Update()
    {
        float offsetX = Mathf.PerlinNoise(Time.time * speed, 0f) - 0.5f;
        float offsetY = Mathf.PerlinNoise(0f, Time.time * speed) - 0.5f;

        if (intensity > baseIntensity)
        {
            intensity -= Time.deltaTime / extraIntensityMultiplicator;
        }
        else
        {
            intensity = baseIntensity;
        }

        Vector3 shakeOffset = new Vector3(offsetX, offsetY, 0f) * intensity;
        transform.localPosition = initialPosition + shakeOffset;
    }

    public void ExtraShake()
    {
        intensity *= extraIntensityMultiplicator; 
    }

}
