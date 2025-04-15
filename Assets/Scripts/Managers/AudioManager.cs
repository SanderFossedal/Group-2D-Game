using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    // Store the sound Scriptable Objects in an array to be assigned via the Inspector.
    public Sound[] sounds;

    // Use a dictionary for fast lookup by sound name.
    private Dictionary<string, Sound> soundDictionary;

    private void Awake()
    {
        // Establish the Singleton. If an instance already exists, destroy this one.
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Populate the dictionary with names as keys.
        soundDictionary = new Dictionary<string, Sound>();
        foreach (Sound sound in sounds)
        {
            if (sound != null && !soundDictionary.ContainsKey(sound.name))
            {
                soundDictionary.Add(sound.name, sound);
            }
            else if (sound == null)
            {
                Debug.LogWarning("One of the sounds in AudioManager is not assigned!");
            }
        }
    }

    /// <summary>
    /// Plays a sound using its name.
    /// </summary>
    /// <param name="soundName">The name of the Sound object to play.</param>
    /// <param name="position">The position where the sound will play.</param>
    public void PlaySound(string soundName, Vector3 position)
    {
        if (soundDictionary.TryGetValue(soundName, out Sound sound))
        {
            // Create a temporary GameObject to play the sound.
            GameObject soundGameObject = new GameObject("Sound_" + soundName);
            soundGameObject.transform.position = position;

            // Add an AudioSource component and configure it using the SO settings.
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.clip = sound.clip;
            audioSource.volume = sound.volume;
            audioSource.pitch = sound.pitch + Random.Range(-sound.pitchVariance, sound.pitchVariance);
            audioSource.Play();

            // Destroy the GameObject once the sound has finished playing.
            Destroy(soundGameObject, sound.clip.length / audioSource.pitch);
        }
        else
        {
            Debug.LogWarning("Sound with name " + soundName + " not found!");
        }
    }

}
