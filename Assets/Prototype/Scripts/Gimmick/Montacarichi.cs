using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Montacarichi : MonoBehaviour
{
    public DistanceCheck distanceCheck;
    public bool playerInRange;
    public bool montacarichiRiparato;
    public PlayerMovement playerMovement;
    public bool montacarichiATerra = true;
    public float travelTime = 2f;
    public bool traveling;
    public Transform startPos;
    public Transform endPos;

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
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("Spostamento_Montacarichi_sfx");
        }

        playerMovement.movementBlock = true;
        playerMovement.rb.velocity = new Vector2(0, playerMovement.rb.velocity.y);
        playerMovement.GetComponent<Animator>().SetBool("IsWalking", false);
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
        Debug.Log("sne");

        float progress = 0;

        while (progress < travelTime && traveling == true)
        {
            transform.position = Vector2.Lerp(startPos.position, endPos.position, (progress / travelTime));
            progress += Time.deltaTime;
            yield return null;
        }
        new WaitForSeconds(travelTime);
        transform.position = endPos.position;
        montacarichiATerra = false;
        traveling = false;
        this.gameObject.tag = "NPC";
        playerMovement.movementBlock = false;

        yield return null;
    }

    public IEnumerator MontacarichiScende()
    {
        Debug.Log("sas");
        float progress = 0;

        while (progress < travelTime && traveling == true)
        {
            transform.position = Vector2.Lerp(endPos.position, startPos.position, (progress / travelTime));
            progress += Time.deltaTime;
            yield return null;
        }
        new WaitForSeconds(travelTime);
        transform.position = startPos.position;
        montacarichiATerra = true;
        traveling = false;
        this.gameObject.tag = "NPC";
        playerMovement.movementBlock = false;

        yield return null;
    }

}
