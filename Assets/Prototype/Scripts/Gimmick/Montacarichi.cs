using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Montacarichi : MonoBehaviour
{
    public DistanceCheck distanceCheck;
    public bool playerInRange;
    public bool montacarichiRiparato;

    private void Update()
    {
        if (distanceCheck.playerIn)
        {
            playerInRange = true;
        }

        else
        {
            playerInRange = false;

        }
    }
}
