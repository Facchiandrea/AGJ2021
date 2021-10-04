using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mongolfiera : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public FadeInOut fadeInOut;
    public DistanceCheck distanceCheck;
    public bool playerInRange;
    public bool lunaSopra;
    public bool terraSotto;

    public Transform InizioPlayerFuori;

    public Transform ArrivoPlayerFuori;

    public Transform StazioneLuna;
    public Transform StazioneTerra;


    public bool playerSullaLuna;

    public LunaDetector lunaDetector;
    public TerraDetector terraDetector;
    public GameObject player;

    public float travelTime = 5f;
    public bool traveling = false;

    public DialogueManager dialogueManager;


    private void Update()
    {
        if (traveling)
        {
            player.transform.position = new Vector3(transform.position.x, transform.position.y - 3, player.transform.position.z);
        }

        if (playerSullaLuna && traveling == false)
        {
            transform.position = StazioneLuna.position;
        }
        else if (playerSullaLuna == false && traveling == false)
        {
            transform.position = StazioneTerra.position;
        }


        if (lunaDetector.lunaTrovata == true)
        {
            lunaSopra = true;
        }
        else
        {
            lunaSopra = false;
        }

        if (terraDetector.terraTrovata == true)
        {
            terraSotto = true;
        }
        else
        {
            terraSotto = false;

        }

        if (distanceCheck.playerIn)
        {
            playerInRange = true;
        }

        else
        {
            playerInRange = false;

        }
    }

    public void ViaggioInMongolfiera()
    {
        if (playerSullaLuna == false)
        {
            player.GetComponentInChildren<SpriteRenderer>().enabled = false;
            transform.GetChild(1).gameObject.SetActive(true);
            playerMovement.movementBlock = true;
            Invoke("ControlloDestinazione", 1.5f);
            traveling = true;

        }
        else
        {
            player.GetComponentInChildren<SpriteRenderer>().enabled = false;
            transform.GetChild(1).gameObject.SetActive(true);
            playerMovement.movementBlock = true;
            Invoke("ControlloDestinazione", 1.5f);
            traveling = true;

        }
    }

    public void ControlloDestinazione()
    {
        if (playerSullaLuna == false && lunaSopra)
        {
            StartCoroutine(SpostamentoVersoLuna());
            this.gameObject.tag = "InactiveNPC";

        }
        else if (playerSullaLuna == true && terraSotto)
        {
            StartCoroutine(SpostamentoVersoTerra());
            this.gameObject.tag = "InactiveNPC";

        }
        else if (playerSullaLuna == false && lunaSopra == false)
        {
            if (dialogueManager.inDialogue == false)
            {
                dialogueManager.dialogue.sentences.Clear();
                dialogueManager.sentences.Clear();
                dialogueManager.dialogue.names.Clear();
                dialogueManager.names.Clear();

                dialogueManager.dialogue.names.Add("Artemisia");

                dialogueManager.dialogue.sentences.Add("Mmm...forse dovrei prima avere una destinazione");

                dialogueManager.StartDialogue(dialogueManager.dialogue);
                dialogueManager.DisplayNextSentence();

            }

            Invoke("ScendiDallaMongolfiera", 0.5f);
        }
        else if (playerSullaLuna == true && terraSotto == false)
        {
            if (dialogueManager.inDialogue == false)
            {
                dialogueManager.dialogue.sentences.Clear();
                dialogueManager.sentences.Clear();
                dialogueManager.dialogue.names.Clear();
                dialogueManager.names.Clear();

                dialogueManager.dialogue.names.Add("Artemisia");

                dialogueManager.dialogue.sentences.Add("Mmm...forse dovrei prima impostare la rotta per il luogo da cui sono partita");

                dialogueManager.StartDialogue(dialogueManager.dialogue);
                dialogueManager.DisplayNextSentence();

            }
            Invoke("ScendiDallaMongolfiera", 0.5f);
        }

    }

    public void ScendiDallaMongolfiera()
    {
        if (playerSullaLuna)
        {
            traveling = false;
            Invoke("PosizionamentoPlayerLuna", 0.1f);


        }
        else if (playerSullaLuna == false)
        {
            traveling = false;
            Invoke("PosizionamentoPlayerTerra", 0.1f);

        }
    }

    public IEnumerator SpostamentoVersoTerra()
    {
        float progress = 0;

        while (progress < travelTime && traveling == true)
        {
            playerMovement.movementBlock = true;

            transform.position = Vector2.Lerp(StazioneLuna.position, StazioneTerra.position, (progress / travelTime));
            progress += Time.deltaTime;
            yield return null;
        }
        new WaitForSeconds(travelTime);
        transform.position = StazioneTerra.position;
        playerSullaLuna = false;
        this.gameObject.tag = "NPC";
        ScendiDallaMongolfiera();

        yield return null;

    }

    public IEnumerator SpostamentoVersoLuna()
    {
        float progress = 0;

        while (progress < travelTime && traveling == true)
        {
            playerMovement.movementBlock = true;

            transform.position = Vector2.Lerp(StazioneTerra.position, StazioneLuna.position, (progress / travelTime));
            progress += Time.deltaTime;
            yield return null;
        }
        new WaitForSeconds(travelTime);
        transform.position = StazioneLuna.position;
        playerSullaLuna = true;
        this.gameObject.tag = "NPC";
        ScendiDallaMongolfiera();

        yield return null;
    }

    public void PosizionamentoPlayerLuna()
    {
        player.transform.position = ArrivoPlayerFuori.position;
        transform.GetChild(1).gameObject.SetActive(false);
        player.GetComponentInChildren<SpriteRenderer>().enabled = true;
        playerMovement.movementBlock = false;

    }
    public void PosizionamentoPlayerTerra()
    {
        player.transform.position = InizioPlayerFuori.position;
        transform.GetChild(1).gameObject.SetActive(false);
        player.GetComponentInChildren<SpriteRenderer>().enabled = true;
        playerMovement.movementBlock = false;

    }
}
