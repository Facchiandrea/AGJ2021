using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonteLevatoio : MonoBehaviour
{
    public NPCInteractor NPCInteractorScript;
    public bool ponteAbbassato;
    //private float flipTime = 10f;
    //private float flipSpeed = 1f;
    //public bool siStaAbbassando;
    //private Quaternion notFlippedPosition;
    //private Quaternion flippedPosition;
    public PlayerMovement playerMovement;
    public GameObject barrieraFosso;
    public GameObject fosso;
    public GameObject portaFinta;

    private void Start()
    {
        //notFlippedPosition = Quaternion.Euler(0, 0, 0);
        //flippedPosition = Quaternion.Euler(0, 0, 90);

    }
    private void Update()
    {
        if (NPCInteractorScript.scolapastaPortato == true && ponteAbbassato == false)// && siStaAbbassando == false)
        {
            //StartCoroutine(BridgeMovingCoroutine());
            ponteAbbassato = true;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            fosso.SetActive(false);
            barrieraFosso.GetComponent<BoxCollider2D>().enabled = false;
            portaFinta.SetActive(true);
        }
    }

    /*public IEnumerator BridgeMovingCoroutine()
    {
        float progress = 0;
        while (progress < flipTime)
        {
            playerMovement.movementBlock = true;

            siStaAbbassando = true;
            transform.rotation = Quaternion.Lerp(notFlippedPosition, flippedPosition, progress * flipSpeed);
            progress += Time.deltaTime;
            if (transform.rotation.eulerAngles.z >= 90)
            {
                fosso.SetActive(false);
                barrieraFosso.GetComponent<BoxCollider2D>().enabled = false;
                transform.rotation = flippedPosition;
                siStaAbbassando = false;
                ponteAbbassato = true;
                playerMovement.movementBlock = false;

            }

            yield return null;

        }

    }*/
}
