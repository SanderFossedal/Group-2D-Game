using UnityEngine;

public class EnemyBird : MonoBehaviour
{
    [SerializeField]
    private float flightSpeed;

    [SerializeField]
    private float flightRange; // **NEW: Defines how far the bird can move up/down from spawn**

    [SerializeField]
    private Rigidbody2D rigidBody;

    public float highestGravity;
    public float lowestGravity;

    private float startY; // **NEW: Stores the bird's initial Y position**

    void Start()
    {
        startY = transform.position.y; // **NEW: Set starting Y position**
    }

    void Update()
    {
        transform.position += Vector3.left * flightSpeed * Time.deltaTime;

        // **NEW: Use startY to make flight range relative to each bird**
        if (transform.position.y <= startY - flightRange)
        {
            rigidBody.gravityScale = lowestGravity;
        }
        else if (transform.position.y >= startY + flightRange)
        {
            rigidBody.gravityScale = highestGravity;
        }

        rigidBody.linearVelocity = new Vector2(rigidBody.linearVelocity.x, Mathf.Clamp(rigidBody.linearVelocity.y, -2f, 2f));
    }
}
