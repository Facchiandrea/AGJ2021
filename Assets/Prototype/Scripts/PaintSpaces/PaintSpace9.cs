using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintSpace9 : MonoBehaviour
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

    public GameObject Painting9;
    public ViewModeSwap ViewModeSwap;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            ViewModeSwap.lastCamCounter = 9;

            //Painting9.transform.GetChild(3).gameObject.SetActive(false);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            //Painting9.transform.GetChild(3).gameObject.SetActive(true);
        }
    }

}
