using UnityEngine;

[CreateAssetMenu(fileName = "New Sound", menuName = "ScriptableObjects/Create Sounds")]
public class Sound : ScriptableObject
{
    // The audio clip to play.
    public AudioClip clip;

    // The base volume of the sound.
    [Range(0f, 1f)]
    public float volume = 1f;

    // The base pitch of the sound.
    public float pitch = 1f;

    // How much the pitch can vary randomly.
    public float pitchVariance = 0.1f;
}
