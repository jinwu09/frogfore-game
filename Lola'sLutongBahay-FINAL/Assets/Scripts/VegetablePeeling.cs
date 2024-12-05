using UnityEngine;

public class VegetablePeeling : MonoBehaviour
{
    public Transform brush; // The GameObject representing the brush.
    public LayerMask vegetableLayer; // The layer of the vegetable.

    private bool isBrushing = false;
    private Collider2D vegetableCollider;

    private void Start()
    {
        vegetableCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        // Detect mouse input (e.g., mouse click or touch) to control the brush.
        if (Input.GetMouseButtonDown(0))
        {
            StartBrushing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopBrushing();
        }

        if (isBrushing)
        {
            MoveBrush();
        }
    }

    private void StartBrushing()
    {
        isBrushing = true;
    }

    private void StopBrushing()
    {
        isBrushing = false;
    }

    private void MoveBrush()
    {
        Vector3 brushPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        brush.position = new Vector3(brushPosition.x, brushPosition.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isBrushing && other == vegetableCollider)
        {
            // Reveal the inner layer by enabling it or modifying the mask component.
            // For example, set the second sprite to be active.
            // innerLayerSpriteRenderer.enabled = true;

            // You can also adjust the mask component to reveal the inner layer as the brush moves.
        }
    }
}
