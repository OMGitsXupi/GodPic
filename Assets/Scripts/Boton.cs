using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour
{
    public GameObject activador;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0f, 1f, 0f), ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider objeto)
    {
        if (objeto.gameObject == activador)
            GetComponent<AudioSource>().Play();
    }

    private void OnCollisionEnter(Collision objeto)
    {
        if (objeto.gameObject == activador)
            GetComponent<AudioSource>().Play();
    }
}
