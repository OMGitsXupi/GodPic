﻿using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MaderaFaraon : MonoBehaviour
{
    public GameObject activador, puerta, jeroglifico;
    public TextMesh dialogoACambiar;

    private XRGrabInteractable objetoAgarrable = null;
    private bool enActivador = false, doorIsOpening = false;

    private void Awake()
    {
        objetoAgarrable = GetComponent<XRGrabInteractable>();
    }

    void Update()
    {
        if (doorIsOpening)
        {
            puerta.transform.Translate(Vector3.down * Time.deltaTime * 10);
        }
        if (puerta.transform.position.y <= -3)
        {
            //doorIsOpening = false;
        }
    }

    void OnCollisionEnter(Collision objeto)
    {
        if (objeto.gameObject == activador)
        {
            enActivador = true;
        }
    }

    void OnCollisionExit(Collision objeto)
    {
        if (objeto.gameObject == activador)
        {
            enActivador = false;
        }
    }


    public void Soltar()
    {
        if (enActivador && jeroglifico != null && jeroglifico.activeSelf)
        {
            dialogoACambiar.text="Gracias!";
            doorIsOpening = true;
            puerta.GetComponent<AudioSource>().enabled = true;
            transform.localScale = new Vector3(0, 0, 0);
            GetComponent<XRGrabInteractable>().enabled = false; //No se puede coger
        }
    }
}
