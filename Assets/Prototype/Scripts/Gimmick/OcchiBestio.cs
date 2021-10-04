using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcchiBestio : MonoBehaviour
{
    private SpriteRenderer SR;
    private void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SR.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SR.enabled = false;
        }

    }
}
