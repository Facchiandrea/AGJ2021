using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public NPCInteractor NPCInteractor;
    Vector2 startPos;
    public GameObject bigliettoUI;
    public GameObject forcinaUI;
    public FadeInOut fadeInOut;

    private void Start()
    {
        startPos = this.gameObject.GetComponent<RectTransform>().anchoredPosition;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        CheckInterations();

    }

    public void CheckInterations()
    {
        if (NPCInteractor.selection != null && fadeInOut.fadeTransition == false)
        {
            //---------------CASCO--------------------
            if (NPCInteractor.selection.name == "RagazzoCheVuoleIlCasco" && this.gameObject.name == "CascoUI")
            {
                this.gameObject.SetActive(false);
                NPCInteractor.cascoPortato = true;
                Debug.Log("Casco consegnato!");
                forcinaUI.SetActive(true);


            }
            else
            {
                transform.GetComponent<RectTransform>().anchoredPosition = startPos;
            }

            //---------------SCOLAPASTA--------------------

            if (NPCInteractor.selection.name == "Bambino" && this.gameObject.name == "ScolapastaUI")
            {
                this.gameObject.SetActive(false);
                NPCInteractor.scolapastaPortato = true;
                Debug.Log("Scolapasta consegnato!");

            }
            else
            {
                transform.GetComponent<RectTransform>().anchoredPosition = startPos;
            }

            //---------------UOVO--------------------

            if (NPCInteractor.selection.name == "Bambino" && this.gameObject.name == "UovoUI")
            {
                this.gameObject.SetActive(false);
                NPCInteractor.uovoPortato = true;
                Debug.Log("Uovo consegnato!");
                bigliettoUI.SetActive(true);
            }
            else
            {
                transform.GetComponent<RectTransform>().anchoredPosition = startPos;
            }

            //---------------AUTOBUS--------------------

            if (NPCInteractor.selection.name == "Autobus" && this.gameObject.name == "BigliettoUI")
            {
                NPCInteractor.ViaggioInAutobus();
            }


            //if else degli altri npc
        }
        else
        {
            transform.GetComponent<RectTransform>().anchoredPosition = startPos;
        }

    }
}
