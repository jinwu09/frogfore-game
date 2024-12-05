using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public List<Sprite> sprites; // List of sprites to change through on swipe left
    private int currentSpriteIndex = 0;
    private Vector2 startPos;
    private Vector2 direction;
    private bool isSwiping = false;

    private void Update()
    {
        // Detect swipe gesture
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            isSwiping = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            direction = (Vector2)Input.mousePosition - startPos;
            isSwiping = false;

            // Check if the swipe is left
            if (direction.x < 0 && direction.magnitude > 50f)
            {
                ChangeSpriteLeft();
            }
        }
    }

    private void ChangeSpriteLeft()
    {
        currentSpriteIndex = (currentSpriteIndex + 1) % sprites.Count;
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        // Assuming you have a SpriteRenderer component attached to the GameObject
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null && currentSpriteIndex < sprites.Count)
        {
            spriteRenderer.sprite = sprites[currentSpriteIndex];
        }
    }
}
