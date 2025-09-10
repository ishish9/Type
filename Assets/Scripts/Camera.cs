using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public static Camera instance;
    private Vector3 initialPosition;
    [SerializeField] private float shakeDuration = 0.5f;
    [SerializeField] private float shakeMagnitude = 0.1f;
    [SerializeField] private float dampingSpeed = 1.0f;
    private float currentShakeDuration;
    private float currentShakeMagnitude;
    private bool isShaking = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShaking)
        {
            if (currentShakeDuration > 0)
            {
                // Apply random offset to camera position
                transform.localPosition = initialPosition + Random.insideUnitSphere * currentShakeMagnitude;

                // Reduce duration and magnitude over time
                currentShakeDuration -= Time.deltaTime * dampingSpeed;
                currentShakeMagnitude = Mathf.Lerp(currentShakeMagnitude, 0, Time.deltaTime * dampingSpeed);
            }
            else
            {
                // Reset when shake is complete
                isShaking = false;
                transform.localPosition = initialPosition;
            }
        }
    }

    public void TriggerShake()
    {
        TriggerShake(shakeDuration, shakeMagnitude);
    }

    public void TriggerShake(float duration, float magnitude)
    {
        if (!isShaking)
        {
            initialPosition = transform.localPosition;
        }

        isShaking = true;
        currentShakeDuration = duration;
        currentShakeMagnitude = magnitude;
    }
}
