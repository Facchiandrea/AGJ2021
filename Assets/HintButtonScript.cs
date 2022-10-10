using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HintButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject[] Painting1Prompts;
    public GameObject[] Painting2Prompts;
    public GameObject[] Painting3Prompts;
    public GameObject[] Painting4Prompts;
    public GameObject[] Painting5Prompts;
    public GameObject[] Painting6Prompts;
    public GameObject[] Painting7Prompts;
    public GameObject[] Painting8Prompts;
    public GameObject[] Painting9Prompts;
    public GameObject[] Painting10Prompts;
    public GameObject[] Painting11Prompts;
    public GameObject[] Painting12Prompts;
    public bool showPrompts;

    public SpacesBetweenPaintings spacesBetweenPaintings;
    public PaintCheckerManager paintCheckerManager;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (spacesBetweenPaintings.playerBetweenPaintings == false)
        {
            ShowPrompts();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        HidePrompts();
    }

    public void ShowPrompts()
    {
        if (paintCheckerManager.currentPainting == 1)
        {
            foreach (var item in Painting1Prompts)
            {
                item.SetActive(true);
            }
            showPrompts = true;
        }

        else if (paintCheckerManager.currentPainting == 2)
        {
            foreach (var item in Painting2Prompts)
            {
                item.SetActive(true);
            }
            showPrompts = true;
        }

        else if (paintCheckerManager.currentPainting == 3)
        {
            foreach (var item in Painting3Prompts)
            {
                item.SetActive(true);
            }
            showPrompts = true;
        }

        else if (paintCheckerManager.currentPainting == 4)
        {
            foreach (var item in Painting4Prompts)
            {
                item.SetActive(true);
            }
            showPrompts = true;
        }

        else if (paintCheckerManager.currentPainting == 5)
        {
            foreach (var item in Painting5Prompts)
            {
                item.SetActive(true);
            }
            showPrompts = true;
        }

        else if (paintCheckerManager.currentPainting == 6)
        {
            foreach (var item in Painting6Prompts)
            {
                item.SetActive(true);
            }
            showPrompts = true;
        }

        else if (paintCheckerManager.currentPainting == 7)
        {
            foreach (var item in Painting7Prompts)
            {
                item.SetActive(true);
            }
            showPrompts = true;
        }

        else if (paintCheckerManager.currentPainting == 8)
        {
            foreach (var item in Painting8Prompts)
            {
                item.SetActive(true);
            }
            showPrompts = true;
        }

        else if (paintCheckerManager.currentPainting == 9)
        {
            foreach (var item in Painting9Prompts)
            {
                item.SetActive(true);
            }
            showPrompts = true;
        }


        else if (paintCheckerManager.currentPainting == 10)
        {
            foreach (var item in Painting10Prompts)
            {
                item.SetActive(true);
            }
            showPrompts = true;
        }

        else if (paintCheckerManager.currentPainting == 11)
        {
            foreach (var item in Painting11Prompts)
            {
                item.SetActive(true);
            }
            showPrompts = true;
        }

        else if (paintCheckerManager.currentPainting == 12)
        {
            foreach (var item in Painting12Prompts)
            {
                item.SetActive(true);
            }
            showPrompts = true;
        }

    }

    public void HidePrompts()
    {
        foreach (var item in Painting1Prompts)
        {
            item.SetActive(false);
        }

        foreach (var item in Painting2Prompts)
        {
            item.SetActive(false);
        }

        foreach (var item in Painting3Prompts)
        {
            item.SetActive(false);
        }

        foreach (var item in Painting4Prompts)
        {
            item.SetActive(false);
        }

        foreach (var item in Painting5Prompts)
        {
            item.SetActive(false);
        }

        foreach (var item in Painting6Prompts)
        {
            item.SetActive(false);
        }

        foreach (var item in Painting7Prompts)
        {
            item.SetActive(false);
        }

        foreach (var item in Painting8Prompts)
        {
            item.SetActive(false);
        }

        foreach (var item in Painting9Prompts)
        {
            item.SetActive(false);
        }

        foreach (var item in Painting10Prompts)
        {
            item.SetActive(false);
        }

        foreach (var item in Painting11Prompts)
        {
            item.SetActive(false);
        }

        foreach (var item in Painting12Prompts)
        {
            item.SetActive(false);
        }

        showPrompts = false;

    }
}
