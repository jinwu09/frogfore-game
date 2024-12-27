using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class HoverTrigger : MonoBehaviour
{
    private Animator animator;
    private bool isCooldownActive = false; // To track if cooldown is active
    private float cooldownTime = 0.5f; // Time delay in seconds (adjustable)

    [Tooltip("Animator trigger for hovering.")]
    public string hoverTrigger = "Hover";

    [Tooltip("Animator trigger for idle state.")]
    public string idleTrigger = "Idle";

    void Start()
    {
        // Cache the Animator component
        animator = GetComponent<Animator>();
    }

    // Triggered when the mouse enters the 2D collider
    void OnMouseEnter()
    {
        if (!isCooldownActive)
        {
            if (animator != null && !string.IsNullOrEmpty(hoverTrigger))
            {
                animator.SetTrigger(hoverTrigger); // Trigger hover animation
            }
        }
    }

    // Triggered when the mouse exits the 2D collider
    void OnMouseExit()
    {
        if (!isCooldownActive)
        {
            if (animator != null && !string.IsNullOrEmpty(idleTrigger))
            {
                animator.SetTrigger(idleTrigger); // Trigger idle animation
            }

            // Start the cooldown to prevent immediate re-entry animation
            StartCoroutine(CooldownCoroutine());
        }
    }

    // Coroutine for cooldown delay
    private IEnumerator CooldownCoroutine()
    {
        isCooldownActive = true; // Set cooldown to active
        yield return new WaitForSeconds(cooldownTime); // Wait for the cooldown duration
        isCooldownActive = false; // Reset cooldown after time has passed
    }
}
