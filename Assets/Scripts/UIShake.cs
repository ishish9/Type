using UnityEngine;

public class UIShake : MonoBehaviour
{
    // Variables to control the shake effect
    [SerializeField] private float shakeDuration = 0.5f;    // How long the shake lasts
    [SerializeField] private float shakeMagnitude = 10f;    // How intense the shake is
    [SerializeField] private float dampingSpeed = 1.0f;     // How quickly the shake fades

    private RectTransform rec;
    private Vector3 initialAnchorPosition;                        // Original position of the UI element
    private Vector3 initialPosition;                        // Original position of the UI element
    private float currentShakeDuration;                     // Current remaining duration
    private bool isShaking = false;                         // Shake state

    void Start()
    {
        // Store the initial position of the UI element
        rec = GetComponent<RectTransform>();
        initialAnchorPosition = rec.anchoredPosition;
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        if (isShaking)
        {
            if (currentShakeDuration > 0)
            {
                // Apply random offset to position within magnitude bounds
                rec.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
                currentShakeDuration -= Time.deltaTime * dampingSpeed;
            }
            else
            {
                // Reset position and stop shaking when duration is up
                isShaking = false;
                transform.localPosition = initialPosition;
            }
        }
    }

    // Public method to trigger the shake
    public void TriggerShake()
    {
        currentShakeDuration = shakeDuration;
        isShaking = true;
    }

    // Optional: Method to trigger shake with custom parameters
    public void TriggerShake(float duration, float magnitude)
    {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
        currentShakeDuration = duration;
        isShaking = true;
    }
}
