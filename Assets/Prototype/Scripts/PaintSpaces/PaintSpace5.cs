using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintSpace5 : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;
    public GameObject camera4;
    public GameObject camera5;
    public GameObject camera6;
    public GameObject camera7;
    public GameObject camera8;
    public GameObject camera9;
    public GameObject camera10;
    public GameObject camera11;
    public GameObject camera12;

    public GameObject tempPainting;
    public ViewModeSwap ViewModeSwap;

    public bool playerIn;

    private void Update()
    {
        if (playerIn && tempPainting != null)
        {
            tempPainting.tag = "Untagged";
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {

            playerIn = true;
            //tempPainting.transform.GetChild(3).gameObject.SetActive(false);
            ViewModeSwap.lastCamCounter = 5;

        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Painting"))
        {
            tempPainting = collision.gameObject;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            tempPainting.gameObject.tag = "Painting";

            playerIn = false;
            //tempPainting.transform.GetChild(3).gameObject.SetActive(true);

        }
    }

}
