using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    // Public attributes
    public static PlayerSounds instance;
    public AudioSource soundPlayer;
    public AudioClip[] shootingSounds;
    public AudioClip[] damageSounds;
    public AudioClip[] platformSounds;
    public AudioClip[] deathSounds;

    // Start is called before first frame update
    private void Start()
    {
        instance = this;
    }

    // Play platform bouncing sounds
    public void PlatformSound(int platformIdentifier)
    {
        soundPlayer.PlayOneShot(platformSounds[platformIdentifier]);
    }

    // Play shooting sounds
    public void PlayShotSound()
    {
        soundPlayer.PlayOneShot(shootingSounds[Random.Range(0, shootingSounds.Length)]);
    }

    // Play damage sounds
    public void PlayDamage()
    {
        soundPlayer.PlayOneShot(damageSounds[Random.Range(0, damageSounds.Length)]);
    }

    // Play death sounds
    public void PlayDeath()
    {
        soundPlayer.PlayOneShot(deathSounds[Random.Range(0, deathSounds.Length)]);
    }
}
