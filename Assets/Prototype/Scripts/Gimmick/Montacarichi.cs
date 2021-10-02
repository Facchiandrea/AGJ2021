using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Montacarichi : MonoBehaviour
{
    public DistanceCheck distanceCheck;
    public bool playerInRange;
    public bool montacarichiRiparato;
    public PlayerMovement playerMovement;
    public bool montacarichiATerra;
    public float travelTime = 5f;
    public bool traveling;
    private Vector3 startPos;
    private Vector3 endPos;

    private void Start()
    {
        startPos = transform.position;
        endPos = new Vector3(startPos.x, startPos.y + 2.35f, startPos.z);
    }
    private void Update()
    {
        if (distanceCheck.playerIn)
        {
            playerInRange = true;
        }

        else
        {
            playerInRange = false;

        }
    }

    public void SpostamentoInMontacarichi()
    {
        playerMovement.movementBlock = true;
        if (montacarichiATerra == true)
        {
            traveling = true;
            this.gameObject.tag = "InactiveNPC";
            StartCoroutine(MontacarichiSale());
        }
        else
        {
            traveling = true;
            this.gameObject.tag = "InactiveNPC";
            StartCoroutine(MontacarichiScende());
        }
    }

    public IEnumerator MontacarichiSale()
    {
        float progress = 0;

        while (progress < travelTime && traveling == true)
        {
            transform.position = Vector2.Lerp(startPos, endPos, (progress / travelTime));
            progress += Time.deltaTime;
            yield return null;
        }
        new WaitForSeconds(travelTime);
        transform.position = endPos;
        montacarichiATerra = false;
        traveling = false;
        this.gameObject.tag = "NPC";
        playerMovement.movementBlock = false;

        yield return null;
    }

    public IEnumerator MontacarichiScende()
    {
        float progress = 0;

        while (progress < travelTime && traveling == true)
        {
            transform.position = Vector2.Lerp(endPos, startPos, (progress / travelTime));
            progress += Time.deltaTime;
            yield return null;
        }
        new WaitForSeconds(travelTime);
        transform.position = startPos;
        montacarichiATerra = true;
        traveling = false;
        this.gameObject.tag = "NPC";
        playerMovement.movementBlock = false;

        yield return null;
    }

}
