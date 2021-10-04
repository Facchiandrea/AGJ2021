using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelection : MonoBehaviour
{
    public ViewModeSwap viewModeSwap;
    private Transform _selectionItem;
    public Transform selection;
    public MorbidDetector MorbidDetector;
    public NPCInteractor NPCInteractor;
    public DialogueManager dialogueManager;



    private void FixedUpdate()
    {
        if (_selectionItem != null)
        {
            selection.GetChild(0).gameObject.SetActive(false);
            _selectionItem = null;
            selection = null;
        }

        if (viewModeSwap.fullView == false && viewModeSwap.transitionToSingle == false)
        {
            int layerMask = LayerMask.GetMask("ObjectsLayer");
            Vector2 cubeRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D cubeHit = Physics2D.Raycast(cubeRay, Vector2.zero, 1000f, layerMask);

            if (cubeHit && cubeHit.transform.CompareTag("Item"))
            {
                selection = cubeHit.transform;
                selection.GetChild(0).gameObject.SetActive(true);
                _selectionItem = selection;
            }

        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selection != null)
            {
                //---------------------CASCO--------------------------
                if (selection.name == "Casco" && selection.GetComponent<PickUpCasco>().canPickUp == true && selection.GetComponent<PickUpCasco>().playerInRange == true)
                {
                    selection.GetComponent<PickUpCasco>().PickUpUIGraphics.SetActive(true);
                    selection.GetComponent<PickUpCasco>().PickUpGraphics.SetActive(false);

                    selection.gameObject.SetActive(false);

                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("Questo casco è proprio quello che mi serve");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);

                    }
                }
                else if (selection.name == "Casco" && selection.GetComponent<PickUpCasco>().canPickUp == true && selection.GetComponent<PickUpCasco>().playerInRange == false)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("Questo casco potrebbe servirmi, ma non posso prenderlo da qui");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);

                    }
                }

                else if (selection.name == "Casco" && selection.GetComponent<PickUpCasco>().canPickUp == false)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("E' un casco da astronauta");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);

                    }
                }
                //---------------------SCOLAPASTA--------------------------
                if (selection.name == "Scolapasta" && selection.GetComponent<PickUpScolapasta>().canPickUp == true && selection.GetComponent<PickUpScolapasta>().playerInRange == true)
                {
                    selection.GetComponent<PickUpScolapasta>().PickUpUIGraphics.SetActive(true);
                    selection.GetComponent<PickUpScolapasta>().PickUpGraphics.SetActive(false);

                    selection.gameObject.SetActive(false);

                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("Ho raccolto lo scolapasta");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }
                else if (selection.name == "Scolapasta" && selection.GetComponent<PickUpScolapasta>().canPickUp == true && selection.GetComponent<PickUpScolapasta>().playerInRange == false)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("Questo scolapasta potrebbe servirmi, ma non posso prenderlo da qui");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }

                else if (selection.name == "Scolapasta" && selection.GetComponent<PickUpScolapasta>().canPickUp == false)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("E' uno scolapasta");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }
                //---------------------UOVO--------------------------
                if (selection.name == "Uovo" && selection.GetComponent<PickUpUovo>().canPickUp == true && selection.GetComponent<PickUpUovo>().playerInRange == true)
                {
                    selection.GetComponent<PickUpUovo>().PickUpUIGraphics.SetActive(true);
                    selection.GetComponent<PickUpUovo>().PickUpGraphics.SetActive(false);

                    selection.gameObject.SetActive(false);
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("Ho raccolto l'uovo");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }
                else if (selection.name == "Uovo" && selection.GetComponent<PickUpUovo>().canPickUp == true && selection.GetComponent<PickUpUovo>().playerInRange == false)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("Questo uovo potrebbe servirmi, ma non posso prenderlo da qui");
                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }

                }

                else if (selection.name == "Uovo" && selection.GetComponent<PickUpUovo>().canPickUp == false)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("E' un uovo");
                        dialogueManager.dialogue.sentences.Add("Mi piacciono le uova");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }

                //-------------------------ROBA MORBIDA-----------------------------------

                if (selection.name == "Fiori")
                {
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("Questo tappeto di fiori sembra veramente soffice");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                    MorbidDetector.interactedWithFlowers = true;
                }
                if (selection.name == "Materassi")
                {
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("Quei materassi sembrano morbidi, peccato siano zozzi da fare schifo");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                    MorbidDetector.interactedWithMattress = true;
                }

                //-------------------------CESTINO/FIAMMIFERI-----------------------------------

                if (selection.name == "Cestino" && NPCInteractor.fiammiferiInInventario == true)
                {
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("Non credo ci sia altro che posso usare, li dentro");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }
                else if (selection.name == "Cestino" && selection.GetComponent<PickUpFiammiferi>().canPickUp == true && selection.GetComponent<PickUpFiammiferi>().playerInRange == true && selection.GetComponent<PickUpFiammiferi>().guardatoNelCestino == true)
                {
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("Ho raccolto i fiammiferi");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                    NPCInteractor.fiammiferiInInventario = true;
                    selection.GetComponent<PickUpFiammiferi>().PickUpUIGraphics.SetActive(true);
                }
                else if (selection.name == "Cestino" && selection.GetComponent<PickUpFiammiferi>().canPickUp == true && selection.GetComponent<PickUpFiammiferi>().playerInRange == true && selection.GetComponent<PickUpFiammiferi>().guardatoNelCestino == false)
                {
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("E' un cestino da picnic. Dentro ci sono dei tramezzini, dell'acqua e...dei fiammiferi! Potrei farne buon uso");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                    NPCInteractor.fiammiferiInInventario = true;
                    selection.GetComponent<PickUpFiammiferi>().PickUpUIGraphics.SetActive(true);
                    selection.GetComponent<PickUpFiammiferi>().guardatoNelCestino = true;
                }

                else if (selection.name == "Cestino" && selection.GetComponent<PickUpFiammiferi>().canPickUp == true && selection.GetComponent<PickUpFiammiferi>().playerInRange == false && selection.GetComponent<PickUpFiammiferi>().guardatoNelCestino == true)
                {
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("Nel cestino c'era qualcosa che potrebbe servirmi, ma sono troppo lontana");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }
                else if (selection.name == "Cestino" && selection.GetComponent<PickUpFiammiferi>().canPickUp == false && selection.GetComponent<PickUpFiammiferi>().playerInRange == false || selection.name == "Cestino" && selection.GetComponent<PickUpFiammiferi>().canPickUp == true && selection.GetComponent<PickUpFiammiferi>().playerInRange == false && selection.GetComponent<PickUpFiammiferi>().guardatoNelCestino == false)
                {
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("E' un cestino da picnic. Se mi avvicino potrei sbirciare dentro");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }

                else if (selection.name == "Cestino" && selection.GetComponent<PickUpFiammiferi>().canPickUp == false && selection.GetComponent<PickUpFiammiferi>().playerInRange == true)
                {
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("E' un cestino da picnic. Dentro ci sono dei tramezzini, dell'acqua e dei fiammiferi");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                    selection.GetComponent<PickUpFiammiferi>().guardatoNelCestino = true;
                }

                //---------------------CONCHIGLIA--------------------------
                if (selection.name == "Conchiglia" && selection.GetComponent<PickUpConchiglia>().canPickUp == true && selection.GetComponent<PickUpConchiglia>().playerInRange == true)
                {
                    selection.GetComponent<PickUpConchiglia>().PickUpUIGraphics.SetActive(true);
                    selection.GetComponent<PickUpConchiglia>().PickUpGraphics.SetActive(false);

                    selection.gameObject.SetActive(false);
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("Sì, questa va benissimo, spero che piacerà a quel vecchietto");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }
                else if (selection.name == "Conchiglia" && selection.GetComponent<PickUpConchiglia>().canPickUp == true && selection.GetComponent<PickUpConchiglia>().playerInRange == false)
                {
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("Quella conchiglia fa al caso mio, ma è lontana");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }

                }

                else if (selection.name == "Conchiglia" && selection.GetComponent<PickUpConchiglia>().canPickUp == false)
                {
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("Adoro le conchiglie, questa è quella che mi è venuta meglio");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }

                //---------------------PORTALE--------------------------
                if (selection.name == "Portale")
                {
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("Tempo di tornare nel mondo reale!");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }


                //-------------------------ALTRI OGGETTI DEL DIPINTO 1-----------------------------------

                //-------------------------ALTRI OGGETTI DEL DIPINTO 2-----------------------------------

                //-------------------------ALTRI OGGETTI DEL DIPINTO 3-----------------------------------
                if (selection.name == "Spaventapasseri")
                {
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("E' uno spaventapasseri");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }


                //-------------------------ALTRI OGGETTI DEL DIPINTO 4-----------------------------------

                if (selection.name == "Fosso" && MorbidDetector.morbidBelow == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");

                    dialogueManager.dialogue.sentences.Add("Se scendessi ora mi farei male");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                }
                else if (selection.name == "Fosso" && MorbidDetector.morbidBelow == true)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");

                    dialogueManager.dialogue.sentences.Add("La roba morbida attutirà la caduta, potrei anche scendere ora");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                }


                //-------------------------ALTRI OGGETTI DEL DIPINTO 5-----------------------------------
                if (selection.name == "Cappello")
                {
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("E' un cappello di paglia. Diventerò il re dei pirati");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }
                if (selection.name == "Tovaglia")
                {
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("Una volta facevo sempre dei pic nic con i miei genitori, adesso odio uscire di casa");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }
                if (selection.name == "Farfalla")
                {
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("HEY, LISTEN!");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }

                //-------------------------ALTRI OGGETTI DEL DIPINTO 6-----------------------------------

                if (selection.name == "Conchiglia gigante" && selection.GetComponent<PickUpConchiglia>().canPickUp == false)
                {
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("Uno dei miei primi quadri, mi stavo ancora esercitando con le proporzioni");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }
                else if (selection.name == "Conchiglia gigante" && selection.GetComponent<PickUpConchiglia>().canPickUp == true)
                {
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("Direi che questa non posso portarla al vecchio");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }


                if (selection.name == "Pallone")
                {
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("E' un pallone");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }
                if (selection.name == "Ombrellone")
                {
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("Non ho tempo per fermarmi a riposare, voglio uscire da questi quadri");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }
                if (selection.name == "Delfini")
                {
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("Se mi reincarnerò voglio essere un delfino, oppure un orso. Nessuno rompe le palle agli orsi.");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }
                if (selection.name == "Veliero")
                {
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("Quella nave sullo sfondo mi ha ispirato a fare un altro quadro. Da bambina sognavo di fare il pirata e navigare ovunque, poi qualcosa è cambiato.");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }


                //-------------------------ALTRI OGGETTI DEL DIPINTO 7-----------------------------------
                if (selection.name == "Pianeta")
                {
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("E' un pianeta");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }
                if (selection.name == "Sonda")
                {
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("E' una sonda lunare");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }
                if (selection.name == "Satellite")
                {
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("E' un satellite");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }
                if (selection.name == "Bandiera")
                {
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("E' la bandiera americana");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }
                if (selection.name == "Stella")
                {
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("E' una stella");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }

                //-------------------------ALTRI OGGETTI DEL DIPINTO 8-----------------------------------

                //-------------------------ALTRI OGGETTI DEL DIPINTO 9-----------------------------------

                //-------------------------ALTRI OGGETTI DEL DIPINTO 10-----------------------------------

                //-------------------------ALTRI OGGETTI DEL DIPINTO 11-----------------------------------

                //-------------------------ALTRI OGGETTI DEL DIPINTO 12-----------------------------------


            }
        }
    }
}
