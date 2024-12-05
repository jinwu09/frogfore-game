using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TouchMotionDetection : MonoBehaviour
{
    public Slider uiSlider;
    public float requiredValueCount = 10;
    public UnityEvent onRequiredValueReached;
    [SerializeField] ServingManager recipeManager;
    [SerializeField] string actionName;
    [SerializeField] Animator touchAnimator;

    private float currentValue = 0;
    private bool isTouching = false;

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            // Check if a touch just began
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                touchAnimator.SetBool("mixing", true);
                isTouching = true;
            }

            // Check if the screen is being touched and held
            if (isTouching)
            {
                // Increase the value
                currentValue++;

                // Update the UI Slider
                if (uiSlider != null)
                {
                    uiSlider.value = currentValue;
                }

                // Check if the required value count is reached
                if (currentValue >= requiredValueCount)
                {
                    // Invoke the Unity event
                    if (onRequiredValueReached != null)
                    {
                        onRequiredValueReached.Invoke();
                        recipeManager.playerActions.Add(actionName);
                        string result = recipeManager.CheckSequence();
                    }
                }
            }
            // Check if touch is released
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                isTouching = false;
                touchAnimator.SetBool("mixing", false);
            }
        }
    }
}
