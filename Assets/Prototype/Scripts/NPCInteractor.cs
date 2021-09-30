using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractor : MonoBehaviour
{
    public ViewModeSwap viewModeSwap;
    private Transform _selectionItem;
    public Transform selection;

    public PickUpCasco pickUpCascoScript;
    public bool cascoPortato = false;

    private void FixedUpdate()
    {
        if (_selectionItem != null)
        {
            selection.GetChild(0).gameObject.SetActive(false);
            _selectionItem = null;
            selection = null;
        }

        if (viewModeSwap.fullView == false && viewModeSwap.transitionToSingle == false)
        {
            int layerMask = LayerMask.GetMask("NPCs");
            Vector2 cubeRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D cubeHit = Physics2D.Raycast(cubeRay, Vector2.zero, 1000f, layerMask);

            if (cubeHit)
            {
                selection = cubeHit.transform;
                selection.GetChild(0).gameObject.SetActive(true);
                _selectionItem = selection;
            }

        }
    }

    private void Update()
    {
        if (selection != null)
        {
            if (Input.GetMouseButtonDown(0) && selection.name == "RagazzoCheVuoleIlCasco" && cascoPortato == false)
            {
                Debug.Log("Mi serve un casco");
                pickUpCascoScript.canPickUp = true;
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "RagazzoCheVuoleIlCasco" && cascoPortato == true)
            {
                Debug.Log("Grazie per il casco!");
            }

        }
    }
}
