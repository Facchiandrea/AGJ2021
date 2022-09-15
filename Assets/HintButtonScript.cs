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
        foreach (var item in Painting1Prompts)
        {
            item.SetActive(true);
        }
        showPrompts = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        foreach (var item in Painting1Prompts)
        {
            item.SetActive(false);
        }
        showPrompts = false;
    }

}
