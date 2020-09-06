using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject puerta, jugador, palancaAnterior;

    private bool doorIsOpening = false, doorIsClosing = false, palancaBajada = false;
    private Vector3 posicionOriginal;

    // Update is called once per frame
    void Update()
    {
        if (doorIsOpening)
            puerta.transform.Translate(Vector3.down * Time.deltaTime * 10);

        if (doorIsClosing)
            puerta.transform.Translate(Vector3.up * Time.deltaTime * 10);

        if (puerta.transform.position.y <= -3) //Se termina de abrir
            doorIsOpening = false;

        if (puerta.transform.position.y >= posicionOriginal.y && doorIsClosing) //Se termina de cerrar
        {
            puerta.transform.position = posicionOriginal;
            doorIsClosing = false;
            puerta.GetComponent<AudioSource>().enabled = false;
        }

        if (palancaAnterior.transform.eulerAngles.y > 90 && !palancaBajada) //Detectar palanca y abrir
        {
            AbrirPuerta();
            palancaBajada = true;
        }
    }
    void Start()
    {
        posicionOriginal = puerta.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            CerrarPuerta();
            //GameObject.Destroy(gameObject);
        }
    }

    public void AbrirPuerta()
    {
        doorIsOpening = true;
        puerta.GetComponent<AudioSource>().Play();
    }

    public void CerrarPuerta()
    {
        doorIsOpening = false;
        doorIsClosing = true;
        puerta.GetComponent<AudioSource>().Play();
    }
}
