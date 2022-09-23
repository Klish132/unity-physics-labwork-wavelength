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
        { // Ёкземпл€р менеджера был найден
            instance = this; // «адаем ссылку на экземпл€р объекта
        }
        else if (instance == this)
        { // Ёкземпл€р объекта уже существует на сцене
            Destroy(gameObject); // ”дал€ем объект
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
