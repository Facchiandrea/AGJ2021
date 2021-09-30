using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorbidDetector : MonoBehaviour
{
    public GameObject barrieraFosso;
    public bool interactedWithFlowers;
    public bool interactedWithMattress;
    public bool morbidBelow;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (barrieraFosso.activeInHierarchy)
        {
            if (collision.name == "Fiori" && interactedWithFlowers || collision.name == "Materassi" && interactedWithMattress)
            {
                barrieraFosso.SetActive(false);
                morbidBelow = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Fiori" || collision.name == "Materassi")
        {
            barrieraFosso.SetActive(true);
            morbidBelow = false; //testare cosa succede se swappo le due cose mordbide porccoddio non va
        }

    }
}
