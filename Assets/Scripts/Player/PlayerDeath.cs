using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDeath : MonoBehaviour
{
    //public bool PlayerIsDead = false;
    public GameObject deadPlayer;
    public UnityEvent onPlayerDeath;
    private GameObject collidedEnemy;
    public HorizontalMovement horizontalMovement;

    private void Start()
    {
        horizontalMovement.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D enemy)
    {
        collidedEnemy = enemy.gameObject;
        if (enemy.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            Die();
        }
    }

    private void Die()
    {
        DeadPlayerBehavior();
        onPlayerDeath?.Invoke();
        gameObject.SetActive(false);
    }

   private void DeadPlayerBehavior()
    {
        deadPlayer.transform.SetParent(null); // Unparent before enabling

        if (collidedEnemy != GameObject.Find("Wall Bottom"))
        {
            deadPlayer.transform.SetParent(collidedEnemy.transform); // Reparent to the collided enemy
            horizontalMovement.enabled = false;
        }
        if (collidedEnemy == GameObject.Find("Wall Bottom"))
        {
            horizontalMovement.enabled = true;

        }

        deadPlayer.SetActive(true);
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
