using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;

public class SlideCutting : MonoBehaviour
{
    private Vector2 touchStartPosition;
    private bool isSwipeCompleted = true;
    private bool allSpritesDisplayed = false;

    public Sprite[] sprites; // Assign the sprites in the Inspector
    private int currentSpriteIndex = 0;
    [SerializeField] Animator animator;
    [SerializeField] string anitrigger;
    public RecipeManager recipeManager;
    [SerializeField] string actionName;
    [SerializeField] AudioSource CutSound;
    [SerializeField] UnityEvent actionEvent;

    private void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPosition = touch.position;
                isSwipeCompleted = false;
            }
            else if (touch.phase == TouchPhase.Ended && !isSwipeCompleted)
            {
                Vector2 touchDelta = touch.position - touchStartPosition;

                // Detect slide down motion
                if (touchDelta.y < -10f)
                {
                    // Move to the next sprite for the next swipe
                    currentSpriteIndex++;
                    animator.SetTrigger(anitrigger);
                    CutSound.Play();

                    // If we reached the last sprite, set allSpritesDisplayed to true
                    if (currentSpriteIndex >= sprites.Length)
                    {
                        currentSpriteIndex = sprites.Length - 1;
                        allSpritesDisplayed = true;
                        PerformTask();
                        recipeManager.playerActions.Add(actionName);
                        actionEvent.Invoke();
                    }

                    // Change the sprite
                    ChangeSprite(currentSpriteIndex);
                }

                // Mark swipe as completed
                isSwipeCompleted = true;
            }
        }
    }

    private void ChangeSprite(int index)
    {
        // Check if the index is within the sprites array bounds
        if (index >= 0 && index < sprites.Length)
        {
            // Set the current sprite
            GetComponent<SpriteRenderer>().sprite = sprites[index];
        }
    }

    // Called when all sprites have been shown
    private void PerformTask()
    {
        Debug.Log("All sprites displayed. Performing task!");
    }

    private void OnEnable()
    {
        // Reset the state when the object becomes enabled
        currentSpriteIndex = 0;
        allSpritesDisplayed = false;
        isSwipeCompleted = true;
        ChangeSprite(currentSpriteIndex);
    }

    private void OnDisable()
    {
        // Reset the state when the object becomes disabled
        currentSpriteIndex = 0;
        allSpritesDisplayed = false;
        isSwipeCompleted = true;
    }
}