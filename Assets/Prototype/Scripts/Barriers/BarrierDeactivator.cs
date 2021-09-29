using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierDeactivator : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            this.gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }

    }
}
