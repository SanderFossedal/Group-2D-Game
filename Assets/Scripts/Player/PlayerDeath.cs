using UnityEngine;
using UnityEngine.Events;

public class PlayerDeath : MonoBehaviour
{
    //public bool PlayerIsDead = false;

    public UnityEvent onPlayerDeath;

    //private void OnCollisionEnter2D(Collision2D enemy)
    //{
    //    if (enemy.gameObject.layer == LayerMask.NameToLayer("Enemies"))
    //    {
    //        Death();
    //    }
    //}

    private void Die()
    {
        onPlayerDeath?.Invoke();
    }

    private void Update()
    {
        //Debug purpose
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            gameObject.SetActive(false);
            Die();
        }
    }
}
