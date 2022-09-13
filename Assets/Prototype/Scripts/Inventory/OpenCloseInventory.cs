using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenCloseInventory : MonoBehaviour
{

    private bool inventoryOpen = false;

    private Vector2 closedPosition;
    private Vector2 openedPosition;

    public float speed;
    RectTransform thisRectTransform;

    public RectTransform inventoryBarRectTransform;

    //fix
    public bool cursorOnInventory;

    private void Start()
    {
        thisRectTransform = this.gameObject.GetComponent<RectTransform>();

        closedPosition = new Vector2(0, 0);
        openedPosition = new Vector2(thisRectTransform.anchoredPosition.x, thisRectTransform.anchoredPosition.y - 200f);
    }
    public void OpenCloseInventoryButton()
    {
        if (inventoryOpen == false)
        {
            inventoryOpen = true;
        }

        else
        {
            inventoryOpen = false;
        }
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())    // is the touch on the GUI
        {
            cursorOnInventory = true;
        }

        else
        {
            cursorOnInventory = false;
        }

        float step = speed * Time.deltaTime;

        if (inventoryOpen == true && thisRectTransform.anchoredPosition.y != openedPosition.y)
        {
            thisRectTransform.anchoredPosition = Vector2.MoveTowards(thisRectTransform.anchoredPosition, openedPosition, step);
            if (thisRectTransform.anchoredPosition.y <= openedPosition.y)
            {
                thisRectTransform.anchoredPosition = openedPosition;
            }
        }
        else if (inventoryOpen == false && thisRectTransform.anchoredPosition.y != closedPosition.y)
        {
            thisRectTransform.anchoredPosition = Vector2.MoveTowards(thisRectTransform.anchoredPosition, closedPosition, step);
            if (thisRectTransform.anchoredPosition.y >= closedPosition.y)
            {
                thisRectTransform.anchoredPosition = new Vector2(0, 0);
            }
        }
        inventoryBarRectTransform.anchoredPosition = thisRectTransform.anchoredPosition;
    }
}
