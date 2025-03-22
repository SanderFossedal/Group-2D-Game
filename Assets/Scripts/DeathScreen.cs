using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    //public PlayerDeath playerDeath;
    [SerializeField] private GameObject deathScreen;


    // Update is called once per frame
    //void Update()
    //{
    //    if(playerDeath.PlayerIsDead == true)
    //    {
    //        deathScreen.SetActive(true);
    //    }
    //}

    public void TurnOnDeathScreen()
    {
        deathScreen.SetActive(true);
    }

    public void TurnOffDeathScreen()
    {
        deathScreen.SetActive(false);
    }
}
