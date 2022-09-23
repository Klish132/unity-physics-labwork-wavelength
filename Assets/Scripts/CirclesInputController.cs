using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CirclesInputController : MonoBehaviour
{    
    public Camera circlesCamera = null;

    public double currentMeasure = 27;

    private float maxRadius;
    private float totalDistMoved;

    // 0.01 unit = 0.001 mm
    private float cameraMeasure = 0.01f;
    // 0.001 mm = 0.001 unit
    private float microscopeMeasure = 0.001f;
    // 0.001 mm = 0.36 degrees
    private float rotatorMeasure = -0.36f;

    private Text currentMeasureText = null;

    private void Start()
    {
        maxRadius = GameObject.Find("CircleDark11").transform.localScale.y / 20f;
        currentMeasureText = GameObject.Find("CurrentMeasureField").GetComponentInChildren<Text>();
    }

    public void SetCameraSize(float scale)
    {
        circlesCamera.orthographicSize = scale / 2f;
    }

    void MoveCircles(int dirModifier, float distMultiplier = 1)
    {
        float distMoved = dirModifier * 0.001f * distMultiplier;
        if (totalDistMoved + distMoved > -maxRadius && totalDistMoved + distMoved < maxRadius)
        {
            totalDistMoved += distMoved;
            GSC.cameraSlide.transform.position += new Vector3(dirModifier * cameraMeasure * distMultiplier, 0, 0);
            GSC.microscope.transform.localPosition += new Vector3(dirModifier * microscopeMeasure * distMultiplier, 0, 0);
            GSC.rotator.transform.localRotation *= Quaternion.Euler(dirModifier * rotatorMeasure * distMultiplier, 0, 0);
            currentMeasure += distMoved;
            currentMeasureText.text = currentMeasure.ToString("F4") + " μμ.";
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("left"))
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                MoveCircles(-1, 4);
            else
                MoveCircles(-1);
        }
        if (Input.GetKey("right"))
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                MoveCircles(1, 4);
            else
                MoveCircles(1);
        }
    }
}
