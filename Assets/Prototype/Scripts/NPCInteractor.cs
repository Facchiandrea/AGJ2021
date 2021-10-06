using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractor : MonoBehaviour
{
    public FadeInOut fadeInOut;
    public ViewModeSwap viewModeSwap;
    private Transform _selectionItem;
    public Transform selection;

    public bool tutorialFinito;


    public PickUpCasco pickUpCascoScript;
    public bool cascoPortato = false;


    public PickUpScolapasta pickUpScolapastaScript;
    public PickUpUovo pickUpUovoScript;
    public bool scolapastaPortato = false;
    public bool uovoPortato = false;

    public GameObject player;
    public Transform posizioneStazione1;
    public Transform posizioneStazione2;
    public bool stazione1 = true;

    public PickUpFiammiferi pickUpFiammiferi;
    public bool fiammiferiInInventario = false;

    public Mongolfiera mongolfieraScript;

    public Armadio armadioScript;
    public bool armadioAperto;
    public bool gambaPresa;
    public PickUpGamba pickUpGamba;
    public GameObject gambaLeva;

    public Uomo uomo;
    public Montacarichi montacarichi;
    public bool conchigliaPortata;
    public PickUpConchiglia pickUpConchiglia;


    public GameObject forcinaUI;
    public GameObject cascoUI;
    public GameObject bigliettoUI;
    public GameObject scolapastaUI;
    public GameObject uovoUI;
    public GameObject gambaUI;
    public GameObject conchigliaUI;


    public DialogueManager dialogueManager;

    private int tutorialCounter = 0;
    private int bambinoCounter1 = 0;
    private int bambinoCounter2 = 0;
    private int ragazzoCounter = 0;
    private int uomoCounter = 0;

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
            int layerMask = LayerMask.GetMask("NPCs");
            Vector2 cubeRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D cubeHit = Physics2D.Raycast(cubeRay, Vector2.zero, 1000f, layerMask);

            if (cubeHit && cubeHit.transform.CompareTag("NPC"))
            {
                selection = cubeHit.transform;
                selection.GetChild(0).gameObject.SetActive(true);
                _selectionItem = selection;
            }

        }
    }

    private void Update()
    {
        if (selection != null && fadeInOut.fadeTransition == false)
        {
            //-----------------TUTORIAL----------------
            if (Input.GetMouseButtonDown(0) && selection.name == "Tutorial" && tutorialFinito == false)
            {
                tutorialFinito = true;

                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("???");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Tut Orial");
                    dialogueManager.dialogue.names.Add("Tut Orial");
                    dialogueManager.dialogue.names.Add("Tut Orial");

                    dialogueManager.dialogue.sentences.Add("Ciao, il mio nome è Tut, ma puoi chiamarmi Orial");
                    dialogueManager.dialogue.sentences.Add("...Seriamente?");
                    dialogueManager.dialogue.sentences.Add("Premi V per allargare la visuale e clicca su un quadro per selezionarlo.");
                    dialogueManager.dialogue.sentences.Add("Seleziona 2 quadri per scambiarli di posto. Non puoi andare in quadri non collegati tra loro.");
                    dialogueManager.dialogue.sentences.Add("ma non puoi scambiare i quadri se c'è un personaggio all'interno, rischierebbe di cadere fuori!");


                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }

            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Tutorial" && tutorialFinito == true && tutorialCounter == 0)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Tut Orial");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Tut Orial");

                    dialogueManager.dialogue.sentences.Add("Sei ancora qua?");
                    dialogueManager.dialogue.sentences.Add("Si");
                    dialogueManager.dialogue.sentences.Add("Ciao");


                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                    tutorialCounter = 1;
                }
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Tutorial" && tutorialFinito == true && tutorialCounter == 1)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Tut Orial");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Tut Orial");
                    dialogueManager.dialogue.names.Add("Artemisia");

                    dialogueManager.dialogue.sentences.Add("Prova secondo dialogo");
                    dialogueManager.dialogue.sentences.Add("Prova prova");
                    dialogueManager.dialogue.sentences.Add("Grazie Artemisia");
                    dialogueManager.dialogue.sentences.Add("Di nulla");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                    tutorialCounter = 0;
                }

            }

            //-----------------RAGAZZO----------------

            if (Input.GetMouseButtonDown(0) && selection.name == "RagazzoCheVuoleIlCasco" && cascoUI.activeInHierarchy == true)
            {
                cascoUI.SetActive(false);
                cascoPortato = true;
                selection.GetChild(1).gameObject.SetActive(true);
                forcinaUI.SetActive(true);
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Ragazzo");
                    dialogueManager.dialogue.names.Add("Ragazzo");

                    dialogueManager.dialogue.sentences.Add("Sì sì! questo è perfetto! Da sballo! mi dona vero ? Esalta i miei fantastici zigomi!Grazie!");
                    dialogueManager.dialogue.sentences.Add("Ora puoi tenerti la forcina, tutto sommato non era così figa.");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    if (AudioManager.instance != null)
                    {
                        AudioManager.instance.Play("Prendere_oggetto_sfx");
                    }

                }
            }

            else if (Input.GetMouseButtonDown(0) && selection.name == "RagazzoCheVuoleIlCasco" && cascoPortato == false && ragazzoCounter == 0)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Ragazzo");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Ragazzo");
                    dialogueManager.dialogue.names.Add("Ragazzo");
                    dialogueManager.dialogue.names.Add("Ragazzo");

                    dialogueManager.dialogue.sentences.Add("Finalmente sei arrivata! Mmmmm ti ricordavo più magra...\nHey, ma tu non sei la mia ragazza!");
                    dialogueManager.dialogue.sentences.Add("Mi sa di no");
                    dialogueManager.dialogue.sentences.Add("Bhe meno male, perchè per la mia VERA ragazza non ho ancora trovato un regalo di compleanno.");
                    dialogueManager.dialogue.sentences.Add("Pensavo di regalarle questa forcina 2000 TURBO placcata d’oro e sistema di ventilazione per quando fa caldo.");
                    dialogueManager.dialogue.sentences.Add("Ma non sono sicuro le possa piacere. Aiutami a trovare un cappello! Uno figo!");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    ragazzoCounter = 1;
                }
                pickUpCascoScript.canPickUp = true;
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "RagazzoCheVuoleIlCasco" && cascoPortato == false && ragazzoCounter == 1)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Ragazzo");
                    dialogueManager.dialogue.names.Add("Artemisia");

                    dialogueManager.dialogue.sentences.Add("Un cappello! Sì, un cappello figo. Magari qualcosa di esotico o stravagante o…");
                    dialogueManager.dialogue.sentences.Add("Ho capito ho capito, un cappello per la tua inesistente ragazza");


                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                    ragazzoCounter = 2;
                }
            }

            else if (Input.GetMouseButtonDown(0) && selection.name == "RagazzoCheVuoleIlCasco" && cascoPortato == false && ragazzoCounter == 2)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Ragazzo");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Ragazzo");

                    dialogueManager.dialogue.sentences.Add("Ah, non vedo l’ora di vedere la mia ragazza. Ha dei colori stupendi e delle pennellate bellissime");
                    dialogueManager.dialogue.sentences.Add("Io non mi ricordo di questa ragazza");
                    dialogueManager.dialogue.sentences.Add("Beh tu non la conosci");


                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                    ragazzoCounter = 3;
                }
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "RagazzoCheVuoleIlCasco" && cascoPortato == false && ragazzoCounter == 3)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Ragazzo");
                    dialogueManager.dialogue.names.Add("Artemisia");

                    dialogueManager.dialogue.sentences.Add("Questa forcina è una vera figata");
                    dialogueManager.dialogue.sentences.Add("Ma quand’è che te l'ho disegnata?!");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                    ragazzoCounter = 1;
                }
            }

            else if (Input.GetMouseButtonDown(0) && selection.name == "RagazzoCheVuoleIlCasco" && cascoPortato == true)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Ragazzo");

                    dialogueManager.dialogue.sentences.Add("Guardatemi sono un astronauta! Non è che si veda proprio bene da questo casco… C'È NESSUNO???");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
            }
            //-----------------BAMBINO----------------
            if (Input.GetMouseButtonDown(0) && selection.name == "Bambino" && scolapastaPortato == false && bambinoCounter1 == 0)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Bambino");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Bambino");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Bambino");
                    dialogueManager.dialogue.names.Add("Bambino");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Bambino");
                    dialogueManager.dialogue.names.Add("Artemisia");

                    dialogueManager.dialogue.sentences.Add("HEEEY SIGNOOOORAAAAAA!!!");
                    dialogueManager.dialogue.sentences.Add("ehm...ciao.");
                    dialogueManager.dialogue.sentences.Add("Tu sei quella che mi ha disegnato?");
                    dialogueManager.dialogue.sentences.Add("Temo di sì");
                    dialogueManager.dialogue.sentences.Add("Ecco..volevo chiederti... PERCHé NON SONO IL RE?! VOGLIO ESSERE RE! Mi serve una corona adatta alla mia altezza!");
                    dialogueManager.dialogue.sentences.Add("Se mi aiuterai… ti darò bel un regalo");
                    dialogueManager.dialogue.sentences.Add("Perchè dovrei aiutarti? Già mi sono pentita di averti creato.");
                    dialogueManager.dialogue.sentences.Add("PER FAVOOORE?");
                    dialogueManager.dialogue.sentences.Add("Uff... va bene");


                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    bambinoCounter1 = 1;
                }
                pickUpScolapastaScript.canPickUp = true;
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Bambino" && scolapastaPortato == false && bambinoCounter1 == 1)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Bambino");
                    dialogueManager.dialogue.names.Add("Artemisia");

                    dialogueManager.dialogue.sentences.Add("PERCHé MI HAI DISEGNATO PRINCIPE? IO VOGLIO ESSERE IL RE!");
                    dialogueManager.dialogue.sentences.Add("Certo certo, ma quando esco ti cancello");


                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    bambinoCounter1 = 2;
                }
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Bambino" && scolapastaPortato == false && bambinoCounter1 == 2)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Bambino");
                    dialogueManager.dialogue.names.Add("Artemisia");

                    dialogueManager.dialogue.sentences.Add("La prossima volta puoi disegnarmi in un Luna Park?");
                    dialogueManager.dialogue.sentences.Add("La prossima volta ti muro la finestra.");


                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    bambinoCounter1 = 3;
                }
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Bambino" && scolapastaPortato == false && bambinoCounter1 == 3)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Bambino");
                    dialogueManager.dialogue.names.Add("Artemisia");

                    dialogueManager.dialogue.sentences.Add("Quando sarò re ti rivolgerai a me come “sua altezza”!");
                    dialogueManager.dialogue.sentences.Add("Davvero? Ma se sei alto come uno sgabello");


                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    bambinoCounter1 = 1;
                }
            }

            else if (Input.GetMouseButtonDown(0) && selection.name == "Bambino" && scolapastaPortato == true && uovoPortato == false && bambinoCounter2 == 0)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Bambino");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Bambino");

                    dialogueManager.dialogue.sentences.Add("Ora voglio un'aquila gigante o qualcosa che vola con gli artigli");
                    dialogueManager.dialogue.sentences.Add("Ok");
                    dialogueManager.dialogue.sentences.Add("VOGLIO UNO PTERODATTILO");


                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    bambinoCounter2 = 1;

                }
                pickUpUovoScript.canPickUp = true;

            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Bambino" && scolapastaPortato == true && uovoPortato == false && bambinoCounter2 == 1)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Bambino");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Bambino");

                    dialogueManager.dialogue.sentences.Add("Deve avere delle grandi ali! E degli artigli affilatissimi! è magari che sia giovane così che possa crescere insieme a me!");
                    dialogueManager.dialogue.sentences.Add("Ma tu non puoi crescere.");
                    dialogueManager.dialogue.sentences.Add("Se divento vecchio e noioso come te non lo voglio di sicuro!");


                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    bambinoCounter2 = 2;
                }
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Bambino" && scolapastaPortato == true && uovoPortato == false && bambinoCounter2 == 2)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Bambino");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Bambino");

                    dialogueManager.dialogue.sentences.Add("Com’è l’interno del castello?");
                    dialogueManager.dialogue.sentences.Add("Ci sono 207 cucine, 453 stanze da letto, 115 bagni e 348 sale da pranzo");
                    dialogueManager.dialogue.sentences.Add("Come hai fatto a contarle tutte?");
                    dialogueManager.dialogue.sentences.Add("Ho molto tempo libero.");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    bambinoCounter2 = 3;
                }
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Bambino" && scolapastaPortato == true && uovoPortato == false && bambinoCounter2 == 3)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Bambino");
                    dialogueManager.dialogue.names.Add("Artemisia");

                    dialogueManager.dialogue.sentences.Add("Non ti senti mai solo?");
                    dialogueManager.dialogue.sentences.Add("E’ anche per questo che voglio un animale domestico! Tu non ti senti mai sola?");
                    dialogueManager.dialogue.sentences.Add("A volte, ma ho paura ad uscire e disegnare mi aiuta a non pensarci");


                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    bambinoCounter2 = 1;
                }
            }

            else if (Input.GetMouseButtonDown(0) && selection.name == "Bambino" && uovoPortato == true && uovoPortato == true)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Bambino");
                    dialogueManager.dialogue.sentences.Add("GRAZIE PER TUTTO ORA SONO FELICIO");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
            }
            //-----------------AUTOBUS----------------

            if (Input.GetMouseButtonDown(0) && selection.name == "Autobus" && bigliettoUI.activeInHierarchy == true)
            {
                ViaggioInAutobus();
                if (AudioManager.instance != null)
                {
                    AudioManager.instance.Play("Prendere_autobus_sfx");
                }

            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Autobus" && bigliettoUI.activeInHierarchy == false)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.sentences.Add("Non ho il biglietto per usarlo");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
            }
            //-----------------Mongolfiera----------------
            if (Input.GetMouseButtonDown(0) && selection.name == "Mongolfiera" && fiammiferiInInventario == false && mongolfieraScript.traveling == false)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");

                    dialogueManager.dialogue.sentences.Add("Mi serve qualcosa per attivare il bruciatore");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                }

                pickUpFiammiferi.canPickUp = true;
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Mongolfiera" && fiammiferiInInventario == true && mongolfieraScript.playerInRange == false && mongolfieraScript.traveling == false)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");

                    dialogueManager.dialogue.sentences.Add("Devo avvicinarmi per poter salire!");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                }
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Mongolfiera" && fiammiferiInInventario == true && mongolfieraScript.playerInRange == true && mongolfieraScript.traveling == false)
            {
                mongolfieraScript.ViaggioInMongolfiera();
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");

                    dialogueManager.dialogue.sentences.Add("Si parte!");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    if (AudioManager.instance != null)
                    {
                        AudioManager.instance.Play("Fuoco_mongolfiera_sfx");
                    }

                }

            }

            //-----------------Armadio----------------

            if (Input.GetMouseButtonDown(0) && selection.name == "Armadio" && armadioAperto == false)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.sentences.Add("E' un armadio con un lucchetto");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Armadio" && armadioAperto == true && armadioScript.playerInRange == true && gambaPresa == false && pickUpGamba.canPickUp == true)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.sentences.Add("Questa gamba di legno fa al caso mio");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
                pickUpGamba.PickUpUIGraphics.SetActive(true);
                pickUpGamba.PickUpGraphics.SetActive(false);
                gambaPresa = true;

            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Armadio" && gambaPresa == true || Input.GetMouseButtonDown(0) && selection.name == "Armadio" && armadioAperto == true && gambaPresa == false && pickUpGamba.canPickUp == false)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.sentences.Add("E' una bella collezione di gambe di legno");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
            }
            //------------------MONTACARICHI-------------
            if (Input.GetMouseButtonDown(0) && selection.name == "Montacarichi" && montacarichi.montacarichiRiparato == false)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.sentences.Add("La leva è rotta, devo sostituirla con qualcosa");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
                pickUpGamba.canPickUp = true;
            }

            else if (Input.GetMouseButtonDown(0) && selection.name == "Montacarichi" && montacarichi.playerInRange == true && montacarichi.montacarichiRiparato == true && montacarichi.traveling == false)
            {
                montacarichi.SpostamentoInMontacarichi();
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Montacarichi" && montacarichi.playerInRange == false && montacarichi.montacarichiRiparato == true)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.sentences.Add("Devo salire sul montacarichi, prima");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
            }

            //------------------UOMO-------------------------

            if (Input.GetMouseButtonDown(0) && selection.name == "Uomo" && conchigliaPortata == false && uomo.playerInRange == true && uomoCounter == 0)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Uomo");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Uomo");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Uomo");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Uomo");
                    dialogueManager.dialogue.names.Add("Uomo");
                    dialogueManager.dialogue.names.Add("Uomo");

                    dialogueManager.dialogue.sentences.Add("Oh oh… buongiorno principessa");
                    dialogueManager.dialogue.sentences.Add("No guarda, se cerchi qualcuno con sangue reale  si trova 2 quadri più sopra, io sono solo una pittrice.");
                    dialogueManager.dialogue.sentences.Add("Una pittrice? Ah ma che bel lavoro, li sapresti disegnare dei quadri così belli?");
                    dialogueManager.dialogue.sentences.Add("Beh questi quadri li ho fatti io");
                    dialogueManager.dialogue.sentences.Add("OH OH… davvero? Ma allora sarai andata in giro per il mondo!");
                    dialogueManager.dialogue.sentences.Add("Beh no, ho preso ispirazione da Pinterest");
                    dialogueManager.dialogue.sentences.Add("What?! Ma dovresti uscire di casa, dovresti vederlo il mondo.");
                    dialogueManager.dialogue.sentences.Add("Io ormai sono vecchio, stanco e beh... non posso fisicamente uscire da questo quadro.");
                    dialogueManager.dialogue.sentences.Add("Ma tu, tu hai questa possibilità. Fai un favore questo vecchio, vorrei vedere il mare. Portami qualcosa che mi ricorderà del mare");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                    uomoCounter = 1;
                }
                pickUpConchiglia.canPickUp = true;
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Uomo" && conchigliaPortata == false && uomo.playerInRange == true && uomoCounter == 1)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Uomo");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Uomo");

                    dialogueManager.dialogue.sentences.Add("Oh, signorina ci conosciamo?");
                    dialogueManager.dialogue.sentences.Add("Ma ci siamo parlati solo poco fa");
                    dialogueManager.dialogue.sentences.Add("Oh si certo certo, che sbadato. Allora hai trovato qualcosa che mi ricorderà del mare?");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                    uomoCounter = 2;
                }
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Uomo" && conchigliaPortata == false && uomo.playerInRange == true && uomoCounter == 2)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Uomo");
                    dialogueManager.dialogue.names.Add("Artemisia");

                    dialogueManager.dialogue.sentences.Add("Sai vecchietto, mi ricordi mio nonno");
                    dialogueManager.dialogue.sentences.Add("Oh, tuo nonno doveva essere un uomo affascinante e facoltoso e virile, ma anche umile e onesto e…");
                    dialogueManager.dialogue.sentences.Add("Si. Mi ricordi decisamente mio nonno.");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                    uomoCounter = 3;
                }
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Uomo" && conchigliaPortata == false && uomo.playerInRange == true && uomoCounter == 3)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Uomo");

                    dialogueManager.dialogue.sentences.Add("Amo questa foresta, la foschia le da un senso mistico, però vorrei abbronzarmi almeno una volta nella vita");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                    uomoCounter = 1;
                }
            }

            else if (Input.GetMouseButtonDown(0) && selection.name == "Uomo" && conchigliaPortata == false && uomo.playerInRange == false)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.sentences.Add("Ehiiiiiii\n...Credo che quel tipo sia sordo, dovrei prima avvicinarmi");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
            }

            else if (Input.GetMouseButtonDown(0) && selection.name == "Uomo" && conchigliaPortata == true)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.sentences.Add("Tempo di svegliarsi! Addio vecchio!");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
            }

            //------------------PECORE-------------------------
            if (Input.GetMouseButtonDown(0) && selection.name == "Pecora 3")
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Rebeeecca");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Rebeeecca");

                    dialogueManager.dialogue.sentences.Add("Dio non esiste e noi siamo solo degli inutili involucri pluricellulari");
                    dialogueManager.dialogue.sentences.Add("...what?!");
                    dialogueManager.dialogue.sentences.Add("ehm...Beeeee!");


                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                    if (AudioManager.instance != null)
                    {
                        AudioManager.instance.Play("Beeee_strano_sfx");
                    }
                }
            }
            if (Input.GetMouseButtonDown(0) && selection.name == "Pecora 1")
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Beeeatrice");

                    dialogueManager.dialogue.sentences.Add("Baaaaaa");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    if (AudioManager.instance != null)
                    {
                        AudioManager.instance.Play("Beeee_sfx");
                    }

                }
            }
            if (Input.GetMouseButtonDown(0) && selection.name == "Pecora 2")
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Baaarbara");

                    dialogueManager.dialogue.sentences.Add("Beeee");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    if (AudioManager.instance != null)
                    {
                        AudioManager.instance.Play("Beeee_sfx");
                    }

                }

            }

            if (Input.GetMouseButtonDown(0) && selection.name == "Pecora 4")
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Beeeth");

                    dialogueManager.dialogue.sentences.Add("Baaaaaa");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    if (AudioManager.instance != null)
                    {
                        AudioManager.instance.Play("Beeee_sfx");
                    }

                }
            }



        }
    }

    public void ViaggioInAutobus()
    {
        if (stazione1 == true)
        {
            bigliettoUI.SetActive(false);
            Invoke("PlayerTP", 1f);
            fadeInOut.FadeIn();
            Debug.Log("VadoAStazione2");

        }
        else if (stazione1 == false)
        {
            bigliettoUI.SetActive(false);
            Invoke("PlayerTP", 1f);
            fadeInOut.FadeIn();
            Debug.Log("VadoAStazione1");
        }

    }

    public void PlayerTP()
    {
        if (stazione1 == true)
        {
            stazione1 = false;
            player.transform.position = posizioneStazione2.position;
        }
        else if (stazione1 == false)
        {
            stazione1 = true;
            player.transform.position = posizioneStazione1.position;
        }

    }
}
