using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onion : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Slice(Vector2 slicerPosition)
    {
        // Get the onion's current sprite bounds
        Bounds onionBounds = spriteRenderer.bounds;
        Vector2 min = onionBounds.min;
        Vector2 max = onionBounds.max;

        // Determine the slicing position on the onion
        float slicePositionX = slicerPosition.x;
        float slicePositionY = slicerPosition.y;

        // Calculate the slice position relative to the onion's bounds
        float relativeX = Mathf.InverseLerp(min.x, max.x, slicePositionX);
        float relativeY = Mathf.InverseLerp(min.y, max.y, slicePositionY);

        // Create a new sprite with sliced texture based on the slice position
        Texture2D texture = spriteRenderer.sprite.texture;
        Rect rect = new Rect(0, 0, texture.width * relativeX, texture.height * relativeY);
        Sprite slicedSprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));

        // Set the sliced sprite to the onion
        spriteRenderer.sprite = slicedSprite;
    }
}

