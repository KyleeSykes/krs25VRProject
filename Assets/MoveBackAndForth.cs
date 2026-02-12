using UnityEngine;

public class MoveBackAndForth : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("How far the object moves from its starting point.")]
    public float distance = 3.0f; // The amplitude of the wave

    [Tooltip("How fast the object moves.")]
    public float speed = 2.0f;    // The frequency of the wave

    [Header("Direction")]
    [Tooltip("Set X, Y, or Z to 1 to choose direction. You can also mix them (e.g., 1, 1, 0).")]
    public Vector3 direction = new Vector3(1, 0, 0); // Default to X-axis

    private Vector3 startPosition;

    void Start()
    {
        // Remember where the object started so movement is relative to this point
        startPosition = transform.position;
    }

    void Update()
    {
        // 1. Calculate the offset based on time
        // We use Math.Sin because it naturally oscillates between -1 and 1
        float rawSineValue = Mathf.Sin(Time.time * speed);

        // 2. Scale that value by our distance setting
        float movementOffset = rawSineValue * distance;

        // 3. Apply the offset to the starting position along the chosen direction
        // We normalize the direction so the speed stays consistent even on diagonals
        transform.position = startPosition + (direction.normalized * movementOffset);
    }
}