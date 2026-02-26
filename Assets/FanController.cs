using UnityEngine;

public class FanController : MonoBehaviour
{
    [Header("Settings")]
    public bool isOn = false;
    public float maxSpeed = 800f; // Max degrees per second
    public float acceleration = 2f; // How fast it reaches max speed

    private float currentSpeed = 0f;

    void Update()
    {
        // 1. Determine the target speed based on the toggle
        float targetSpeed = isOn ? maxSpeed : 0f;

        // 2. Smoothly transition currentSpeed toward targetSpeed
        // MoveTowards is great for linear changes; Lerp for "easing"
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * 100f * Time.deltaTime);

        // 3. Apply the rotation (adjust Vector3.up if your fan axis is different)
        transform.Rotate(Vector3.up * currentSpeed * Time.deltaTime);
    }

    // Context menu allows you to test the toggle by right-clicking the component
    [ContextMenu("Toggle Fan")]
    public void ToggleFan()
    {
        isOn = !isOn;
    }
}