using UnityEngine;
using UnityEngine.Events;

public class PlayerDeath : MonoBehaviour
{
    //public bool PlayerIsDead = false;
    public GameObject deadPlayer;
    public UnityEvent onPlayerDeath;

    private void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            
            Die();
        }
    }

    private void Die()
    {
        deadPlayer.transform.SetParent(null); // Unparent before enabling
        deadPlayer.SetActive(true);
        onPlayerDeath?.Invoke();
        gameObject.SetActive(false);
    }

   

    private void Start()
    {
        
    }
    private void Update()
    {
        //Debug purpose
        if (Input.GetKeyDown(KeyCode.Delete))
        {

            Die();
        }
    }
}
