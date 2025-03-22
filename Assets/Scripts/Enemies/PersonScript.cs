using UnityEngine;

public class PersonScript : MonoBehaviour
{

    [SerializeField]
    private float walkSpeed;


    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * walkSpeed * Time.deltaTime);

    }
}
