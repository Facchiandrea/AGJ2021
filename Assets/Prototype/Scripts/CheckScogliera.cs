using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScogliera : MonoBehaviour
{
    public Scala scala;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            scala.playerAllaScogliera = true;
        }
    }
}
