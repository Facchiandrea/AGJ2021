using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swapper : MonoBehaviour
{
    public ViewModeSwap viewModeSwap;
    private Transform _selection;
    public Sprite notSelectedSprite;
    public Sprite hoveredSprite;
    public Sprite selectedSprite;

    public int selectionCounter;
    public Transform selectedPaint1;
    public Transform selectedPaint2;

    private void Start()
    {
        selectionCounter = 0;
    }


    void FixedUpdate()
    {

        if (selectionCounter == 2)
        {
            Swap();
        }


        if (viewModeSwap.fullView)
        {

            if (_selection != null)
            {
                var selectionRenderer = _selection.GetComponent<SpriteRenderer>();
                selectionRenderer.sprite = notSelectedSprite;
                _selection = null;
            }

            int layerMask = 1 << 8 | 1 << 9;
            Vector2 cubeRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D cubeHit = Physics2D.Raycast(cubeRay, Vector2.zero, layerMask);
            var selection = cubeHit.transform;

            if (cubeHit && cubeHit.collider.CompareTag("SelectedPainting"))
            {
                Debug.Log("We hit " + cubeHit.collider.name);
                if (Input.GetMouseButtonDown(0) && selectionCounter == 1)
                {
                    selectionCounter--;
                    selectedPaint1.root.tag = "Painting";
                    selectedPaint1.GetChild(0).gameObject.SetActive(false);
                }
            }

            else if (cubeHit && cubeHit.collider.CompareTag("Painting"))
            {
                Debug.Log("We hit " + cubeHit.collider.name);
                var selectionRenderer = selection.GetComponent<SpriteRenderer>();

                if (Input.GetMouseButtonDown(0))
                {
                    if (selectionCounter == 0)
                    {
                        Debug.Log("Funge");
                        cubeHit.collider.transform.root.tag = "SelectedPainting";
                        cubeHit.collider.transform.GetChild(0).gameObject.SetActive(true);
                        selectionCounter++;
                        selectedPaint1 = cubeHit.transform;

                    }
                    else if (selectionCounter == 1)
                    {
                        Debug.Log("Funge");
                        cubeHit.collider.transform.root.tag = "SelectedPainting";
                        cubeHit.collider.transform.GetChild(0).gameObject.SetActive(true);
                        selectionCounter++;
                        selectedPaint2 = cubeHit.transform;
                    }
                }

                if (selectionRenderer != null)
                {
                    selectionRenderer.sprite = hoveredSprite;
                }


            }
            _selection = selection;


        }
    }
    public void Swap()
    {
        selectedPaint1.GetChild(0).gameObject.SetActive(false);
        selectedPaint2.GetChild(0).gameObject.SetActive(false);

        Vector3 tempPosition = selectedPaint1.transform.position;
        selectedPaint1.transform.position = selectedPaint2.transform.position;
        selectedPaint2.transform.position = tempPosition;
        selectionCounter = 0;
        selectedPaint1.root.tag = "Painting";
        selectedPaint2.root.tag = "Painting";
    }
}
