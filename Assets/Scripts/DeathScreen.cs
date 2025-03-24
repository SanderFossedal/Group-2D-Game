using System.Collections;
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

    private void Start()
    {

        
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);  // Wait for 1 second
        deathScreen.SetActive(true);
        Debug.Log("1 second passed!");
    }

    public void TurnOnDeathScreen()
    {
        StartCoroutine(Delay());
        
    }

    public void TurnOffDeathScreen()
    {
        deathScreen.SetActive(false);
    }
}
