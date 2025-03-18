using Unity.VisualScripting;
using UnityEngine;

public class PoopOnHit : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            // add XP here
            
            Destroy(this.gameObject);
        }
        else
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
            {
                Destroy(this.gameObject);
            }
            
        }
    }
}
