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
            /*foreach (PolygonCollider2D c in collision.transform.root.GetComponents<PolygonCollider2D>())
            {
                c.enabled = false;
            }*/

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            /*foreach (PolygonCollider2D c in collision.transform.root.GetComponents<PolygonCollider2D>())
            {
                c.enabled = true;
            }*/
            collision.transform.root.GetComponent<PolygonCollider2D>().enabled = true;

            collision.transform.root.GetChild(2).gameObject.SetActive(false);
        }
    }

}
