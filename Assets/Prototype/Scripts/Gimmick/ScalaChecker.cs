using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalaChecker : MonoBehaviour
{
    public bool scalaTrovata;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Scala")
        {
            scalaTrovata = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Scala")
        {
            scalaTrovata = false;
        }

    }
}
