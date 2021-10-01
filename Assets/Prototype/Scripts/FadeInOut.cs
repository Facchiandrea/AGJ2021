using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    public GameObject fadeInOBJ;
    public GameObject fadeOutOBJ;
    public PlayerMovement playerMovement;
    public NPCInteractor NPCInteractor;
    public ViewModeSwap viewModeSwap;
    public bool fadeTransition = false;
    public void FadeIn()
    {
        fadeTransition = true;

        fadeInOBJ.SetActive(true);
        playerMovement.movementBlock = true;
        Invoke("FadeOut", 1f);
    }

    public void FadeOut()
    {
        fadeInOBJ.SetActive(false);
        fadeOutOBJ.SetActive(true);
        Invoke("EndTransition", 1f);
        Invoke("CameraFix", 0.05f);
        if (NPCInteractor.uovoPortato == true)
        {
            NPCInteractor.bigliettoUI.SetActive(true);
        }


    }

    public void EndTransition()
    {
        fadeTransition = false;

        playerMovement.movementBlock = false;
        fadeOutOBJ.SetActive(false);

    }

    public void CameraFix()
    {
        viewModeSwap.BusCameraTransition();
    }
}
