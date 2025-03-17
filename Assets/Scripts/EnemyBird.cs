using UnityEngine;

public class EnemyBird : MonoBehaviour
{
    [SerializeField]
    private float flightSpeed;
    
    [SerializeField]
    private float lowestFlightPoint;
   
    [SerializeField]
    private float highestFlightPoint;
    
    [SerializeField]
    private Rigidbody2D rigidBody;

    public float highestGravity;
    public float lowestGravity;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * flightSpeed * Time.deltaTime);
        
        if (transform.position.y <= lowestFlightPoint)
        {

            rigidBody.gravityScale = lowestGravity;
        }
        if (transform.position.y >= highestFlightPoint)
        {

            rigidBody.gravityScale = highestGravity;
        }

        // **NEW: Clamp vertical speed to prevent exponential growth**
        rigidBody.linearVelocity = new Vector2(rigidBody.linearVelocity.x, Mathf.Clamp(rigidBody.linearVelocity.y, -2f, 2f));
    }
}
