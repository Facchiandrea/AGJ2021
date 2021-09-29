using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptItemManager : MonoBehaviour
{
    public GameObject[] Items;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            foreach (var item in Items)
            {
                item.tag = "Item";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            foreach (var item in Items)
            {
                item.tag = "InactiveItem";
            }
        }

    }
}
