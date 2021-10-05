using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNiBBa : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            collision.transform.parent.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0.254902f, 0.3215686f, 0.5019608f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            collision.transform.parent.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);

        }
    }
}
