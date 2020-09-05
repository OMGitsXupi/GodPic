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

        if (puerta.transform.position.y <= -3) //door.transform.position.x > 2.8f
        {
            doorIsOpening = false;
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
            puerta.GetComponent<AudioSource>().Play();
            GameObject.Destroy(gameObject);
        }
    }

    public void AbrirPuerta()
    {
        doorIsOpening = true;
        puerta.GetComponent<AudioSource>().enabled = true;
    }

    public void CerrarPuerta()
    {
        doorIsOpening = false;
        puerta.transform.position = posicionOriginal;
        puerta.GetComponent<AudioSource>().Play();
    }
}
