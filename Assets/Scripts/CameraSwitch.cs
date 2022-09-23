using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera = null;
    public Camera circlesCamera = null;

    private Vector3 lastMousePosition;

    public void SwitchToCircles()
    {
        mainCamera.enabled = false;
        circlesCamera.enabled = true;
    }

    public void SwitchToMicroscope()
    {
        mainCamera.enabled = true; ;
        circlesCamera.enabled = false;
    }

    private void OnMouseDown()
    {
        lastMousePosition = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        Vector3 delta = Input.mousePosition - lastMousePosition;
        if (delta == Vector3.zero && GSC.focusTarget == GSC.mainBody)
        {
            SwitchToCircles();
        }
    }
}
