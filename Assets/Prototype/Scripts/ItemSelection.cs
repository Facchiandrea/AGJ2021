using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelection : MonoBehaviour
{
    public ViewModeSwap viewModeSwap;

    private void FixedUpdate()
    {
        if (viewModeSwap.fullView == false)
        {
            int layerMask = 1 << 9;
            Vector2 cubeRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D cubeHit = Physics2D.Raycast(cubeRay, Vector2.zero, layerMask);

            if (cubeHit)
            {
                Debug.Log("We hovered " + cubeHit.collider.name);
            }

        }
    }
}
