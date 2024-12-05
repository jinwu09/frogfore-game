using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwipeUpDetector : MonoBehaviour
{
    public Animator animator;
    private Vector2 swipeStartPos;
    private Vector2 swipeEndPos;
    public RecipeManager recipeManager;
    [SerializeField] string actionName;
    [SerializeField] string triggeranimation;
    [SerializeField] CookingController CookFlip;

    public UnityEvent EggFlipOmeletEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
        {
            swipeStartPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            swipeEndPos = Input.mousePosition;
            DetectSwipe();
        }
    }

    void DetectSwipe()
    {
        Vector2 swipeDirection = (swipeEndPos - swipeStartPos).normalized;

        if (swipeDirection.y > 0.5f && Mathf.Abs(swipeDirection.x) < 0.3f)
        {
            // Upward swipe detected, initiate omelet flipping
            FlipOmelet();
            CookFlip.isAdded = true;
        }
    }

    void FlipOmelet()
    {
        EggFlipOmeletEvent.Invoke();
        animator.SetTrigger(triggeranimation);
        recipeManager.playerActions.Add(actionName);
    }
}
