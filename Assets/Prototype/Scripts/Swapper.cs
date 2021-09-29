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

    public bool transition = false;

    public GameObject barriersPaint1;
    public GameObject barriersPaint2;
    public GameObject barriersPaint3;
    public GameObject barriersPaint4;
    public GameObject barriersPaint5;
    public GameObject barriersPaint6;
    public GameObject barriersPaint7;
    public GameObject barriersPaint8;
    public GameObject barriersPaint9;
    public GameObject barriersPaint10;
    public GameObject barriersPaint11;
    public GameObject barriersPaint12;


    private void Start()
    {
        selectionCounter = 0;
    }


    void FixedUpdate()
    {

        if (selectionCounter == 2 && transition == false)
        {
            StartSwap();
            transition = true;
        }

        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<SpriteRenderer>();
            selectionRenderer.sprite = notSelectedSprite;
            _selection = null;
            PaintHovered = false;
            OnPaintSelected = false;
        }

        if (viewModeSwap.fullView && transition == false)
        {

            int layerMask = 1 << 8;
            Vector2 cubeRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D cubeHit = Physics2D.Raycast(cubeRay, Vector2.zero, 1000f, layerMask);
            selection = cubeHit.transform;

            if (cubeHit && cubeHit.collider.transform.root.CompareTag("SelectedPainting"))
            {
                if (OnPaintSelected == false)
                {
                    OnPaintSelected = true;
                }
            }

            else if (cubeHit && cubeHit.collider.transform.root.CompareTag("Painting"))
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
        if (viewModeSwap.fullView == false && selectedPaint1 != null)
        {
            selectedPaint1.GetChild(0).gameObject.SetActive(false);
            selectedPaint1.gameObject.tag = "Painting";
            selectedPaint1 = null;
            selectionCounter = 0;
        }

        if (Input.GetMouseButtonDown(0) && selectionCounter == 1 && OnPaintSelected)
        {
            selectionCounter--;
            selectedPaint1.transform.gameObject.tag = "Painting";
            selectedPaint1.GetChild(0).gameObject.SetActive(false);
            OnPaintSelected = false;
            selectedPaint1 = null;
        }

        if (Input.GetMouseButtonDown(0) && PaintHovered)
        {
            if (selectionCounter == 0)
            {
                selection.transform.gameObject.tag = "SelectedPainting";
                selection.GetChild(0).gameObject.SetActive(true);
                selectionCounter++;
                selectedPaint1 = selection.transform;

            }
            else if (selectionCounter == 1)
            {
                selection.transform.gameObject.tag = "SelectedPainting";
                selection.GetChild(0).gameObject.SetActive(true);
                selectionCounter++;
                selectedPaint2 = selection.transform;
            }
        }


    }
    public void StartSwap()
    {
        selectedPaint1.GetChild(0).gameObject.SetActive(false);
        selectedPaint2.GetChild(0).gameObject.SetActive(false);

        FadeIn();
        Invoke("FadeOut", 1f);
        Invoke("Swap", 1f);
        Invoke("EndSwap", 2f);


    }
    public void Swap()
    {
        Vector3 tempPosition = selectedPaint1.transform.position;
        selectedPaint1.transform.position = selectedPaint2.transform.position;
        selectedPaint2.transform.position = tempPosition;
    }

    public void EndSwap()
    {
        selectedPaint1.GetChild(2).gameObject.SetActive(false);
        selectedPaint2.GetChild(2).gameObject.SetActive(false);


        selectionCounter = 0;
        selectedPaint1.transform.gameObject.tag = "Painting";
        selectedPaint2.transform.gameObject.tag = "Painting";
        transition = false;

        selectedPaint1 = null;
        selectedPaint2 = null;

        ResetBarriers();

    }
    public void FadeIn()
    {
        selectedPaint1.GetChild(1).gameObject.SetActive(true);
        selectedPaint2.GetChild(1).gameObject.SetActive(true);
    }
    public void FadeOut()
    {
        selectedPaint1.GetChild(1).gameObject.SetActive(false);
        selectedPaint2.GetChild(1).gameObject.SetActive(false);

        selectedPaint1.GetChild(2).gameObject.SetActive(true);
        selectedPaint2.GetChild(2).gameObject.SetActive(true);

    }

    public void ResetBarriers()
    {
        barriersPaint1.SetActive(true);
        barriersPaint1.transform.GetChild(0).gameObject.SetActive(true);
        barriersPaint1.transform.GetChild(1).gameObject.SetActive(true);

        barriersPaint2.SetActive(true);
        barriersPaint2.transform.GetChild(0).gameObject.SetActive(true);
        barriersPaint2.transform.GetChild(1).gameObject.SetActive(true);

        barriersPaint3.SetActive(true);
        barriersPaint3.transform.GetChild(0).gameObject.SetActive(true);
        barriersPaint3.transform.GetChild(1).gameObject.SetActive(true);

        barriersPaint4.SetActive(true);
        barriersPaint4.transform.GetChild(0).gameObject.SetActive(true);
        barriersPaint4.transform.GetChild(1).gameObject.SetActive(true);

        barriersPaint5.SetActive(true);
        barriersPaint5.transform.GetChild(0).gameObject.SetActive(true);
        barriersPaint5.transform.GetChild(1).gameObject.SetActive(true);

        barriersPaint6.SetActive(true);
        barriersPaint6.transform.GetChild(0).gameObject.SetActive(true);
        barriersPaint6.transform.GetChild(1).gameObject.SetActive(true);

        barriersPaint7.SetActive(true);
        barriersPaint7.transform.GetChild(0).gameObject.SetActive(true);
        barriersPaint7.transform.GetChild(1).gameObject.SetActive(true);

        barriersPaint8.SetActive(true);
        barriersPaint8.transform.GetChild(0).gameObject.SetActive(true);
        barriersPaint8.transform.GetChild(1).gameObject.SetActive(true);

        barriersPaint9.SetActive(true);
        barriersPaint9.transform.GetChild(0).gameObject.SetActive(true);
        barriersPaint9.transform.GetChild(1).gameObject.SetActive(true);

        barriersPaint10.SetActive(true);
        barriersPaint10.transform.GetChild(0).gameObject.SetActive(true);
        barriersPaint10.transform.GetChild(1).gameObject.SetActive(true);

        barriersPaint11.SetActive(true);
        barriersPaint11.transform.GetChild(0).gameObject.SetActive(true);
        barriersPaint11.transform.GetChild(1).gameObject.SetActive(true);

        barriersPaint12.SetActive(true);
        barriersPaint12.transform.GetChild(0).gameObject.SetActive(true);
        barriersPaint12.transform.GetChild(1).gameObject.SetActive(true);

    }
}
