using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MaderaFaraon : MonoBehaviour
{
    public GameObject activador, jeroglifico, palanca, luzRoja, luzVerde;
    public TextMesh dialogoACambiar;
    
    private bool enActivador = false;
    

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
            transform.localScale = new Vector3(0, 0, 0);
            GetComponent<XRGrabInteractable>().enabled = false; //No se puede coger

            JointLimits limits = palanca.GetComponent<HingeJoint>().limits; //Desbloquear palanca
            limits.max = 90;
            palanca.GetComponent<HingeJoint>().limits = limits;

            luzRoja.SetActive(false); //Poner luz verde
            luzVerde.SetActive(true);
        }
    }
}

