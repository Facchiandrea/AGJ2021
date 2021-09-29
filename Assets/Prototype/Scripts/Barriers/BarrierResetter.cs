using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierResetter : MonoBehaviour
{
    public Swapper swapper;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Activator"))
        {
            swapper.ResetBarriers();
        }
    }
}
