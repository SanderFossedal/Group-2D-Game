using Unity.VisualScripting;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public bool PlayerIsDead = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            Death();
        }
    }

    private void Death()
    {
        PlayerIsDead = true;
        this.gameObject.SetActive(false);
        
    }
}
