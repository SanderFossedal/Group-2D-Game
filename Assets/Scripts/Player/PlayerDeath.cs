using UnityEngine;
using UnityEngine.Events;

public class PlayerDeath : MonoBehaviour
{
    //public bool PlayerIsDead = false;

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
        onPlayerDeath?.Invoke();
        gameObject.SetActive(false);
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
