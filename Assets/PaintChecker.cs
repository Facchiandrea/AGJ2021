using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintChecker : MonoBehaviour
{
    public PaintCheckerManager paintCheckerManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            if (this.gameObject.name == "1RESIZINATOR & music")
            {
                paintCheckerManager.currentPainting = 1;
            }
            else if (this.gameObject.name == "2RESIZINATOR & music")
            {
                paintCheckerManager.currentPainting = 2;
            }
            else if (this.gameObject.name == "3RESIZINATOR & music")
            {
                paintCheckerManager.currentPainting = 3;
            }
            else if (this.gameObject.name == "4RESIZINATOR & music")
            {
                paintCheckerManager.currentPainting = 4;
            }
            else if (this.gameObject.name == "5RESIZINATOR & music")
            {
                paintCheckerManager.currentPainting = 5;
            }
            else if (this.gameObject.name == "6RESIZINATOR & music")
            {
                paintCheckerManager.currentPainting = 6;
            }
            else if (this.gameObject.name == "7RESIZINATOR & music")
            {
                paintCheckerManager.currentPainting = 7;
            }
            else if (this.gameObject.name == "8RESIZINATOR & music")
            {
                paintCheckerManager.currentPainting = 8;
            }
            else if (this.gameObject.name == "9RESIZINATOR & music")
            {
                paintCheckerManager.currentPainting = 9;
            }
            else if (this.gameObject.name == "10RESIZINATOR & music")
            {
                paintCheckerManager.currentPainting = 10;
            }
            else if (this.gameObject.name == "11RESIZINATOR & music")
            {
                paintCheckerManager.currentPainting = 11;
            }
            else if (this.gameObject.name == "12RESIZINATOR & music")
            {
                paintCheckerManager.currentPainting = 12;
            }

        }
    }
}
