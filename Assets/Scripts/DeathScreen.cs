using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public PlayerDeath playerDeath;
    public GameObject deathScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerDeath.PlayerIsDead == true)
        {
            deathScreen.SetActive(true);
        }
    }
}
