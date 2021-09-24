using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanZoom : MonoBehaviour
{
    private Vector3 _pressedMousePos;

    public void BeginDrag()
    {
        _pressedMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    public void Drag()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            Zoom(difference * 0.01f);
        } else
        {
            Vector3 direction = _pressedMousePos - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position += direction;
        }
    }
    private void Zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, 3, 7);
    }
    private void Update()
    {
        Zoom(Input.GetAxis("Mouse ScrollWheel") * 5);
    }
}
