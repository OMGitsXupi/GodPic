using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RocaGeroglifico : MonoBehaviour
{
    public GameObject activador, actibableAlSoltar;

    private XRGrabInteractable objetoAgarrable = null;
    private bool enActivador = false;

    private void Awake()
    {
        objetoAgarrable = GetComponent<XRGrabInteractable>();
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
        if (enActivador)
        {
            actibableAlSoltar.SetActive(true);
        }
    }
}
