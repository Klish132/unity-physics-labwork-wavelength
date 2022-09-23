using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsController : MonoBehaviour
{
    public Camera mainCamera = null;

    public GameObject mainBody = null;
    public GameObject cameraSwitch = null;

    public OrbitSphere mainOrbitSphere = null;

    public GameObject zoomoutButton = null;
    public GameObject goBackButton = null;
    
    // Start is called before the first frame update
    void Start()
    {
        mainOrbitSphere = GameObject.Find("MainOrbit").GetComponent<OrbitSphere>();
    }

    public void FocusOnMainBody()
    {
        mainBody.GetComponent<ObjectOfFocus>().Focus();
    }
    public void SwitchToMicroscope()
    {
        cameraSwitch.GetComponent<CameraSwitch>().SwitchToMicroscope();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainOrbitSphere.isActive == true || mainCamera.enabled == false)
        {
            zoomoutButton.SetActive(false);
        }
        else
        {
            zoomoutButton.SetActive(true);
        }

        if (mainCamera.enabled == false)
        {
            goBackButton.SetActive(true);
        }
        else
        {
            goBackButton.SetActive(false);
        }
    }
}
