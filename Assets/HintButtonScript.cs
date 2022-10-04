using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HintButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject[] Painting1Prompts;
    public bool showPrompts;

    public void OnPointerDown(PointerEventData eventData)
    {
        ShowPrompts();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        HidePrompts();
    }

    public void ShowPrompts()
    {
        foreach (var item in Painting1Prompts)
        {
            item.SetActive(true);
        }
        showPrompts = true;

    }

    public void HidePrompts()
    {
        foreach (var item in Painting1Prompts)
        {
            item.SetActive(false);
        }
        showPrompts = false;

    }
}
