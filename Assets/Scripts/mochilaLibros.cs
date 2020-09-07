using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mochilaLibros : MonoBehaviour
{
    public List<GameObject> libros;
    public TextMesh dialogoACambiar;
    public GameObject paredParaQuitar, perro;

    private int librosBien = 0;
    private const int librosTotales = 4;

    void OnTriggerEnter(Collider objeto)
    {
        for (int i = 0; i < 4; i++)
        {
            if (objeto.gameObject == libros[i])
            {
                librosBien++;
                libros[i].SetActive(false);
                GetComponent<AudioSource>().Play();
                Terminar();
            }
        }
    }
    public void Terminar()
    {
        if (librosBien == librosTotales)
        {
            perro.GetComponent<AudioSource>().Play();
            dialogoACambiar.text = "Ya tienes lo necesario...\nA trabajar.";
            paredParaQuitar.SetActive(false);
        }
    }
}
