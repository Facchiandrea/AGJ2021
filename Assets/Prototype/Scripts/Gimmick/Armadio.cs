﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadio : MonoBehaviour
{
    public DistanceCheck distanceCheck;
    public bool playerInRange;
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