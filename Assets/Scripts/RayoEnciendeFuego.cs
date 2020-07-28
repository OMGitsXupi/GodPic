using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RayoEnciendeFuego : MonoBehaviour
{
    public GameObject door, fuego, activador;
    public bool doorIsOpening;

    private XRGrabInteractable objetoAgarrable = null;
    private Outline outline;

    private void Awake()
    {
        objetoAgarrable = GetComponent<XRGrabInteractable>();
        objetoAgarrable.onHoverEnter.AddListener(Resaltar);
        objetoAgarrable.onLastHoverExit.AddListener(DejarDeResaltar);

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
        if (door.transform.position.x > 2.8f)
        {
            doorIsOpening = false;
        }
    }

    private void OnDestroy()
    {
        objetoAgarrable.onHoverEnter.RemoveListener(Resaltar);
        objetoAgarrable.onLastHoverExit.RemoveListener(DejarDeResaltar);
    }

    void OnTriggerEnter(Collider objeto)
    {
        if (objeto.gameObject == activador)
        {
            doorIsOpening = true;
            fuego.SetActive(true);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void Resaltar(XRBaseInteractor interactor)
    {
        outline.enabled = true;
    }

    void DejarDeResaltar(XRBaseInteractor interactor)
    {
        outline.enabled = false;
    }
}
