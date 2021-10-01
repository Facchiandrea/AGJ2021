using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacesBetweenPaintings : MonoBehaviour
{
    public bool playerBetweenPaintings = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            playerBetweenPaintings = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            playerBetweenPaintings = false;
        }
    }

}
