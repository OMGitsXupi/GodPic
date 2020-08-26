using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RayoEnciendeFuego : MonoBehaviour
{
    public GameObject door, fuego, activador;
    private bool doorIsOpening;

    private XRGrabInteractable objetoAgarrable = null;
    private Outline outline;
    private bool enActivador = false;

    private void Awake()
    {
        objetoAgarrable = GetComponent<XRGrabInteractable>();

        outline = gameObject.AddComponent<Outline>();
        outline.enabled = false;
        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 5f;
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
            doorIsOpening = true;
            door.GetComponent<AudioSource>().enabled = true;
            fuego.SetActive(true);
            transform.localScale = new Vector3(0, 0, 0);
            GetComponent<XRGrabInteractable>().enabled = false; //No se puede coger
        }
    }
}
