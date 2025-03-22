using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    public enum MovementType { None, Constant, ConstantRandom, Oscillatory }

    [Header("Movement Type")]
    [SerializeField, Tooltip("Choose how the enemy moves vertically.")]
    private MovementType movementType = MovementType.None;

    [Header("Constant Movement Settings")]
    [SerializeField, Tooltip("Check to move up (only for constant movement).")]
    private bool moveUp = false;
    [SerializeField, Tooltip("Check to move down (only for constant movement).")]
    private bool moveDown = false;
    [SerializeField, Tooltip("Speed for constant vertical movement.")]
    private float verticalSpeed = 2f;

    [Header("Random Constant Movement Settings")]
    [SerializeField, Tooltip("Time (seconds) between random changes in movement.")]
    private float directionChangeInterval = 1.0f;
    [SerializeField, Tooltip("Lowest random speed multiplier.")]
    private float randomSpeedMultiplierMin = 0.5f;
    [SerializeField, Tooltip("Highest random speed multiplier.")]
    private float randomSpeedMultiplierMax = 1.5f;

    [Header("Oscillatory Movement Settings")]
    [SerializeField, Tooltip("How far up and down the enemy moves.")]
    private float verticalAmplitude = 1f;
    [SerializeField, Tooltip("How fast the enemy oscillates up and down.")]
    private float verticalFrequency = 1f;

    // Used to offset the sine wave so enemies are not in sync.
    private float phaseOffset = 0f;
    private float startY;

    // Variables for random constant movement
    private float nextDirectionChangeTime = 0f;
    private float currentRandomVerticalSpeed = 0f;
    private int randomDirection = 1; // 1 for up, -1 for down

    private void Start()
    {
        // Save the initial vertical position.
        startY = transform.position.y;

        if (movementType == MovementType.Oscillatory)
        {
            // Start oscillation at a random point.
            phaseOffset = Random.Range(0f, 2 * Mathf.PI);
        }
        else if (movementType == MovementType.ConstantRandom)
        {
            // Randomize the start time for the first change.
            nextDirectionChangeTime = Time.time + Random.Range(0f, directionChangeInterval);
            SetRandomVerticalMovement();
        }
    }

    private void Update()
    {
        switch (movementType)
        {
            case MovementType.Constant:
                ConstantMovement();
                break;
            case MovementType.ConstantRandom:
                ConstantRandomMovement();
                break;
            case MovementType.Oscillatory:
                OscillatoryMovement();
                break;
            case MovementType.None:
            default:
                // No vertical movement.
                break;
        }
    }

    private void ConstantMovement()
    {
        float deltaY = 0f;

        if (moveUp && !moveDown)
        {
            deltaY = verticalSpeed * Time.deltaTime;
        }
        else if (moveDown && !moveUp)
        {
            deltaY = -verticalSpeed * Time.deltaTime;
        }
        transform.Translate(0f, deltaY, 0f);
    }

    private void ConstantRandomMovement()
    {
        if (Time.time >= nextDirectionChangeTime)
        {
            SetRandomVerticalMovement();
        }
        float deltaY = currentRandomVerticalSpeed * randomDirection * Time.deltaTime;
        transform.Translate(0f, deltaY, 0f);
    }

    private void OscillatoryMovement()
    {
        Vector3 pos = transform.position;
        pos.y = startY + Mathf.Sin((Time.time + phaseOffset) * verticalFrequency) * verticalAmplitude;
        transform.position = pos;
    }

    private void SetRandomVerticalMovement()
    {
        // Set the next time to change movement.
        nextDirectionChangeTime = Time.time + directionChangeInterval + Random.Range(0f, directionChangeInterval);
        // Randomize speed.
        currentRandomVerticalSpeed = verticalSpeed * Random.Range(randomSpeedMultiplierMin, randomSpeedMultiplierMax);
        // Randomly decide to move up or down.
        randomDirection = Random.value < 0.5f ? 1 : -1;
    }
}
