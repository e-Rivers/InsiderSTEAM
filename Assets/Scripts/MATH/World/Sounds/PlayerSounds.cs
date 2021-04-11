using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    // Public attributes
    public static PlayerSounds instance;
    public AudioSource soundPlayer;
    public AudioClip[] shootingSounds;
    public AudioClip[] damageSounds;
    public AudioClip[] platformSounds;
    public AudioClip[] grabbingSounds;
    public AudioClip[] deathSounds;
    public AudioClip[] jumpingSounds;
    public AudioClip healSound;
    public AudioClip reloadPromptSound;
    public AudioClip reloadSound;

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
    public void PlayShotSound(int currBullets)
    {
        if (currBullets > 5)
        {
            soundPlayer.PlayOneShot(shootingSounds[Random.Range(0, shootingSounds.Length - 1)]);
        } else
        {
            soundPlayer.PlayOneShot(shootingSounds[shootingSounds.Length - 1]);
        }
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

    // Play healing sound
    public void PlayHeal()
    {
        soundPlayer.PlayOneShot(healSound);
    }

    // Play jumping sounds
    public void PlayJump()
    {
        soundPlayer.PlayOneShot(jumpingSounds[Random.Range(0, 2)]);
    }

    // Play grabbing sounds
    public void PlayGrab(int platformIdentifier)
    {
        switch (platformIdentifier)
        {
            
        }
    }

    // Play reload prompt sound
    public void PlayReloadPrompt()
    {
        soundPlayer.PlayOneShot(reloadPromptSound);
    }

    // Play reload sound
    public void PlayReload()
    {
        soundPlayer.PlayOneShot(reloadSound);
    }

}
