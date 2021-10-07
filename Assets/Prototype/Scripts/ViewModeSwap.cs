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
    public int lastCamCounter;

    public SpacesBetweenPaintings spacesBetweenPaintings;
    public NPCInteractor NPCInteractor;
    public Swapper swapper;
    public FadeInOut FadeInOut;
    public Mongolfiera mongolfiera;
    public DialogueManager dialogueManager;
    public LockManager lockManager;

    [HideInInspector]
    public bool fullView;


    public bool transitionToSingle = false;
    public bool transitionToFull = false;
    private float timerCameraTransition = 1.2f;
    private float timer;

    private void Start()
    {
        fullView = false;
        lastCamCounter = 1;
        timer = 0;
    }
    void Update()
    {
        if (lockManager.lockPuzzleActive == false)
        {

            if (Input.GetKeyDown(KeyCode.Space) && fullView == false && swapper.transition == false && spacesBetweenPaintings.playerBetweenPaintings == false && FadeInOut.fadeTransition == false && mongolfiera.traveling == false && dialogueManager.inDialogue == false)
            {
                EnterFullView();
                transitionToFull = true;
                transitionToSingle = false;

            }

            else if (Input.GetKeyDown(KeyCode.Space) && fullView == true && swapper.transition == false && spacesBetweenPaintings.playerBetweenPaintings == false && FadeInOut.fadeTransition == false && mongolfiera.traveling == false)
            {
                ExitFullView();
                transitionToSingle = true;
                transitionToFull = false;

            }

            if (transitionToFull == true)
            {
                timer += Time.deltaTime;
                if (timer >= timerCameraTransition)
                {
                    timer = timerCameraTransition;
                    transitionToFull = false;
                }
            }

            if (transitionToSingle == true)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer = 0;
                    transitionToSingle = false;
                }
            }

            if (fullView == false)
            {
                if (lastCamCounter == 1)
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
                    fullViewCam.SetActive(false);
                }
                else if (lastCamCounter == 2)
                {
                    camera1.SetActive(false);
                    camera2.SetActive(true);
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
                    fullViewCam.SetActive(false);

                }
                else if (lastCamCounter == 3)
                {
                    camera1.SetActive(false);
                    camera2.SetActive(false);
                    camera3.SetActive(true);
                    camera4.SetActive(false);
                    camera5.SetActive(false);
                    camera6.SetActive(false);
                    camera7.SetActive(false);
                    camera8.SetActive(false);
                    camera9.SetActive(false);
                    camera10.SetActive(false);
                    camera11.SetActive(false);
                    camera12.SetActive(false);
                    fullViewCam.SetActive(false);

                }

                else if (lastCamCounter == 4)
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
                    fullViewCam.SetActive(false);

                }

                else if (lastCamCounter == 5)
                {
                    camera1.SetActive(false);
                    camera2.SetActive(false);
                    camera3.SetActive(false);
                    camera4.SetActive(false);
                    camera5.SetActive(true);
                    camera6.SetActive(false);
                    camera7.SetActive(false);
                    camera8.SetActive(false);
                    camera9.SetActive(false);
                    camera10.SetActive(false);
                    camera11.SetActive(false);
                    camera12.SetActive(false);
                    fullViewCam.SetActive(false);

                }

                else if (lastCamCounter == 6)
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
                    fullViewCam.SetActive(false);

                }

                else if (lastCamCounter == 7)
                {
                    camera1.SetActive(false);
                    camera2.SetActive(false);
                    camera3.SetActive(false);
                    camera4.SetActive(false);
                    camera5.SetActive(false);
                    camera6.SetActive(false);
                    camera7.SetActive(true);
                    camera8.SetActive(false);
                    camera9.SetActive(false);
                    camera10.SetActive(false);
                    camera11.SetActive(false);
                    camera12.SetActive(false);
                    fullViewCam.SetActive(false);

                }

                else if (lastCamCounter == 8)
                {
                    camera1.SetActive(false);
                    camera2.SetActive(false);
                    camera3.SetActive(false);
                    camera4.SetActive(false);
                    camera5.SetActive(false);
                    camera6.SetActive(false);
                    camera7.SetActive(false);
                    camera8.SetActive(true);
                    camera9.SetActive(false);
                    camera10.SetActive(false);
                    camera11.SetActive(false);
                    camera12.SetActive(false);
                    fullViewCam.SetActive(false);

                }

                else if (lastCamCounter == 9)
                {
                    camera1.SetActive(false);
                    camera2.SetActive(false);
                    camera3.SetActive(false);
                    camera4.SetActive(false);
                    camera5.SetActive(false);
                    camera6.SetActive(false);
                    camera7.SetActive(false);
                    camera8.SetActive(false);
                    camera9.SetActive(true);
                    camera10.SetActive(false);
                    camera11.SetActive(false);
                    camera12.SetActive(false);
                    fullViewCam.SetActive(false);

                }

                else if (lastCamCounter == 10)
                {
                    camera1.SetActive(false);
                    camera2.SetActive(false);
                    camera3.SetActive(false);
                    camera4.SetActive(false);
                    camera5.SetActive(false);
                    camera6.SetActive(false);
                    camera7.SetActive(false);
                    camera8.SetActive(false);
                    camera9.SetActive(false);
                    camera10.SetActive(true);
                    camera11.SetActive(false);
                    camera12.SetActive(false);
                    fullViewCam.SetActive(false);

                }

                else if (lastCamCounter == 11)
                {
                    camera1.SetActive(false);
                    camera2.SetActive(false);
                    camera3.SetActive(false);
                    camera4.SetActive(false);
                    camera5.SetActive(false);
                    camera6.SetActive(false);
                    camera7.SetActive(false);
                    camera8.SetActive(false);
                    camera9.SetActive(false);
                    camera10.SetActive(false);
                    camera11.SetActive(true);
                    camera12.SetActive(false);
                    fullViewCam.SetActive(false);

                }

                else if (lastCamCounter == 12)
                {
                    camera1.SetActive(false);
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
                    camera12.SetActive(true);
                    fullViewCam.SetActive(false);

                }
            }
        }
    }

    public void EnterFullView()
    {
        /*if (camera1.activeInHierarchy)
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
        }*/
        fullViewCam.SetActive(true);
        camera1.SetActive(false);
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

        fullView = true;


    }

    public void ExitFullView()
    {
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

    public void BusCameraTransition()
    {
        camera1.SetActive(false);
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
        fullViewCam.SetActive(false);

        if (NPCInteractor.stazione1 == false)
        {
            camera9.SetActive(true);
        }
        else
        {
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

        }
    }
}
