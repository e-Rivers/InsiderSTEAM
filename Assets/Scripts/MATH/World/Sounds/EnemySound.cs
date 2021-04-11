using UnityEngine;

public class EnemySound : MonoBehaviour
{

    // Sounds that are able to be played
    public GameObject soundSourceGameObject;
    public AudioClip[] deathSounds;
    public AudioClip[] damageSounds;

    // Private attributes
    private AudioSource soundSource;


    private void Awake()
    {
        soundSourceGameObject = GameObject.Find("MainSoundSource");
        soundSource = soundSourceGameObject.GetComponent<AudioSource>();
    }

    public void PlayDeath()
    {
        if (EnemyControl.instance.canTriggerSounds)
        {
            soundSource.PlayOneShot(deathSounds[Random.Range(0, deathSounds.Length)]);
        }
    }

    public void PlayDamage()
    {
        if (EnemyControl.instance.canTriggerSounds)
        {
            soundSource.PlayOneShot(damageSounds[Random.Range(0, damageSounds.Length)]);
        }
    }
}
