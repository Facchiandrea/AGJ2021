using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintSpace6 : MonoBehaviour
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

    private bool playerIn;

    private void Update()
    {
        if (playerIn && tempPainting != null)
        {
            tempPainting.tag = "Untagged";
        }
        else if (tempPainting != null)
        {
            tempPainting.tag = "Painting";
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(false);
            camera5.SetActive(false);
            camera6.SetActive(true);
            camera7.SetActive(false);
            camera8.SetActive(false);
            camera9.SetActive(false);
            camera10.SetActive(false);
            camera11.SetActive(false);
            camera12.SetActive(false);

            playerIn = true;
        }

        if (collision.CompareTag("Painting"))
        {
            tempPainting = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            this.gameObject.transform.root.tag = "Painting";

            playerIn = false;
        }
    }

}
