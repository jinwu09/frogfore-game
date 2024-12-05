using UnityEngine;

public class BrushPeel : MonoBehaviour
{
    public PeelSimulation potato;

    private void OnMouseDown()
    {
        if (potato != null)
        {
            potato.StartPeeling();
        }
    }
}
