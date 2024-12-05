using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSpot : MonoBehaviour
{
    public ParticleSystem saltyparticleSystem;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Draggable") && Input.GetMouseButtonUp(0))
        {
            // Activate particle system
            saltyparticleSystem.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Draggable"))
        {
            // Deactivate particle system
            saltyparticleSystem.Stop();
            saltyparticleSystem.Clear();
        }
    }
}

