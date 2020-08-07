using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject puerta, jugador;
    private bool doorIsOpening = false, doorIsClosing = false;
    private Vector3 posicionOriginal;

    // Update is called once per frame
    void Update()
    {
        if (doorIsOpening)
        {
            puerta.transform.Translate(Vector3.down * Time.deltaTime * 5);
        }
        /*if (doorIsClosing)
        {
            puerta.transform.Translate(Vector3.up * Time.deltaTime * 5);
        }*/

        if (puerta.transform.position.y <= -3)
        {
            doorIsOpening = false;
        }
        /*if (puerta.transform.position.y >= posicionOriginal.y)
        {
            doorIsClosing = false;
        }*/
    }
    void Start()
    {
        posicionOriginal = puerta.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            puerta.transform.position = posicionOriginal;
            GameObject.Destroy(gameObject);
        }
    }

    public void AbrirPuerta()
    {
        doorIsOpening = true;
    }
}
