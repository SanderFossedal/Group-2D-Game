using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip deathSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
