using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderFixer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            collision.transform.root.GetChild(2).gameObject.SetActive(true);
            collision.transform.root.GetComponent<PolygonCollider2D>().enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            collision.transform.root.GetComponent<PolygonCollider2D>().enabled = true;
            collision.transform.root.GetChild(2).gameObject.SetActive(false);
        }
    }

}
