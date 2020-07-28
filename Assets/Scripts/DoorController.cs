using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject Door;
    public GameObject fuego;
    public bool doorIsOpening;

    // Update is called once per frame
    void Update()
    {
        if (doorIsOpening)
        {
            Door.transform.Translate(Vector3.down * Time.deltaTime * 10);
        }
        if(Door.transform.position.x> 2.8f)
        {
            doorIsOpening = false;
        }
    }
    void OnMouseDown()
    {
        doorIsOpening = true;
        fuego.SetActive(true);
    }
}
