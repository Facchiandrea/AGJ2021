using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptItemManager : MonoBehaviour
{
    public GameObject[] Items;
    public GameObject[] NPC;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            foreach (var item in Items)
            {
                item.tag = "Item";
            }

            foreach (var npc in NPC)
            {
                npc.tag = "NPC";
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
            foreach (var npc in NPC)
            {
                npc.tag = "InactiveNPC";
            }


        }

    }
}
