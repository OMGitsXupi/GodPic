using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Ratas : MonoBehaviour //ESTE SCRIPT IRÁ EN EL CUADRO EN EL QUE SE METERÁN LAS RATAS
{
    public GameObject door;
    public List<GameObject> ratas, imagenesRata;
    public TextMesh dialogoACambiar;

    private List<bool> ratasEnActivador = new List<bool>(4);
    private int ratasBien = 0;
    private const int ratasTotales = 4;
    private bool doorIsOpening;
    private XRGrabInteractable objetoAgarrable = null;

    private void Awake()
    {
        objetoAgarrable = GetComponent<XRGrabInteractable>();
    }

    void Update()
    {
        if (doorIsOpening)
        {
            door.transform.Translate(Vector3.down * Time.deltaTime * 10);
        }
        if (door.transform.position.y <= -3)
        {
            doorIsOpening = false;
        }
    }

    void OnTriggerEnter(Collider objeto)
    {
        for (int i = 0; i < 4; i++) 
        {
            if (objeto.gameObject == ratas[i])
            {
                ratasBien++;
                ratas[i].SetActive(false);
                imagenesRata[i].SetActive(true);
                Terminar();
            }
        }
    }

    void OnTriggerExit(Collider objeto)
    {
        for (int i = 0; i < 4; i++)
        {
            if (objeto.gameObject == ratas[i])
            {
                ratasBien--;
                ratas[i].SetActive(true);
                imagenesRata[i].SetActive(false);
                Terminar();
            }
        }
    }

    public void Terminar()
    {
        if (ratasBien == ratasTotales)
        {
            dialogoACambiar.text = "Parece ser que los pacientes\nestán mejorando poco a poco";
            doorIsOpening = true;
            door.GetComponent<AudioSource>().enabled = true;
        }
    }
}
