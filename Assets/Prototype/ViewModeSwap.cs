using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewModeSwap : MonoBehaviour
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
    public GameObject fullViewCam;
    private int lastCamCounter;

    [HideInInspector]
    public bool fullView;

    private void Start()
    {
        fullView = false;
        lastCamCounter = 1;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && fullView == false)
        {
            EnterFullView();
        }

        else if (Input.GetKeyDown(KeyCode.V) && fullView == true)
        {
            ExitFullView();
        }

    }

    public void EnterFullView()
    {
        Debug.Log("SAS");
        if (camera1.activeInHierarchy)
        {
            lastCamCounter = 1;
            camera1.SetActive(false);
        }
        else if (camera2.activeInHierarchy)
        {
            lastCamCounter = 2;
            camera2.SetActive(false);
        }
        else if (camera3.activeInHierarchy)
        {
            lastCamCounter = 3;
            camera3.SetActive(false);
        }
        else if (camera4.activeInHierarchy)
        {
            lastCamCounter = 4;
            camera4.SetActive(false);
        }
        else if (camera5.activeInHierarchy)
        {
            lastCamCounter = 5;
            camera5.SetActive(false);
        }
        else if (camera6.activeInHierarchy)
        {
            lastCamCounter = 6;
            camera6.SetActive(false);
        }
        else if (camera7.activeInHierarchy)
        {
            lastCamCounter = 7;
            camera7.SetActive(false);
        }
        else if (camera8.activeInHierarchy)
        {
            lastCamCounter = 8;
            camera8.SetActive(false);
        }
        else if (camera9.activeInHierarchy)
        {
            lastCamCounter = 9;
            camera9.SetActive(false);
        }
        else if (camera10.activeInHierarchy)
        {
            lastCamCounter = 10;
            camera10.SetActive(false);
        }
        else if (camera11.activeInHierarchy)
        {
            lastCamCounter = 11;
            camera11.SetActive(false);
        }
        else if (camera12.activeInHierarchy)
        {
            lastCamCounter = 12;
            camera12.SetActive(false);
        }

        fullView = true;

        fullViewCam.SetActive(true);

    }

    public void ExitFullView()
    {
        Debug.Log("SNE");

        fullView = false;

        if (lastCamCounter == 1)
        {
            camera1.SetActive(true);
        }
        else if (lastCamCounter == 2)
        {
            camera2.SetActive(true);
        }
        else if (lastCamCounter == 3)
        {
            camera3.SetActive(true);
        }
        else if (lastCamCounter == 4)
        {
            camera4.SetActive(true);
        }
        else if (lastCamCounter == 5)
        {
            camera5.SetActive(true);
        }
        else if (lastCamCounter == 6)
        {
            camera6.SetActive(true);
        }
        else if (lastCamCounter == 7)
        {
            camera7.SetActive(true);
        }
        else if (lastCamCounter == 8)
        {
            camera8.SetActive(true);
        }
        else if (lastCamCounter == 9)
        {
            camera9.SetActive(true);
        }
        else if (lastCamCounter == 10)
        {
            camera10.SetActive(true);
        }
        else if (lastCamCounter == 11)
        {
            camera11.SetActive(true);
        }
        else if (lastCamCounter == 12)
        {
            camera12.SetActive(true);
        }

        fullViewCam.SetActive(false);

    }
}
