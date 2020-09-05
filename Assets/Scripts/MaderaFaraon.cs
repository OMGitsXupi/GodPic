using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MaderaFaraon : MonoBehaviour
{
    public GameObject activador, puerta, jeroglifico;
    public TextMesh dialogoACambiar;

    private XRGrabInteractable objetoAgarrable = null;
    private bool enActivador = false;

    private void Awake()
    {
        objetoAgarrable = GetComponent<XRGrabInteractable>();
    }

    void OnTriggerEnter(Collider objeto)
    {
        if (objeto.gameObject == activador)
        {
            enActivador = true;
        }
    }

    void OnTriggerExit(Collider objeto)
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
            puerta.transform.position = puerta.transform.position - new Vector3(0, 3, 0);
            puerta.GetComponent<AudioSource>().enabled = true;
            GameObject.Destroy(gameObject);
        }
    }
}

