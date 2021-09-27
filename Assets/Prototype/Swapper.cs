using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swapper : MonoBehaviour
{
    public ViewModeSwap viewModeSwap;
    private Transform _selection;
    public Sprite notSelectedSprite;
    public Sprite selectedSprite;



    void FixedUpdate()
    {

        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<SpriteRenderer>();
            selectionRenderer.sprite = notSelectedSprite;
            _selection = null;
        }

        int layerMask = 1 << 8;
        Vector2 cubeRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D cubeHit = Physics2D.Raycast(cubeRay, Vector2.zero, layerMask);
        var selection = cubeHit.transform;

        if (cubeHit && cubeHit.collider.CompareTag("Painting"))
        {
            Debug.Log("We hit " + cubeHit.collider.name);
            var selectionRenderer = selection.GetComponent<SpriteRenderer>();

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Funge");
            }
            if (selectionRenderer != null)
            {
                selectionRenderer.sprite = selectedSprite;
            }


        }
        _selection = selection;
    }
}
