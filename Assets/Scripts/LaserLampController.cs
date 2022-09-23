using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLampController : MonoBehaviour
{
    public GameObject redLamp;
    public GameObject greenLamp;
    public GameObject blueLamp;

    public void EnableRedLamp()
    {
        redLamp.SetActive(true);
        greenLamp.SetActive(false);
        blueLamp.SetActive(false);
    }
    public void EnableGreenLamp()
    {
        redLamp.SetActive(false);
        greenLamp.SetActive(true);
        blueLamp.SetActive(false);
    }
    public void EnableBlueLamp()
    {
        redLamp.SetActive(false);
        greenLamp.SetActive(false);
        blueLamp.SetActive(true);
    }
}
