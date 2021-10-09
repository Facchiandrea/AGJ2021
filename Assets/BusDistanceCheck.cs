using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusDistanceCheck : MonoBehaviour
{
    public NPCInteractor NPCInteractor;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Activator")
        {
            NPCInteractor.autobusInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Activator")
        {
            NPCInteractor.autobusInRange = false;
        }

    }

}
