using UnityEngine;

public class EnemyCrane : MonoBehaviour
{
    [SerializeField]
    private float craneSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * craneSpeed * Time.deltaTime);

    }
}
