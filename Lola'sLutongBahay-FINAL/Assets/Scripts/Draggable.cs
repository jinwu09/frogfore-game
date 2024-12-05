using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector3 offset;
    public float rotateSpeed = 10f; // The speed of rotation
    public bool canRotate = true; // Flag to enable/disable rotation

    private Vector3 mousePosPrev; // The previous mouse position

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        mousePosPrev = Vector3.zero;
    }

    private void OnMouseDrag()
    {
        Vector3 cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 cursorWorldPoint = Camera.main.ScreenToWorldPoint(cursorScreenPoint);
        transform.position = cursorWorldPoint + offset;

        //rotate

        if (!canRotate)
            return;

        Vector3 mousePos = Input.mousePosition;
        if (mousePosPrev != Vector3.zero)
        {
            float deltaX = mousePos.x - mousePosPrev.x;
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.forward, -rotateSpeed * Time.deltaTime);
            }
        }
        mousePosPrev = mousePos;
    }
}