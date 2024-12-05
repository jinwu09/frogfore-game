using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoubleTapAnimation : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component on the GameObject
    public string actionName;
    public ServingManager recipeManager;
    private float doubleTapTimeThreshold = 0.2f; // Adjust this value to control the double-tap speed
    private float lastTapTime = 0f;

    private Vector2 touchStartPosition;
    //private float circularMotionThreshold = 30f; // Adjust this value as needed to detect circular motion
    [SerializeField] UnityEvent CrackEggActionEvent;

    private void Start()
    {
        // Get the Animator component if it's not assigned in the Inspector
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check for double-tap
            if (touch.phase == TouchPhase.Began)
            {
                if (Time.time - lastTapTime < doubleTapTimeThreshold)
                {
                    crackegg();
                }

                lastTapTime = Time.time;
            }
        }

    }

    private void crackegg()
    {
        // Trigger the "PlayAnimation" parameter in the Animator
        recipeManager.playerActions.Add(actionName);
        string result = recipeManager.CheckSequence();
        Debug.Log(result);
        CrackEggActionEvent.Invoke();
    }
}

