using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunaDetector : MonoBehaviour
{
    public bool lunaTrovata;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Luna"))
        {
            lunaTrovata = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Luna"))
        {
            lunaTrovata = false;
        }

    }
}
