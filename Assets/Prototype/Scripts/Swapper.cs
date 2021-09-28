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

    public bool OnPaintSelected;
    public bool PaintHovered;

    public Transform selection;

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

        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<SpriteRenderer>();
            selectionRenderer.sprite = notSelectedSprite;
            _selection = null;
            PaintHovered = false;
            OnPaintSelected = false;
        }

        if (viewModeSwap.fullView)
        {

            int layerMask = 1 << 8;
            Vector2 cubeRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D cubeHit = Physics2D.Raycast(cubeRay, Vector2.zero, 1000f, layerMask);
            selection = cubeHit.transform;

            if (cubeHit && cubeHit.collider.CompareTag("SelectedPainting"))
            {
                if (OnPaintSelected == false)
                {
                    OnPaintSelected = true;
                }
            }

            else if (cubeHit && cubeHit.collider.CompareTag("Painting"))
            {
                if (PaintHovered == false)
                {
                    PaintHovered = true;
                }

                var selectionRenderer = selection.GetComponent<SpriteRenderer>();

                if (selectionRenderer != null)
                {
                    selectionRenderer.sprite = hoveredSprite;
                }


            }
            _selection = selection;

        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && selectionCounter == 1 && OnPaintSelected)
        {
            selectionCounter--;
            selectedPaint1.root.tag = "Painting";
            selectedPaint1.GetChild(0).gameObject.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0) && PaintHovered)
        {
            if (selectionCounter == 0)
            {
                selection.root.tag = "SelectedPainting";
                selection.GetChild(0).gameObject.SetActive(true);
                selectionCounter++;
                selectedPaint1 = selection.transform;

            }
            else if (selectionCounter == 1)
            {
                selection.root.tag = "SelectedPainting";
                selection.GetChild(0).gameObject.SetActive(true);
                selectionCounter++;
                selectedPaint2 = selection.transform;
            }
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
