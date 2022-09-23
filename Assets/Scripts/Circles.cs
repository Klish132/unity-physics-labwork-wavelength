using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Circles : MonoBehaviour
{
    private int color_id;
    private float top_circle_const;
    private float radius_bright;
    private float radius_dark;

    private int circleScale = 20;

    public Text curvatureText;

    public GameObject circlesScene = null;

    public GameObject darkCirclePrefab = null;
    public GameObject redCirclePrefab = null;
    public GameObject greenCirclePrefab = null;
    public GameObject blueCirclePrefab = null;

    private GameObject[] circleArray;
    void Start()
    {
        System.Random rnd = new System.Random();
        GSC.lensCurvature = rnd.Next(150, 251) / 10f;
        curvatureText.text = curvatureText.text + GSC.lensCurvature.ToString();
        top_circle_const = rnd.Next(1, 6) / 10f;

        circleArray = new GameObject[23];

        // 1 = Red, 2 = Green, 3 = Blue
        color_id = rnd.Next(1, 4);
        switch (color_id)
        {
            // 650nm +- 1%
            case 1:
                GSC.waveLength = rnd.Next(6435, 6565) / 10f;
                GenerateCircles(redCirclePrefab);
                GameObject.Find("LaserLampController").GetComponent<LaserLampController>().EnableRedLamp();
                break;
            // 568nm +- 1%
            case 2:
                GSC.waveLength = rnd.Next(56232, 57368) / 100f;
                GenerateCircles(greenCirclePrefab);
                GameObject.Find("LaserLampController").GetComponent<LaserLampController>().EnableGreenLamp();
                break;
            // 492nm +- 1%
            case 3:
                GSC.waveLength = rnd.Next(48708, 49692) / 100f;
                GenerateCircles(blueCirclePrefab);
                GameObject.Find("LaserLampController").GetComponent<LaserLampController>().EnableBlueLamp();
                break;
        }
        float top_circle_radius = (float)GenerateTopCircleRadius(GSC.lensCurvature, GSC.waveLength) * circleScale;
        circleArray[0] = GenerateCircle(darkCirclePrefab, 0, 0, top_circle_radius);

        CirclesInputController circlesInputController = GameObject.Find("CirclesInputController").GetComponent<CirclesInputController>();
        circlesInputController.SetCameraSize(circleArray[22].transform.localScale.y);
    }

    // dark_bright_indicator = 1 for dark, -1 for bright
    private double GenerateCircleRadius(double lc, double wl, int m, int dark_bright_indicator)
    {
        return (0.01 / 2f) * (System.Math.Sqrt(0.1 * lc * m * wl) + System.Math.Sqrt(0.1 * lc * (2 * m + dark_bright_indicator) * wl / 2f));
    }
    private double GenerateTopCircleRadius(double lc, double wl)
    {
        return (top_circle_const * 0.01 / 2f) * (System.Math.Sqrt(0.1 * lc * wl) * (1 + (1 / System.Math.Sqrt(2))));
    }

    private GameObject GenerateCircle(GameObject coloredPrefab, float y, int m, float radius)
    {
        GameObject circle = Instantiate(coloredPrefab) as GameObject;
        circle.name = coloredPrefab.name + m.ToString();
        circle.transform.parent = circlesScene.transform;
        circle.transform.localPosition = new Vector3(0, y, 0);
        circle.transform.localScale = Vector3.one * radius;
        return circle;
    }

    private void GenerateCircles(GameObject coloredPrefab)
    {
        int arrIdx = 1;
        for (int m = 1; m <= 11; m++)
        {
            float dark_r = (float)GenerateCircleRadius(GSC.lensCurvature, GSC.waveLength, m, 1) * circleScale;
            float bright_r = (float)GenerateCircleRadius(GSC.lensCurvature, GSC.waveLength, m, -1) * circleScale;
            circleArray[arrIdx] = GenerateCircle(coloredPrefab, -m, m, bright_r);
            arrIdx++;
            circleArray[arrIdx] = GenerateCircle(darkCirclePrefab, -m - 0.1f, m, dark_r);
            arrIdx++;
        }
    }
}
