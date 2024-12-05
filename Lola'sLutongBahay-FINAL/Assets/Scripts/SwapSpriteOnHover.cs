using UnityEngine;

public class SwapSpriteOnHover : MonoBehaviour
{
    public Sprite swappedSprite; // The sprite to use when swapping
    public float swapInterval = 0.5f; // The interval between sprite swaps

    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component
    private Sprite originalSprite; // The original sprite of the game object
    private float lastSwapTime; // The last time a sprite swap occurred

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite;
        lastSwapTime = Time.time;
    }

    private void Update()
    {
        if (spriteRenderer.sprite != originalSprite && Time.time - lastSwapTime > swapInterval)
        {
            spriteRenderer.sprite = originalSprite;
            lastSwapTime = Time.time;
        }
    }

    private void OnMouseEnter()
    {
        spriteRenderer.sprite = swappedSprite;
    }

    private void OnMouseExit()
    {
        spriteRenderer.sprite = originalSprite;
    }
}
