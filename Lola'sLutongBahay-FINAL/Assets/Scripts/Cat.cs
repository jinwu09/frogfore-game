using UnityEngine;

public class Cat : MonoBehaviour
{
    private Animator catAnimator;
    private AudioSource catAudio;

    void Start()
    {
        // Get the Animator component attached to the cat object
        catAnimator = GetComponent<Animator>();

        // Get the AudioSource component attached to the cat object
        catAudio = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        // If the cat is clicked or tapped, trigger the animation and play the sound
        catAnimator.SetTrigger("TapTrigger");
        catAudio.Play();
    }
}
