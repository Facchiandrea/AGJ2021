using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ItemSelection : MonoBehaviour
{
    public ViewModeSwap viewModeSwap;
    private Transform _selectionItem;
    public Transform selection;
    public MorbidDetector MorbidDetector;
    public NPCInteractor NPCInteractor;
    public DialogueManager dialogueManager;
    public PickUpConchiglia pickUpConchiglia;
    public Scala scalaManager;
    public PickUpCasco pickUpCasco;
    public LockManager lockManager;
    public bool portaleAperto;

    public GameObject whiteScreen;
    public GameObject scrittaFinale;

    private void FixedUpdate()
    {
        if (_selectionItem != null)
        {
            selection.GetChild(0).gameObject.SetActive(false);
            _selectionItem = null;
            selection = null;
        }

        if (viewModeSwap.fullView == false && viewModeSwap.transitionToSingle == false)// && NPCInteractor.dragging == false)
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

    private void EndSequence()
    {
        whiteScreen.SetActive(true);
        scrittaFinale.SetActive(true);
        StartCoroutine(ToMenuCoroutine());
    }


    public IEnumerator ToMenuCoroutine()
    {
        lockManager.lockPuzzleActive = true;
        yield return new WaitForSeconds(15f);
        lockManager.lockPuzzleActive = false;
        SceneManager.LoadScene(0);
        yield return null;
    }
    private void Update()
    {
        if (lockManager.lockPuzzleActive == false)
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

                            dialogueManager.dialogue.sentences.Add("Sorry, Neil, I hope you don't mind if I borrow it for a little while.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                            if (AudioManager.instance != null)
                            {
                                AudioManager.instance.Play("Prendere_oggetto_sfx");
                            }

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

                            dialogueManager.dialogue.sentences.Add("That space helmet is perfect, it's definitely something special.\nI should get close to get it.");

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

                            dialogueManager.dialogue.sentences.Add("Neil must have left this space helmet here, he was always a little forgetful.");

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

                            dialogueManager.dialogue.sentences.Add("Oh yeah! This could be the perfect crown!");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                            if (AudioManager.instance != null)
                            {
                                AudioManager.instance.Play("Prendere_oggetto_sfx");
                            }

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

                            dialogueManager.dialogue.sentences.Add("I might need that colander, but I can't reach it from here.");

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

                            dialogueManager.dialogue.sentences.Add("A colander made of gold, whoever used it had a lot of money to spend.");

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

                            dialogueManager.dialogue.sentences.Add("Gotcha! It’s a bit big, but I don't think he will complain.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                            if (AudioManager.instance != null)
                            {
                                AudioManager.instance.Play("Prendere_oggetto_sfx");
                            }

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

                            dialogueManager.dialogue.sentences.Add("I might need that egg, but I have to be closer to get it.");
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

                            dialogueManager.dialogue.sentences.Add("But how big is this egg?!\nIt could be from a pterodactyl!");

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

                            dialogueManager.dialogue.sentences.Add("These flowers seem to have a wonderful scent, too bad I can't draw that too. They are also very soft!");

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

                            dialogueManager.dialogue.sentences.Add("To be part of a terrible monster, they look quite fluffy. Although definitely dirty.");

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

                            dialogueManager.dialogue.sentences.Add("I don't think there's anything else I can use in there");

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

                            dialogueManager.dialogue.sentences.Add("There were matches here when I checked. Bingo!");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                            if (AudioManager.instance != null)
                            {
                                AudioManager.instance.Play("Prendere_oggetto_sfx");
                            }

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

                            dialogueManager.dialogue.sentences.Add("It's not nice to rummage through other people's things, but in theory, it's all my property here. So let's see... there's a bottle of water, some sandwiches, and... matches! I could make good use of them.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                            if (AudioManager.instance != null)
                            {
                                AudioManager.instance.Play("Prendere_oggetto_sfx");
                            }

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

                            dialogueManager.dialogue.sentences.Add("There was something in the basket I might need, but I'm too far away");

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

                            dialogueManager.dialogue.sentences.Add("It's a picnic basket. If I get closer I could peek inside.");

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

                            dialogueManager.dialogue.sentences.Add("It's not nice to rummage through other people's things, but in theory, it's all my property here. So let's see... there's a bottle of water, some sandwiches, and some matches.");

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

                            dialogueManager.dialogue.sentences.Add("Yes, this is perfect. I hope that the old man will like it.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                            if (AudioManager.instance != null)
                            {
                                AudioManager.instance.Play("Prendere_oggetto_sfx");
                            }

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

                            dialogueManager.dialogue.sentences.Add("That shell seems to be fine, but I'm far away.");

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

                            dialogueManager.dialogue.sentences.Add("I love shells, this is the one I painted best.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }

                    //---------------------PORTALE--------------------------
                    if (selection.name == "Portale" && portaleAperto == false)
                    {
                        lockManager.PuzzleLockStart();
                    }
                    else if (selection.name == "Portale" && portaleAperto == true)
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("PLACEHOLDER");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                        EndSequence();
                    }

                    //---------------------SCALA--------------------------

                    if (selection.name == "Scala")
                    {
                        scalaManager.Spostamento();
                    }


                    //-------------------------ALTRI OGGETTI DEL DIPINTO 1-----------------------------------
                    if (selection.name == "Nuvola")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("The shape of this cloud reminds me of a slightly fat cat.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }
                    if (selection.name == "Casetta")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("I'd like to have a tiny house on the lake, maybe that one over there belongs to some fisherman.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }

                    //-------------------------ALTRI OGGETTI DEL DIPINTO 2-----------------------------------

                    if (selection.name == "LunaBus" && NPCInteractor.bigliettoUI.activeInHierarchy == true)
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("Now that I think about it, the moon does not shine with its own light. Maybe I should look in another painting.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }
                    else if (selection.name == "LunaBus" && NPCInteractor.bigliettoUI.activeInHierarchy == false)
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("Goodbye, goodbye, good friends, goodbye.\nCause now it's time to go…\nand then I don't remember.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }

                    if (selection.name == "StazioneBus")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("This bus stop is a bit spooky, but that's what I like about this painting.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }
                    if (selection.name == "Città")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("Metropolises are confusing and noisy. I wouldn't like to live there, but they offer a lot of opportunities.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }

                    if (selection.name == "CiuffoErba")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");
                            dialogueManager.dialogue.names.Add("Artemisia");
                            dialogueManager.dialogue.names.Add("Artemisia");
                            dialogueManager.dialogue.names.Add("Artemisia");
                            dialogueManager.dialogue.names.Add("Artemisia");
                            dialogueManager.dialogue.sentences.Add("I seem to see something there...");
                            dialogueManager.dialogue.sentences.Add("...");
                            dialogueManager.dialogue.sentences.Add("I can't believe it.\nI really found it.");
                            dialogueManager.dialogue.sentences.Add("It is definitely it.");
                            dialogueManager.dialogue.sentences.Add("Deez nuts!");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }




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

                            dialogueManager.dialogue.sentences.Add("I should have painted this scarecrow with a more menacing look.\nIt's not doing a good job.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }


                    //-------------------------ALTRI OGGETTI DEL DIPINTO 4-----------------------------------

                    if (selection.name == "Fosso" && MorbidDetector.morbidBelow == false)
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("I certainly can't jump because there's nothing to cushion the fall.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }
                    else if (selection.name == "Fosso" && MorbidDetector.morbidBelow == true)
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("Okay, now I should be able to come down from here without breaking my legs.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }

                    if (selection.name == "PortaFinta")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");
                            dialogueManager.dialogue.names.Add("Prince");
                            dialogueManager.dialogue.names.Add("Artemisia");
                            dialogueManager.dialogue.names.Add("Prince");
                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("Who knows if that door can lead me inside the castle...");
                            dialogueManager.dialogue.sentences.Add("IT'S USELESS, YOU CANNOT GET THERE EVEN IF YOU WANTED!");
                            dialogueManager.dialogue.sentences.Add("And what if I get there?");
                            dialogueManager.dialogue.sentences.Add("STILL USELESS BECAUSE THE DOOR IS FAKE!");
                            dialogueManager.dialogue.sentences.Add("...I've already wasted too much time with this nonsense, better concentrate on something else.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }
                    if (selection.name == "Castello")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("Simple but elegant, the way I like it. But if I lived there alone, I would get lost right away.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }
                    if (selection.name == "PonteDistrutto")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("I liked the idea of ​​painting the castle as separate from everything and everyone, but I think the owners aren't happy with it.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }

                    if (selection.name == "Gatto")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");
                            dialogueManager.dialogue.names.Add("Artemisia");
                            dialogueManager.dialogue.names.Add("Artemisia");
                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("Awwww, this cat is so cuteeee <3");
                            dialogueManager.dialogue.sentences.Add("No Artemisia, you have to learn to contain yourself, you can't act like an idiot every time you see a cat.");
                            dialogueManager.dialogue.sentences.Add("...");
                            dialogueManager.dialogue.sentences.Add("OMG,  WHAT CUTE, WHAT BEAUTIFUL, HELLO KITTY KITTEN PSS PSS COME HOME WITH ME.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }
                    if (selection.name == "Ornitottero")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("I painted this ornithopter after playing Assassin's Creed II.\nLeonardo da Vinci's inventions have always fascinated me. However, I would never try to fly on one of these!");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }



                    //-------------------------ALTRI OGGETTI DEL DIPINTO 5-----------------------------------
                    if (selection.name == "Cappello" && pickUpCasco.canPickUp == false)
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("A straw hat. I'm gonna be the pirate king!");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }
                    else if (selection.name == "Cappello" && pickUpCasco.canPickUp == true)
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("It's a hat, but it doesn't seem exotic enough for what I need.");

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

                            dialogueManager.dialogue.sentences.Add("I always used to have picnics with my parents, but now I hate leaving my house.");

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
                    if (selection.name == "Ombrello")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("It's an umbrella, luckily it doesn't rain in any of these paintings");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }

                    //-------------------------ALTRI OGGETTI DEL DIPINTO 6-----------------------------------

                    if (selection.name == "Conchiglia gigante" && pickUpConchiglia.canPickUp == false)
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("It's one of my first paintings, and I was still practicing with proportions...");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }
                    else if (selection.name == "Conchiglia gigante" && pickUpConchiglia.canPickUp == true)
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("I guess I can't take this to the old man...");

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

                            dialogueManager.dialogue.sentences.Add("I've never been good at ball sports. But when I played, I still enjoyed it. ");

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

                            dialogueManager.dialogue.sentences.Add("I don't have time to stop and relax, I want to get out of these paintings.");

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

                            dialogueManager.dialogue.sentences.Add("If I reincarnate, I want to be a dolphin. Or a bear. Nobody bothers the bears.");

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

                            dialogueManager.dialogue.sentences.Add("This ship inspired me to do another painting. As a child, I dreamed of being a pirate and sailing everywhere, then something changed.");

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

                            dialogueManager.dialogue.sentences.Add("I've always found Saturn's rings fascinating. They are made of billions of small chunks of ice and rock coated with other materials such as dust.");

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

                            dialogueManager.dialogue.sentences.Add("A spacecraft. With the big hips I have, I don't think I can fit in.");

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

                            dialogueManager.dialogue.sentences.Add("It is one of Elon Musk's satellites.\nWith this, I will have access to the internet from my small town of 10 inhabitants.");

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

                            dialogueManager.dialogue.sentences.Add("Many people still believe the moon landing was fake. Lol.");

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

                            dialogueManager.dialogue.sentences.Add("This is Polaris IV.\nOn this star, I will exile all those people who don't like my paintings.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }

                    //-------------------------ALTRI OGGETTI DEL DIPINTO 8-----------------------------------
                    if (selection.name == "Squali")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("It's more likely to get killed by a falling coconut than by a shark, but I guess I'll stay away from them anyway, just in case.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }
                    if (selection.name == "Corallo")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("I'd like to see the coral reef, but I'm afraid to travel. So I think I'll be satisfied with seeing it in documentaries.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }
                    if (selection.name == "Relitto")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("Under the sea, under the sea!\nDarling it’s better, down where it’s wetter, take it from me!");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }

                    if (selection.name == "Alga")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("That's how fishes get high.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }


                    //-------------------------ALTRI OGGETTI DEL DIPINTO 9-----------------------------------
                    if (selection.name == "Fontana")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("Throwing a coin into the fountain brings good luck, but I'm poor.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }
                    if (selection.name == "CassettaPosta")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("Are these things still used?");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }
                    if (selection.name == "Tombino")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("I hope there isn't a clown in there... or the ninja turtles.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }

                    //-------------------------ALTRI OGGETTI DEL DIPINTO 10-----------------------------------
                    if (selection.name == "Pappagallo")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("I'd like to have a parrot, but it would probably learn to swear. A lot.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }
                    if (selection.name == "Tempio")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("I painted this picture after reading a book about the Maya city of Uxmal, which was founded in the 6th century.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }
                    if (selection.name == "Insetto")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("Oh no, another bug!");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }

                    //-------------------------ALTRI OGGETTI DEL DIPINTO 11-----------------------------------
                    if (selection.name == "Marmitta")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("VROOM VROOM MOTHERFUCKER!");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }
                    if (selection.name == "Carrello")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("It's the shopping cart with a broken wheel that I always get at the supermarket. Fuck it.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }
                    if (selection.name == "Lavatrice")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("It's my old washing machine, damn it! It always stopped working when I needed it most!");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }
                    if (selection.name == "Immondizia")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("A huge pile of trash. If I look closely, I'm sure I'll find my old right sock, which I lost a long time ago.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }
                    if (selection.name == "Bestio")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("I wanted to represent a living version of pollution, but looking back, I don't think it's such an original idea. Someone even made a pokémon about it.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }



                    //-------------------------ALTRI OGGETTI DEL DIPINTO 12-----------------------------------
                    if (selection.name == "Cervo")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("Powerful, but shy. An animal that is better not to piss off... but I would like to caress you too much!");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }
                    if (selection.name == "Bacche")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("They could be delicious raspberries or poisonous berries. When in doubt, I don't think I'll eat them.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }

                    if (selection.name == "Funghi")
                    {
                        if (dialogueManager.inDialogue == false)
                        {

                            dialogueManager.dialogue.sentences.Clear();
                            dialogueManager.sentences.Clear();
                            dialogueManager.dialogue.names.Clear();
                            dialogueManager.names.Clear();

                            dialogueManager.dialogue.names.Add("Artemisia");

                            dialogueManager.dialogue.sentences.Add("I drew some paintings after eating similar mushrooms.");

                            dialogueManager.StartDialogue(dialogueManager.dialogue);
                        }
                    }



                }
            }
        }
    }
}
