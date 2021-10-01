using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintSpace1 : MonoBehaviour
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

    public GameObject Painting1;
    public ViewModeSwap ViewModeSwap;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            camera1.SetActive(true);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(false);
            camera5.SetActive(false);
            camera6.SetActive(false);
            camera7.SetActive(false);
            camera8.SetActive(false);
            camera9.SetActive(false);
            camera10.SetActive(false);
            camera11.SetActive(false);
            camera12.SetActive(false);

            ViewModeSwap.lastCamCounter = 1;
            //Painting1.transform.GetChild(3).gameObject.SetActive(false);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            //Painting1.transform.GetChild(3).gameObject.SetActive(true);
        }
    }

}
