using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RotateOnTouch : MonoBehaviour
{
    private bool isRotating = false;
    private Vector3 lastTouchPosition;
    public RecipeManager recipeManager;
    [SerializeField] string actionName;

    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float rotationThreshold = 360f;

    public UnityEvent OnRotationComplete;

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = new Vector3(touch.position.x, touch.position.y, transform.position.z); // Convert touch position to a Vector3

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    isRotating = true;
                    lastTouchPosition = touchPosition; // Store the converted touch position
                    break;

                case TouchPhase.Moved:
                    if (isRotating)
                    {
                        Vector3 deltaTouchPosition = touchPosition - lastTouchPosition;
                        float rotationAmount = deltaTouchPosition.x * rotationSpeed * Time.deltaTime;
                        transform.Rotate(Vector3.forward, rotationAmount);

                        lastTouchPosition = touchPosition;

                        if (Mathf.Abs(transform.eulerAngles.z) >= rotationThreshold)
                        {
                            isRotating = false;
                            transform.eulerAngles = new Vector3(0, 0, 0); // Reset rotation
                            recipeManager.playerActions.Add(actionName);
                            OnRotationComplete.Invoke(); // Trigger the event when rotation completes
                        }
                    }
                    break;

                case TouchPhase.Ended:
                    isRotating = false;
                    break;
            }
        }
    }
}
