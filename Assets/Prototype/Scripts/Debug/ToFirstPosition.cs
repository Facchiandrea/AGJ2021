using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToFirstPosition : MonoBehaviour
{
    public ViewModeSwap viewModeSwap;
    private Vector3 startPos;
    public Transform lunaPos;
    public Transform mongolfieraPos;


    void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && viewModeSwap.fullView == false)
        {
            transform.position = startPos;
        }
        if (Input.GetKeyDown(KeyCode.L) && viewModeSwap.fullView == false)
        {
            transform.position = lunaPos.position;
        }
        if (Input.GetKeyDown(KeyCode.M) && viewModeSwap.fullView == false)
        {
            transform.position = mongolfieraPos.position;
        }
    }
}
