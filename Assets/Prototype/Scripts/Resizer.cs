using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resizer : MonoBehaviour
{
    public Vector3 scaleOfThisPainting;
    private float positionRegulator;
    private void Start()
    {
        positionRegulator = scaleOfThisPainting.y;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator") && collision.transform.root.transform.GetChild(0).localScale != scaleOfThisPainting)
        {
            //collision.transform.root.transform.GetChild(0).position = new Vector3(collision.transform.root.transform.GetChild(0).position.x, 0, collision.transform.root.transform.GetChild(0).position.z);
            Vector3 tempSize = collision.transform.root.transform.GetChild(0).localScale;
            collision.transform.root.transform.GetChild(0).localScale = scaleOfThisPainting;

            if (collision.transform.root.transform.GetChild(0).localScale.y < scaleOfThisPainting.y)
            {
                collision.transform.root.transform.GetChild(0).position = new Vector3
                (collision.transform.root.transform.GetChild(0).position.x, collision.transform.root.transform.GetChild(0).position.y + (scaleOfThisPainting.y - tempSize.y), collision.transform.root.transform.GetChild(0).position.z);

            }
            else
            {
                collision.transform.root.transform.GetChild(0).position = new Vector3
                (collision.transform.root.transform.GetChild(0).position.x, collision.transform.root.transform.GetChild(0).position.y - (tempSize.y - scaleOfThisPainting.y), collision.transform.root.transform.GetChild(0).position.z);

            }


        }
    }
}
