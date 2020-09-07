using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class accionarSwad : MonoBehaviour
{
    public GameObject activador, swadParaActivar, palanca, luzRoja, luzVerde;
    public TextMesh dialogoACambiar;

    private bool enActivador = false;

    void OnTriggerEnter(Collider objeto)
    {
        if (objeto.gameObject == activador)
            enActivador = true;
    }

    void OnTriggerExit(Collider objeto)
    {
        if (objeto.gameObject == activador)
            enActivador = false;
    }

    public void Soltar()
    {
        if (enActivador)
        {
            dialogoACambiar.text = " Mejor... ahora solo te quedan\n4 piezas de conocimiento.";
            transform.localScale = new Vector3(0, 0, 0);
            GetComponent<XRGrabInteractable>().enabled = false; //No se puede coger
            swadParaActivar.SetActive(true);

            JointLimits limits = palanca.GetComponent<HingeJoint>().limits; //Desbloquear palanca
            limits.max = 90;
            palanca.GetComponent<HingeJoint>().limits = limits;

            luzRoja.SetActive(false); //Poner luz verde
            luzVerde.SetActive(true);
        }
    }
}
