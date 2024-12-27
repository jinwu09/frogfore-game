using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverAnimationHandler : MonoBehaviour
{
    private AudioSource audioSource;

    [Tooltip("Sound to play on hover.")]
    public AudioClip hoverSound;

    private bool soundPlayed = false;  // Flag to check if sound has been played

    private void Start()
    {
        // Each item gets its own AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Triggered by Animation Event
    public void PlayHoverSound()
    {
        // Check if sound has already been played
        if (hoverSound != null && audioSource != null && !soundPlayed)
        {
            audioSource.PlayOneShot(hoverSound);
            soundPlayed = true; // Set flag to true to prevent re-triggering
        }
    }

    // Optional: Reset soundPlayed flag when hover ends, if needed for re-triggering
    public void ResetSoundPlayed()
    {
        soundPlayed = false;
    }
    void OnMouseExit()
    {
        ResetSoundPlayed();
    }
}