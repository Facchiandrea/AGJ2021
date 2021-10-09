using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNiBBa : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            collision.transform.parent.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0.2142399f, 0.2883942f, 0.6415094f);
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
