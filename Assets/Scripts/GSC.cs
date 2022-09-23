using UnityEngine;

public class GSC : MonoBehaviour
{
    public static GSC instance = null;

    public static GameObject focusTarget = null;

    public static GameObject mainBody = null;
    public static GameObject rotator = null;
    public static GameObject microscope = null;
    public static GameObject ruler = null;

    public static float waveLength = 0;
    public static float lensCurvature = 0;

    public static GameObject cameraSlide = null;

    void Start()
    {
        if (instance == null)
        { // ��������� ��������� ��� ������
            instance = this; // ������ ������ �� ��������� �������
        }
        else if (instance == this)
        { // ��������� ������� ��� ���������� �� �����
            Destroy(gameObject); // ������� ������
        }
        Initialize();
    }

    private void Initialize()
    {
        focusTarget = mainBody = GameObject.Find("MainBody");
        rotator = GameObject.Find("Rotator");
        microscope = GameObject.Find("Microscope");
        ruler = GameObject.Find("Ruler");

        cameraSlide = GameObject.Find("CameraSlide");

        //benchHolder = GameObject.Find("bench").GetComponent<ObjectHolder>();
    }
}
