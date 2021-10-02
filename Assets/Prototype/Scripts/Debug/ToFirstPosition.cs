using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToFirstPosition : MonoBehaviour
{
    public ViewModeSwap viewModeSwap;
    private Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && viewModeSwap.fullView == false)
        {
            transform.position = startPos;
        }
    }

}
