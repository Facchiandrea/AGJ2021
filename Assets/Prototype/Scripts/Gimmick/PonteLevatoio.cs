using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonteLevatoio : MonoBehaviour
{
    public NPCInteractor NPCInteractorScript;
    public bool ponteAbbassato;
    private float flipTime = 10f;
    private float flipSpeed = 1f;
    public bool siStaAbbassando;
    private Quaternion notFlippedPosition;
    private Quaternion flippedPosition;
    public PlayerMovement playerMovement;

    private void Start()
    {
        notFlippedPosition = Quaternion.Euler(0, 0, 0);
        flippedPosition = Quaternion.Euler(0, 0, 90);

    }
    private void Update()
    {
        if (NPCInteractorScript.scolapastaPortato == true && ponteAbbassato == false)
        {
            StartCoroutine(BridgeMovingCoroutine());
        }
    }

    public IEnumerator BridgeMovingCoroutine()
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
                transform.rotation = flippedPosition;
                siStaAbbassando = false;
                ponteAbbassato = true;
                playerMovement.movementBlock = true;

            }

            yield return null;

        }

    }
}
