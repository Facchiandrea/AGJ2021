using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintSpace12 : MonoBehaviour
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

    public GameObject Painting12;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(true);
            camera5.SetActive(false);
            camera6.SetActive(false);
            camera7.SetActive(false);
            camera8.SetActive(false);
            camera9.SetActive(false);
            camera10.SetActive(false);
            camera11.SetActive(false);
            camera12.SetActive(false);

            //Painting12.transform.GetChild(3).gameObject.SetActive(false);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            //Painting12.transform.GetChild(3).gameObject.SetActive(true);
        }
    }

}
