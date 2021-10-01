using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScolapasta : MonoBehaviour
{
    public DistanceCheck distanceCheck;

    public GameObject PickUpGraphics;
    public GameObject PickUpUIGraphics;
    public bool playerInRange;

    public bool canPickUp = false; //questa bool va a true quando fai l'interazione relativa ad esso

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
