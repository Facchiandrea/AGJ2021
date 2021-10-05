using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    public GameObject fadeBlack;
    public PlayerMovement playerMovement;
    public NPCInteractor NPCInteractor;
    public ViewModeSwap viewModeSwap;
    public bool fadeTransition = false;
    public void FadeIn()
    {
        fadeTransition = true;

        fadeBlack.SetActive(true);
        playerMovement.movementBlock = true;
        playerMovement.rb.velocity = new Vector2(0, playerMovement.rb.velocity.y);

        Invoke("Magheggi", 1f);
        Invoke("EndTransition", 2f);

    }

    public void Magheggi()
    {
        viewModeSwap.BusCameraTransition();
        if (NPCInteractor.uovoPortato == true)
        {
            NPCInteractor.bigliettoUI.SetActive(true);
        }
        //Invoke("CameraFix", 0.1f);

    }

    public void EndTransition()
    {
        fadeTransition = false;

        playerMovement.movementBlock = false;
        fadeBlack.SetActive(false);

    }

}
