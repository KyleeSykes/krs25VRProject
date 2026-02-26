using UnityEngine;

public class SpinGlobe : MonoBehaviour
{
    [Header("Rotation Settings")]
    [Tooltip("The speed and direction of the rotation on the X, Y, and Z axes.")]
    public Vector3 rotationSpeed = new Vector3(0f, 15f, 0f);

    [Tooltip("Choose 'Self' to spin on its own tilted axis, or 'World' to spin perfectly upright relative to the scene.")]
    public Space rotationSpace = Space.Self;

    void Update()
    {
        // transform.Rotate applies the rotation frame by frame.
        // Multiplying by Time.deltaTime ensures the globe spins smoothly regardless of the game's framerate.
        transform.Rotate(rotationSpeed * Time.deltaTime, rotationSpace);
    }
}