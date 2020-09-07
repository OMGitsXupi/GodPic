using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RayoEnciendeFuego : MonoBehaviour
{
    public GameObject fuego, activador, palanca, luzRoja, luzVerde;
    public TextMesh dialogoACambiar;

    private bool doorIsOpening;
    private Outline outline;
    private bool enActivador = false;

    private void Awake()
    {
        outline = gameObject.AddComponent<Outline>();
        outline.enabled = false;
        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 5f;
    }

    void OnTriggerEnter(Collider objeto)
    {
        if (objeto.gameObject == activador)
        {
            enActivador = true;
            outline.OutlineColor = Color.red;
        }
    }

    void OnTriggerExit(Collider objeto)
    {
        if (objeto.gameObject == activador)
        {
            enActivador = false;
            outline.OutlineColor = Color.yellow;
        }
    }

    public void Resaltar(bool siono)
    {
        outline.enabled = siono;
    }

    public void Soltar()
    {
        if (enActivador)
        {
            dialogoACambiar.text = "Ahora podremos calentarnos,\nprotegernos y cocinar alimentos";
            fuego.SetActive(true);
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
