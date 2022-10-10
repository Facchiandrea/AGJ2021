using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpacesBetweenPaintings : MonoBehaviour
{
    public bool playerBetweenPaintings = false;
    public HintButtonScript hintButtonScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            playerBetweenPaintings = true;
            hintButtonScript.HidePrompts();
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
