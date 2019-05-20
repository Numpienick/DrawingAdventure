using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreenResolution : MonoBehaviour
{

    public bool maintainWidth = true;

    [Range(-1, 1)]
    public int adaptPosition;

    float defaultWidth;
    float defaultHeight;

    Camera mainCam;
    Vector3 cameraPos;

    void Start()
    {
        mainCam = Camera.main;
        cameraPos = mainCam.transform.position;

        defaultHeight = mainCam.orthographicSize;
        defaultWidth = mainCam.orthographicSize * mainCam.aspect;
    }

    void Update()
    {
        if (maintainWidth)
        {
            mainCam.orthographicSize = defaultWidth / mainCam.aspect;

            mainCam.transform.position = new Vector3(cameraPos.x, adaptPosition * (defaultHeight - mainCam.orthographicSize), cameraPos.z);
        }
        else
        {
            mainCam.transform.position = new Vector3(adaptPosition * (defaultWidth - mainCam.orthographicSize * mainCam.aspect), cameraPos.y, cameraPos.z);
        }
    }
}
