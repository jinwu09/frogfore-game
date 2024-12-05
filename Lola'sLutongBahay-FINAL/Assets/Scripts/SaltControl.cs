using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SaltControl : MonoBehaviour
{
    private Vector3 originalPosition;
    private bool isDragging = false;
    private bool isReleased = false;

    public Collider2D targetCollider;
    public ParticleSystem saltparticleSystem;
    public string actionName;
    public ServingManager servingManager;
    public RecipeManager recipeManager;
    [SerializeField] AudioSource SaltPlay;
    [SerializeField] UnityEvent DragActionEvent;
    private float smoothTime = 11.22f;
    float r;

    private void Start()
    {
        saltparticleSystem.Stop();
        originalPosition = transform.position;
    }

    private void OnMouseDown()
    {
        isDragging = true;
        isReleased = false;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 newPosition = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);

            transform.position = newPosition;
        }
    }

    private void OnMouseUp()
    {
        if (isDragging)
        {
            isReleased = true;
            isDragging = false;
        }
        if (targetCollider != null)
        {
            // Check if the dropped position is inside the collider
            if (targetCollider.bounds.Contains(transform.position))
            {
                Debug.Log("Inside");
                // Play the particle system
                if (saltparticleSystem != null)
                {
                    saltparticleSystem.Stop();
                }
                if (servingManager == null) 
                {
                    recipeManager.playerActions.Add(actionName);
                    string result = recipeManager.CheckSequence();
                    Debug.Log(result);
                }
                else
                {
                    servingManager.playerActions.Add(actionName);
                    string result = servingManager.CheckSequence();
                    Debug.Log(result);
                }
                DragActionEvent.Invoke();
            }
        }
    }

    private void Update()
    {
        if (isReleased)
        {
            // Smoothly move the sprite back to its original position
            transform.position = Vector3.Lerp(transform.position, originalPosition, smoothTime * Time.deltaTime);
            saltparticleSystem.Stop();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDragging)
        {
            Debug.Log("In");
            saltparticleSystem.Play();
            PlayAudio();
            targetCollider = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (isDragging && other == targetCollider)
        {
            Debug.Log("Out");
            targetCollider = null;
            saltparticleSystem.Stop();
            StopAudio();
        }
    }

    private void PlayAudio()
    {
        // Check if the default AudioClip is set.
        if (SaltPlay != null)
        {
            SaltPlay.Play();
        }
        else
        {
            Debug.LogWarning("Default AudioClip is not set.");
        }
    }
    private void StopAudio()
    {
        // Check if the default AudioClip is set.
        if (SaltPlay != null)
        {
            SaltPlay.Stop();
        }
        else
        {
            Debug.LogWarning("Default AudioClip is not set.");
        }
    }
}

