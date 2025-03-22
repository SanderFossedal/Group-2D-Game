using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    [SerializeField, Tooltip("Speed at which the Object moves to the left.")]
    private float horizontalSpeed = 5f;

    private void Update()
    {
        // Move left using Translate, so it adds to any other movement
        transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);
    }
}
