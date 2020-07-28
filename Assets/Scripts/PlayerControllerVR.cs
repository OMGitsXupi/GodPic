using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerVR : MonoBehaviour
{

    public float velocidadMovimiento= 0.05f;
    public CharacterController controlador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento:
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controlador.Move(move * velocidadMovimiento * Time.deltaTime);

        //SALIR CON ESC
        if (Input.GetKey(KeyCode.Q))
        {
            Application.Quit();
        }
    }
}
