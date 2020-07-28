using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFP : MonoBehaviour
{

    public Camera CameraFPS;
    public float camSensibilidadX;
    public float camSensibilidadY;

    float y;
    float x;

    float yRotacion=0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        x = 10* camSensibilidadX * Input.GetAxis("Mouse X") * Time.deltaTime;
        y = 10* camSensibilidadY * Input.GetAxis("Mouse Y") * Time.deltaTime;

        yRotacion -= y;
        yRotacion = Mathf.Clamp(yRotacion, -90f, 90f);

        CameraFPS.transform.localRotation = Quaternion.Euler(yRotacion,0f,0f); //90f porque el personaje está girado //giro vertical
        transform.Rotate(Vector3.up*x); //giro horizontal
    }
}
