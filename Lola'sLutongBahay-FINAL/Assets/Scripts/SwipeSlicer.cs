using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeSlicer : MonoBehaviour
{
    private Vector2 touchStartPosition;
    private Vector2 touchEndPosition;

    private const float minSwipeDistance = 50f;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchStartPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            touchEndPosition = Input.GetTouch(0).position;
            DetectSwipeDirection();
        }
    }

    private void DetectSwipeDirection()
    {
        float swipeDistance = (touchEndPosition - touchStartPosition).magnitude;

        if (swipeDistance > minSwipeDistance)
        {
            Vector2 swipeDirection = (touchEndPosition - touchStartPosition).normalized;

            // Check if the swipe is mainly vertical (up or down)
            if (Mathf.Abs(swipeDirection.y) > Mathf.Abs(swipeDirection.x))
            {
                if (swipeDirection.y > 0)
                {
                    // Swipe up - Perform the slice action
                    PerformSlice(Vector2.up);
                }
                else
                {
                    // Swipe down - Perform the slice action
                    PerformSlice(Vector2.down);
                }
            }
        }
    }

    private void PerformSlice(Vector2 direction)
    {
        // Raycast in the swipe direction to detect collision with the Onion
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1f);

        if (hit.collider != null && hit.collider.CompareTag("Onion"))
        {
            Onion onion = hit.collider.GetComponent<Onion>();
            onion.Slice(transform.position);
        }
    }
}

