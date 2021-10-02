using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerraDetector : MonoBehaviour
{
    public bool terraTrovata;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Luna"))
        {
            terraTrovata = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Luna"))
        {
            terraTrovata = false;
        }

    }

}
