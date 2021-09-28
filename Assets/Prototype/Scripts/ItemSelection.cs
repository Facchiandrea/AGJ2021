using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelection : MonoBehaviour
{
    public ViewModeSwap viewModeSwap;
    private Transform _selectionItem;
    private Transform selection;


    private void FixedUpdate()
    {
        if (_selectionItem != null)
        {
            selection.GetChild(0).gameObject.SetActive(false);
            _selectionItem = null;
        }

        if (viewModeSwap.fullView == false)
        {
            int layerMask = LayerMask.GetMask("ObjectsLayer");
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
}
