using UnityEngine;

public class Resaltar : MonoBehaviour
{
    public GameObject activador = null;
    
    private Outline outline;

    void Awake()
    {
        outline = gameObject.AddComponent<Outline>();
        outline.enabled = false;
        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 5f;
    }
    
    public void ResaltarObjeto(bool siono)
    {
        outline.enabled = siono;
    }

    void OnTriggerEnter(Collider objeto)
    {
        if (activador != null && objeto.gameObject == activador)
        {
            outline.OutlineColor = Color.red;
        }
    }

    void OnTriggerExit(Collider objeto)
    {
        if (activador != null && objeto.gameObject == activador) 
        {
            outline.OutlineColor = Color.yellow;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (activador != null && collision.gameObject == activador)
        {
            outline.OutlineColor = Color.red;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (activador != null && collision.gameObject == activador)
        {
            outline.OutlineColor = Color.yellow;
        }
    }
}
