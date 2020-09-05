using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class movement_VR : LocomotionProvider
{
    public List<XRController> controladores = null;
    public float multiplicadorGravedad = 1f, velocidad = 1f;

    private CharacterController controladorPersonaje = null;
    private GameObject cabeza = null;

    protected override void Awake()
    {
        controladorPersonaje = GetComponent<CharacterController>();
        cabeza = GetComponent<XRRig>().cameraGameObject;
    }

    void Start()
    {
        PositionController();
    }
    
    void FixedUpdate()
    {
        PositionController();
        ComprobarInput();
        AplicarGravedad();
    }

    void PositionController()
    {
        float alturaCabeza = Mathf.Clamp(cabeza.transform.localPosition.y, 1, 2);
        controladorPersonaje.height = alturaCabeza;

        Vector3 nuevoCentro = new Vector3(
            cabeza.transform.localPosition.x,
            (controladorPersonaje.height/2) + controladorPersonaje.skinWidth,
            cabeza.transform.localPosition.z);

        controladorPersonaje.center = nuevoCentro;
    }

    void ComprobarInput()
    {
        foreach(XRController controlador in controladores)
        {
            if (controlador.enableInputActions)
                if (controlador.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 posicion))
                    Mover(posicion);
        }
    }

    void Mover(Vector2 posicion)
    {
        Vector3 direccion = new Vector3(posicion.x, 0f, posicion.y);
        Vector3 rotacion = new Vector3(0, cabeza.transform.eulerAngles.y, 0);
        direccion = Quaternion.Euler(rotacion) * direccion;

        controladorPersonaje.Move(direccion * velocidad * Time.deltaTime);
    }

    void AplicarGravedad()
    {
        Vector3 gravedad = new Vector3(0, Physics.gravity.y * multiplicadorGravedad, 0);
        controladorPersonaje.Move(gravedad * Time.deltaTime);
    }
}
