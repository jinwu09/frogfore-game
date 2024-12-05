using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class PeelSimulation : MonoBehaviour
{
    public SpriteRenderer unpeeledSpriteRenderer;
    public Sprite peeledSprite;
    public int totalBrushStrokes = 10;
    public float peelSpeed = 0.1f;
    public UnityEvent onPeelingComplete;

    private int currentBrushStrokes = 0;
    private bool isPeeling = false;

    private void Start()
    {
        unpeeledSpriteRenderer.sprite = peeledSprite;
    }

    public void StartPeeling()
    {
        if (!isPeeling)
        {
            StartCoroutine(PeelPotato());
        }
    }

    private IEnumerator PeelPotato()
    {
        isPeeling = true;
        Color initialColor = unpeeledSpriteRenderer.color;
        Color targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0);

        while (currentBrushStrokes < totalBrushStrokes)
        {
            unpeeledSpriteRenderer.color = Color.Lerp(initialColor, targetColor, (float)currentBrushStrokes / totalBrushStrokes);
            currentBrushStrokes++;
            yield return new WaitForSeconds(peelSpeed);
        }

        // Set the sprite to peeled and invoke the event.
        unpeeledSpriteRenderer.sprite = peeledSprite;
        unpeeledSpriteRenderer.color = Color.white;

        if (onPeelingComplete != null)
        {
            onPeelingComplete.Invoke();
        }

        isPeeling = false;
    }
}
