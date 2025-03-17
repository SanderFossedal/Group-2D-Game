using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f; // Kraften p� hoppet
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Henter Rigidbody2D-komponenten p� spillobjektet
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Hopper n�r mellomromstasten trykkes
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    void Jump()
    {
        rb.linearVelocity = Vector2.up * jumpForce; // Setter farten rett opp for et jevnt hopp
    }
}
