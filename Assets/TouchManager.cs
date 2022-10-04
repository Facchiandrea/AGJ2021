using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchManager : MonoBehaviour
{
    public int touchCount;
    public int fingerNum;

    void Update()
    {
        if (Input.touchCount > touchCount)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.touches[i].phase == TouchPhase.Began)
                {
                    fingerNum = Input.touches[i].fingerId;
                }
            }
        }
        touchCount = Input.touchCount;
    }
}
