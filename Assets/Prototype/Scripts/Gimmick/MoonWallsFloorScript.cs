using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonWallsFloorScript : MonoBehaviour
{
    public Mongolfiera mongolfiera;

    private void Update()
    {
        if (mongolfiera.traveling == true)
        {
            GetComponent<PolygonCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<PolygonCollider2D>().enabled = true;
        }
    }
}
