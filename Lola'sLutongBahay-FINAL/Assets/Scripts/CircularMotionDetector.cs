using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CircularMotionDetector : MonoBehaviour
{
    public RecipeManager recipeManager;

    private Vector2 touchStartPosition;
    private int circularMotionCount = 0;
    private bool isPerformingAction = false;
    public string actionName;


    [SerializeField] UnityEvent MixActionEvent;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isPerformingAction = true;
                touchStartPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved && isPerformingAction)
            {
                // Calculate the angle between the current touch position and the start position
                Vector2 direction = touch.position - touchStartPosition;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                // Normalize the angle to avoid sudden changes in angle caused by crossing the 0-degree boundary
                angle = (angle + 360) % 360;

                // Check if the angle forms a circular motion
                if (Mathf.Abs(angle) >= 350 || Mathf.Abs(angle) <= 10)
                {
                    // Increment circular motion count
                    circularMotionCount++;
                }
                else
                {
                    // Reset circular motion count if the motion is not continuous
                    circularMotionCount = 0;
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                if (circularMotionCount >= 1)
                {
                    // Perform your action here (e.g., call a method)
                    mixgisa();
                }

                // Reset circular motion count
                circularMotionCount = 0;
                isPerformingAction = false;
            }
        }
        }

        private void mixgisa()
        {
            recipeManager.playerActions.Add(actionName);
            string result = recipeManager.CheckSequence();
            Debug.Log(result);
            MixActionEvent.Invoke();
        }
    }

