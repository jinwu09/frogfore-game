using UnityEngine;

public class SpriteHover : MonoBehaviour
{
    public Material shadeMaterial; // Reference to the shade material

    private Material originalMaterial; // Reference to the original material

    private void Start()
    {
        // Store the original material of the sprite
        var spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalMaterial = spriteRenderer.material;
        }
    }

    private void OnMouseEnter()
    {
        // Check if the shade material is assigned and the sprite has a renderer
        if (shadeMaterial != null && originalMaterial != null)
        {
            var spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                // Activate the shade material
                spriteRenderer.material = shadeMaterial;
            }
        }
    }

    private void OnMouseExit()
    {
        // Check if the sprite has a renderer
        if (originalMaterial != null)
        {
            var spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                // Deactivate the shade material and revert back to the original material
                spriteRenderer.material = originalMaterial;
            }
        }
    }
}
