using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomDuration = 2.0f; // Duration of the zoom in and out in seconds
    public float zoomedInFieldOfView = 30f; // Field of view when zoomed in
    public float zoomedOutFieldOfView = 60f; // Field of view when zoomed out

    private Camera mainCamera;
    private float originalFieldOfView;

    private void Start()
    {
        mainCamera = Camera.main;
        originalFieldOfView = mainCamera.fieldOfView;
    }

    public void ZoomInAndOut()
    {
        StartCoroutine(ZoomCoroutine());
    }

    private IEnumerator ZoomCoroutine()
    {
        // Zoom in
        float elapsedTime = 0f;
        float startFieldOfView = mainCamera.fieldOfView;
        while (elapsedTime < zoomDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / zoomDuration);
            mainCamera.fieldOfView = Mathf.Lerp(startFieldOfView, zoomedInFieldOfView, t);
            yield return null;
        }

        // Wait for a short moment at the zoomed-in state (you can adjust the duration as needed)
        yield return new WaitForSeconds(1.0f);

        // Zoom out
        elapsedTime = 0f;
        while (elapsedTime < zoomDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / zoomDuration);
            mainCamera.fieldOfView = Mathf.Lerp(zoomedInFieldOfView, zoomedOutFieldOfView, t);
            yield return null;
        }

        // Reset the camera's field of view to its original value
        mainCamera.fieldOfView = originalFieldOfView;
    }
}

