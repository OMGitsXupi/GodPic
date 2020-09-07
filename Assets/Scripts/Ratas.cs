using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Ratas : MonoBehaviour //ESTE SCRIPT IRÁ EN EL CUADRO EN EL QUE SE METERÁN LAS RATAS
{
    public GameObject palanca, luzRoja, luzVerde;
    public List<GameObject> ratas, imagenesRata;
    public TextMesh dialogoACambiar;

    private List<bool> ratasEnActivador = new List<bool>(4);
    private int ratasBien = 0;
    private const int ratasTotales = 4;

    void OnTriggerEnter(Collider objeto)
    {
        for (int i = 0; i < 4; i++) 
        {
            if (objeto.gameObject == ratas[i])
            {
                ratasBien++;
                ratas[i].SetActive(false);
                imagenesRata[i].SetActive(true);
                Terminar();
            }
        }
    }

    void OnTriggerExit(Collider objeto)
    {
        for (int i = 0; i < 4; i++)
        {
            if (objeto.gameObject == ratas[i])
            {
                ratasBien--;
                ratas[i].SetActive(true);
                imagenesRata[i].SetActive(false);
                Terminar();
            }
        }
    }

    public void Terminar()
    {
        if (ratasBien == ratasTotales)
        {
            dialogoACambiar.text = "Parece ser que los pacientes\nestan mejorando poco a poco";

            JointLimits limits = palanca.GetComponent<HingeJoint>().limits; //Desbloquear palanca
            limits.max = 90;
            palanca.GetComponent<HingeJoint>().limits = limits;

            luzRoja.SetActive(false); //Poner luz verde
            luzVerde.SetActive(true);
        }
    }
}
