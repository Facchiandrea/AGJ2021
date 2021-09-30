using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelection : MonoBehaviour
{
    public ViewModeSwap viewModeSwap;
    private Transform _selectionItem;
    public Transform selection;


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
            int layerMask = LayerMask.GetMask("ObjectsLayer");
            Vector2 cubeRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D cubeHit = Physics2D.Raycast(cubeRay, Vector2.zero, 1000f, layerMask);

            if (cubeHit && cubeHit.transform.CompareTag("Item"))
            {
                selection = cubeHit.transform;
                selection.GetChild(0).gameObject.SetActive(true);
                _selectionItem = selection;
            }

        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selection != null)
            {
                if (selection.name == "Casco" && selection.GetComponent<PickUpCasco>().canPickUp == true)
                {
                    selection.GetComponent<PickUpCasco>().PickUpUIGraphics.SetActive(true);
                    selection.GetComponent<PickUpCasco>().PickUpGraphics.SetActive(false);

                    selection.gameObject.SetActive(false);
                    Debug.Log("Hai raccolto il casco");

                }
                else if (selection.name == "Casco" && selection.GetComponent<PickUpCasco>().canPickUp == false)
                {
                    Debug.Log("E' un casco da astronauta");
                }

            }
        }
    }
}
