using UnityEngine;

public class ParticleToggle : MonoBehaviour
{
    public static ParticleToggle instance;
    public ParticleSystem fireparticleSystem; // Reference to the Particle System component
    public ParticleSystem particleSystem2;
    private bool isActive = false; // Flag to track activation state
    private float degrees = 90;
    public EggCooking egg;

    private void Start()
    {
        fireparticleSystem.Stop();
        particleSystem2.Stop();
    }
    private void Update()
    {
        egg = FindObjectOfType<EggCooking>(); // Automatically find and assign MyScript during Awake
    }

    private void OnMouseDown()
    {
        egg.isCooking = !egg.isCooking;

        if (egg.isCooking)
            Debug.Log("Egg cooking has started.");
        else
            Debug.Log("Egg cooking has stopped.");

        // Toggle particle system activation
        if (fireparticleSystem != null)
        {
            isActive = !isActive;

            if (isActive)
            {
                fireparticleSystem.Play();
                particleSystem2.Play();
                transform.eulerAngles = Vector3.forward * degrees;
            }
            else
            {
                fireparticleSystem.Stop();
                particleSystem2.Stop();
                transform.rotation = Quaternion.identity;
            }
        }
    }
}
