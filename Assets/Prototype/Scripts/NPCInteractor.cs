using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NPCInteractor : MonoBehaviour
{
    public FadeInOut fadeInOut;
    public ViewModeSwap viewModeSwap;
    private Transform _selectionItem;
    public Transform selection;

    public bool tutorialFinito;


    public PickUpCasco pickUpCascoScript;
    public bool cascoPortato = false;

    public GameObject cascoTesta;
    public PickUpScolapasta pickUpScolapastaScript;
    public PickUpUovo pickUpUovoScript;
    public bool scolapastaPortato = false;
    public bool uovoPortato = false;


    public GameObject player;
    public Transform posizioneStazione1;
    public Transform posizioneStazione2;
    public bool stazione1 = true;
    public bool autobusInRange;

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
    public GameObject filastroccaUI;
    public LockManager lockManager;
    public DialogueManager dialogueManager;

    public bool compariPortale = false;
    //public bool dragging;
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
        if (lockManager.lockPuzzleActive == false)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
            }

            else if (selection != null && fadeInOut.fadeTransition == false)
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
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("Tut Orial");
                        dialogueManager.dialogue.names.Add("Tut Orial");
                        dialogueManager.dialogue.names.Add("Tut Orial");
                        dialogueManager.dialogue.names.Add("Tut Orial");
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("Tut Orial");
                        dialogueManager.dialogue.names.Add("Tut Orial");
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("Tut Orial");
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("Tut Orial");


                        dialogueManager.dialogue.sentences.Add("Hey, nice to meet you. Not many people pass here! I am Tut, but you can call me Orial, and I like to explain things to people.");
                        dialogueManager.dialogue.sentences.Add("You are a strange guy.");
                        dialogueManager.dialogue.sentences.Add("Listen, do you want to get out of this place? Then let me do my job.");
                        dialogueManager.dialogue.sentences.Add("As you can see, we are inside a painting, but you do not belong to this place. You are the one who painted us all.");
                        dialogueManager.dialogue.sentences.Add("I have no idea how you can escape, but maybe someone else can help you. I know that a little boy lives in the painting with the castle, you could visit him.");
                        dialogueManager.dialogue.sentences.Add("I remember. He is one of the characters I painted. But how do I get there?");
                        dialogueManager.dialogue.sentences.Add("To move from one painting to another, you will have to make sure that the road in the painting you are in, and the road in the painting you want to go to, are aligned.");
                        dialogueManager.dialogue.sentences.Add("If they have different heights, you will not be able to pass!");
                        dialogueManager.dialogue.sentences.Add("Press SPACE to change the view, then click a painting to select it. By selecting a painting first and then a second one, you will swap them places!");
                        dialogueManager.dialogue.sentences.Add("BEWARE, however, the paintings in the corners where there are people and the painting in which you are currently, CANNOT be moved.");
                        dialogueManager.dialogue.sentences.Add("Ok, clear. If I forget, I'll ask again. Is there anything else I need to know?");
                        dialogueManager.dialogue.sentences.Add("You have an inventory that you can open by clicking on the icon at the top center of the screen. There you can see what you have collected.");
                        dialogueManager.dialogue.sentences.Add("But know that you can't pick up an item until you know you need it. When you realize you need an item you already found while exploring, come back for it!");
                        dialogueManager.dialogue.sentences.Add("Actually, these pants don't have pockets. I don't want to carry useless stuff with me.");
                        dialogueManager.dialogue.sentences.Add("And if by chance I get lost, and I don't know where to go?");
                        dialogueManager.dialogue.sentences.Add("If you really don't know what to do, you can download the .txt file with the solution from the Itch.Io page.");
                        dialogueManager.dialogue.sentences.Add("I understand. I hope I won't need it.");
                        dialogueManager.dialogue.sentences.Add("We all hope so.");


                        dialogueManager.StartDialogue(dialogueManager.dialogue);

                    }

                }
                else if (Input.GetMouseButtonDown(0) && selection.name == "Tutorial" && tutorialFinito == true)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("Tut Orial");
                        dialogueManager.dialogue.names.Add("Tut Orial");
                        dialogueManager.dialogue.names.Add("Tut Orial");
                        dialogueManager.dialogue.names.Add("Tut Orial");
                        dialogueManager.dialogue.names.Add("Tut Orial");
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("Tut Orial");
                        dialogueManager.dialogue.names.Add("Tut Orial");
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("Tut Orial");
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("Tut Orial");

                        dialogueManager.dialogue.sentences.Add("Uh, could you explain again?");
                        dialogueManager.dialogue.sentences.Add("Sure, that's what I'm here for!");
                        dialogueManager.dialogue.sentences.Add("To move from one painting to another, you will have to make sure that the road in the painting you are in, and the road in the painting you want to go to, are aligned.");
                        dialogueManager.dialogue.sentences.Add("If they have different heights, you will not be able to pass!");
                        dialogueManager.dialogue.sentences.Add("Press SPACE to change the view, then click a painting to select it. By selecting a painting first and then a second one, you will swap them places!");
                        dialogueManager.dialogue.sentences.Add("BEWARE, however, the paintings in the corners where there are people and the painting in which you are currently, CANNOT be moved.");
                        dialogueManager.dialogue.sentences.Add("Is there anything else?");
                        dialogueManager.dialogue.sentences.Add("You have an inventory that you can open by clicking on the icon at the top center of the screen. There you can see what you have collected.");
                        dialogueManager.dialogue.sentences.Add("But know that you can't pick up an item until you know you need it. When you realize you need an item you already found while exploring, come back for it!");
                        dialogueManager.dialogue.sentences.Add("Right, I don't have pockets, and I don't want to carry useless stuff with me.");
                        dialogueManager.dialogue.sentences.Add("And where is the txt file with the solution?");
                        dialogueManager.dialogue.sentences.Add("You can download it from the Itch.Io page!");
                        dialogueManager.dialogue.sentences.Add("I understand. If I need the explanation again, I'll be back!");
                        dialogueManager.dialogue.sentences.Add("Let's hope not!");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);

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

                        dialogueManager.dialogue.names.Add("Cool dude");
                        dialogueManager.dialogue.names.Add("Cool dude");

                        dialogueManager.dialogue.sentences.Add("Yes, yes! This is perfect! Rocking! Suits me, right ? It enhances my awesome cheekbones. Thanks!");
                        dialogueManager.dialogue.sentences.Add("Now you can keep the hairpin. All in all, it wasn't that cool...");

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

                        dialogueManager.dialogue.names.Add("Dude");
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("Dude");
                        dialogueManager.dialogue.names.Add("Dude");

                        dialogueManager.dialogue.sentences.Add("You finally arrived!\nMmm, I reminded you thinner...but, wait, you are not my girlfriend!");
                        dialogueManager.dialogue.sentences.Add("I guess not.");
                        dialogueManager.dialogue.sentences.Add("Well, thank goodness, because I haven't found a birthday present for my REAL girlfriend yet.I was thinking of giving her this gold - plated hairpin, a Turbo model one with a ventilation system for when it's hot.");
                        dialogueManager.dialogue.sentences.Add("But I'm not sure she'll like it. So help me find a hat! An exotic and extravagant one!");

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

                        dialogueManager.dialogue.names.Add("Dude");
                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("A hat! Yes, a cool hat. Maybe something special...");
                        dialogueManager.dialogue.sentences.Add("I understand, I understand, a hat for your non-existent girlfriend.");


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

                        dialogueManager.dialogue.names.Add("Dude");
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("Dude");

                        dialogueManager.dialogue.sentences.Add("Ah, I can't wait to see my girlfriend. She has beautiful colors and awesome brushstrokes");
                        dialogueManager.dialogue.sentences.Add("I don't remember this girl.");
                        dialogueManager.dialogue.sentences.Add("Well, you don't know her!");


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

                        dialogueManager.dialogue.names.Add("Dude");
                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("This hairpin is really cool.");
                        dialogueManager.dialogue.sentences.Add("But when did I draw it?!");

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

                        dialogueManager.dialogue.names.Add("Cool dude");

                        dialogueManager.dialogue.sentences.Add("Look at me! I'm an astronaut! I can't see very well with this space helmet... ANYBODY HERE??");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);

                    }
                }
                //-----------------BAMBINO----------------

                if (Input.GetMouseButtonDown(0) && selection.name == "Prince" && scolapastaUI.activeInHierarchy)
                {
                    scolapastaUI.SetActive(false);
                    scolapastaPortato = true;
                    cascoTesta.SetActive(true);
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Prince");
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("Prince");
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("Prince");
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("King");
                        dialogueManager.dialogue.names.Add("King");
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("King");
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("King");
                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("A colander?");
                        dialogueManager.dialogue.sentences.Add("Yes, it is perfect as a crown.");
                        dialogueManager.dialogue.sentences.Add("I hate it.");
                        dialogueManager.dialogue.sentences.Add("Don't throw a tantrum. In the 1500s, there was a very powerful king who wore exactly this crown.");
                        dialogueManager.dialogue.sentences.Add("Okay, but did he have sunglasses and a mustache?");
                        dialogueManager.dialogue.sentences.Add("...yes.");
                        dialogueManager.dialogue.sentences.Add("Oh. He had to be really cool! Ok, I accept the crown and to celebrate I will make a giant cake! I have sugar, milk, flour, butter, and lots of CHOCOLATE!");
                        dialogueManager.dialogue.sentences.Add("Mmm, I don't know, it just seems like something is missing.");
                        dialogueManager.dialogue.sentences.Add("A person to share this cake with? Like me ;-)");
                        dialogueManager.dialogue.sentences.Add("Nonsense! I'm sure an ingredient is missing, but I don't remember what. Would you help me to find it? AND THEN BRING IT TO ME!");
                        dialogueManager.dialogue.sentences.Add("You already owe me. Why should I?");
                        dialogueManager.dialogue.sentences.Add("Beeecause otherwise I'll start crying aaaand you would hear me in all the paintings!");
                        dialogueManager.dialogue.sentences.Add("Oh god no! Ok you convinced me, stay there.");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }

                }
                else if (Input.GetMouseButtonDown(0) && selection.name == "Prince" && uovoUI.activeInHierarchy)
                {
                    uovoUI.SetActive(false);
                    uovoPortato = true;
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("King");
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("King");

                        dialogueManager.dialogue.sentences.Add("Ah yes, now I remember! I miss the egg!");
                        dialogueManager.dialogue.sentences.Add("Yes, of course, you remember. I just brought it to you.");
                        dialogueManager.dialogue.sentences.Add("Hurray! Now I can make a cake! Give me that! Here, take this bus ticket. I don't need it. I don't like traveling.");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                        if (AudioManager.instance != null)
                        {
                            AudioManager.instance.Play("Prendere_oggetto_sfx");
                        }

                    }
                    bigliettoUI.SetActive(true);
                }

                else if (Input.GetMouseButtonDown(0) && selection.name == "Prince" && scolapastaPortato == false && bambinoCounter1 == 0)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Prince");
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("Prince");
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("Prince");
                        dialogueManager.dialogue.names.Add("Prince");
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("Prince");
                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("HEEEEEEY MISSSSSSS!!");
                        dialogueManager.dialogue.sentences.Add("...Hi.");
                        dialogueManager.dialogue.sentences.Add("Are you the one who drew me?");
                        dialogueManager.dialogue.sentences.Add("I'm afraid so.");
                        dialogueManager.dialogue.sentences.Add("Well...I wanted to ask you...\nWHY AM I NOT THE KING?! I WANT TO BE THE KING!\nI need a crown that suits my rank!");
                        dialogueManager.dialogue.sentences.Add("If you help me, I'll give you a nice gift!");
                        dialogueManager.dialogue.sentences.Add("Why should I help you? I have already regretted having created you.");
                        dialogueManager.dialogue.sentences.Add("PLEEEEEEASE?");
                        dialogueManager.dialogue.sentences.Add("Uff… okay");


                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                        bambinoCounter1 = 1;
                    }
                    pickUpScolapastaScript.canPickUp = true;
                }
                else if (Input.GetMouseButtonDown(0) && selection.name == "Prince" && scolapastaPortato == false && bambinoCounter1 == 1)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Prince");
                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("WHY DID YOU DRAW ME AS A PRINCE? I WANT TO BE THE KING! AND I WANT THE CROWN!");
                        dialogueManager.dialogue.sentences.Add("Sure, sure, but when I go out, I will erase you.");


                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                        bambinoCounter1 = 2;
                    }
                }
                else if (Input.GetMouseButtonDown(0) && selection.name == "Prince" && scolapastaPortato == false && bambinoCounter1 == 2)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Prince");
                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("Next time, you could draw me inside an amusement park...");
                        dialogueManager.dialogue.sentences.Add("Next time, I'll wall your window.");


                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                        bambinoCounter1 = 3;
                    }
                }
                else if (Input.GetMouseButtonDown(0) && selection.name == "Prince" && scolapastaPortato == false && bambinoCounter1 == 3)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Prince");
                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("When I become king, you will address me as ''Your highness''!");
                        dialogueManager.dialogue.sentences.Add("Really? But if you are tall as a stool.");


                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                        bambinoCounter1 = 1;
                    }
                }

                else if (Input.GetMouseButtonDown(0) && selection.name == "Prince" && scolapastaPortato == true && uovoPortato == false && bambinoCounter2 == 0)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("King");
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("King");
                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("Sugar, milk, flour, butter, and chocolate... something is missing.");
                        dialogueManager.dialogue.sentences.Add("My will to help you?");
                        dialogueManager.dialogue.sentences.Add("I said if you help me, I'll give you a gift!");
                        dialogueManager.dialogue.sentences.Add("It better be something useful.");



                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                        bambinoCounter2 = 1;

                    }
                    pickUpUovoScript.canPickUp = true;

                }
                else if (Input.GetMouseButtonDown(0) && selection.name == "Prince" && scolapastaPortato == true && uovoPortato == false && bambinoCounter2 == 1)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();


                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("King");
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("King");

                        dialogueManager.dialogue.sentences.Add("What is the inside of the castle like?");
                        dialogueManager.dialogue.sentences.Add("There are 207 kitchens, 453 bedrooms, 115 bathrooms, and 348 dining rooms.");
                        dialogueManager.dialogue.sentences.Add("How did you manage to count them all?");
                        dialogueManager.dialogue.sentences.Add("I have a lot of free time.");


                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                        bambinoCounter2 = 2;
                    }
                }
                else if (Input.GetMouseButtonDown(0) && selection.name == "Prince" && scolapastaPortato == true && uovoPortato == false && bambinoCounter2 == 2)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("King");
                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("Don't you ever feel alone?");
                        dialogueManager.dialogue.sentences.Add("No, I have a lot of imaginary friends. Don't YOU ever feel alone?");
                        dialogueManager.dialogue.sentences.Add("Sometimes, but I'm afraid to go out, and painting helps me not to think about it.");


                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                        bambinoCounter2 = 0;
                    }
                }

                else if (Input.GetMouseButtonDown(0) && selection.name == "Prince" && uovoPortato == true && uovoPortato == true)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("King");
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("King");

                        dialogueManager.dialogue.sentences.Add("It’s cake time! I looove cooking caaaakes, I loooove eating caaaaakes!");
                        dialogueManager.dialogue.sentences.Add("Can I have a piece?");
                        dialogueManager.dialogue.sentences.Add("SHUT UP! It’s a sacred moment.");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);

                    }
                }
                //-----------------AUTOBUS----------------

                if (Input.GetMouseButtonDown(0) && selection.name == "Autobus" && bigliettoUI.activeInHierarchy == true && autobusInRange == true)
                {
                    ViaggioInAutobus();
                    if (AudioManager.instance != null)
                    {
                        AudioManager.instance.Play("Prendere_autobus_sfx");
                    }

                }
                else if (Input.GetMouseButtonDown(0) && selection.name == "Autobus" && bigliettoUI.activeInHierarchy == true && autobusInRange == false)
                {
                    if (dialogueManager.inDialogue == false)
                    {

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.sentences.Add("I have to get close to get on the bus!");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
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
                        dialogueManager.dialogue.sentences.Add("I can't get on the bus. I don't have a ticket.");

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

                        dialogueManager.dialogue.sentences.Add("Tsk... the balloon lifting system is not working.\nI need something to light the burner.");

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

                        dialogueManager.dialogue.sentences.Add("I have to get close to get on board.");

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

                        dialogueManager.dialogue.sentences.Add("To infinity and beyond.");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                        if (AudioManager.instance != null)
                        {
                            AudioManager.instance.Play("Fuoco_mongolfiera_sfx");
                        }

                    }

                }

                //-----------------Armadio----------------
                if (Input.GetMouseButtonDown(0) && selection.name == "Armadio" && armadioAperto == true && armadioScript.playerInRange == true && gambaPresa == false && pickUpGamba.canPickUp == true && dialogueManager.inDialogue == false)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.sentences.Add("This wooden leg is just what I was looking for.");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);

                    }
                    pickUpGamba.PickUpUIGraphics.SetActive(true);
                    pickUpGamba.PickUpGraphics.SetActive(false);
                    gambaPresa = true;

                }

                else if (Input.GetMouseButtonDown(0) && selection.name == "Armadio" && forcinaUI.activeInHierarchy && armadioScript.playerInRange == true && dialogueManager.inDialogue == false)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.sentences.Add("Open Sesame.");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                        if (AudioManager.instance != null)
                        {
                            AudioManager.instance.Play("Aprire_armadio_sfx");
                        }

                    }
                    armadioAperto = true;
                    forcinaUI.SetActive(false);
                    selection.GetChild(1).gameObject.SetActive(false);
                    selection.GetChild(2).gameObject.SetActive(true);

                }
                else if (Input.GetMouseButtonDown(0) && selection.name == "Armadio" && forcinaUI.activeInHierarchy && armadioScript.playerInRange == false)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.sentences.Add("I need to get closer to pick that lock.");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }

                else if (Input.GetMouseButtonDown(0) && selection.name == "Armadio" && armadioAperto == false)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.sentences.Add("It's a wardrobe closed with a padlock.");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);

                    }
                }
                else if (Input.GetMouseButtonDown(0) && selection.name == "Armadio" && armadioAperto == true && armadioScript.playerInRange == false && gambaPresa == false && pickUpGamba.canPickUp == true)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.sentences.Add("Mmm...I could get one of those wooden legs in the wardrobe.");

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
                        dialogueManager.dialogue.sentences.Add("It's a nice collection of wooden legs. Fascinating.");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);

                    }
                }
                //------------------MONTACARICHI-------------
                if (Input.GetMouseButtonDown(0) && selection.name == "Montacarichi" && gambaUI.activeInHierarchy)
                {
                    gambaUI.SetActive(false);
                    montacarichi.montacarichiRiparato = true;
                    if (dialogueManager.inDialogue == false)
                    {
                        if (AudioManager.instance != null)
                        {
                            AudioManager.instance.Play("Gamba_Leva_sfx");
                        }

                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.sentences.Add("Fits like a glove!");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                    gambaLeva.SetActive(true);
                }

                else if (Input.GetMouseButtonDown(0) && selection.name == "Montacarichi" && montacarichi.montacarichiRiparato == false)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.sentences.Add("Contraption does not move.\nThe lever is missing, I have to find something to replace it.");

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
                        dialogueManager.dialogue.sentences.Add("I have to get on the elevator first.");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);

                    }
                }

                //------------------UOMO-------------------------
                if (Input.GetMouseButtonDown(0) && selection.name == "Old Man" && conchigliaUI.activeInHierarchy && uomo.playerInRange == true)
                {
                    conchigliaUI.SetActive(false);
                    conchigliaPortata = true;
                    compariPortale = true;
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Old Man");
                        dialogueManager.dialogue.names.Add("Old Man");
                        dialogueManager.dialogue.names.Add("Old Man");
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("Old Man");
                        dialogueManager.dialogue.names.Add("Old Man");
                        dialogueManager.dialogue.names.Add("Old Man");
                        dialogueManager.dialogue.names.Add("Old Man");
                        dialogueManager.dialogue.names.Add("Old Man");
                        dialogueManager.dialogue.names.Add("Artemisia");


                        dialogueManager.dialogue.sentences.Add("Oh, finally! Now I can hear the magnificent sound of the waves...");
                        dialogueManager.dialogue.sentences.Add("And besides the sound of the sea, I hear something else... it is like a word that echoes.");
                        dialogueManager.dialogue.sentences.Add("It seems to be like... hocus pocus?");
                        dialogueManager.dialogue.sentences.Add("What the fuck??");
                        dialogueManager.dialogue.sentences.Add("And I hear more, it seems to be a nursery rhyme...");
                        dialogueManager.dialogue.sentences.Add("''In a distant time long ago,\na brave man tried to soar from a château.''");
                        dialogueManager.dialogue.sentences.Add("''He traveled far and wide in all the nations,\nseeing beautiful landscapes and ancient civilizations.''");
                        dialogueManager.dialogue.sentences.Add("''And in the end he left this world,\nto reach what shines with its own light,\nin the darkness of the night.''");
                        dialogueManager.dialogue.sentences.Add("Here, I wrote it to you on a piece of paper if you want a reminder while you're on the go.");
                        dialogueManager.dialogue.sentences.Add("Uhh...thanks i guess.");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                        if (AudioManager.instance != null)
                        {
                            AudioManager.instance.Play("Prendere_oggetto_sfx");
                        }

                    }
                    filastroccaUI.SetActive(true);
                }
                else if (Input.GetMouseButtonDown(0) && selection.name == "Old Man" && conchigliaUI.activeInHierarchy && uomo.playerInRange == false)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.sentences.Add("Better get closer first.");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);
                    }
                }

                else if (Input.GetMouseButtonDown(0) && selection.name == "Old Man" && conchigliaPortata == false && uomo.playerInRange == true && uomoCounter == 0)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Old Man");
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("Old Man");
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("Old Man");
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("Old Man");
                        dialogueManager.dialogue.names.Add("Old Man");

                        dialogueManager.dialogue.sentences.Add("Oh oh...\ngood morning princess.");
                        dialogueManager.dialogue.sentences.Add("No, listen, if you are looking for someone with royal blood, it is 2 pictures above. I'm just a painter.");
                        dialogueManager.dialogue.sentences.Add("A painter? Ah, but what a great job, would you be able to paint such beautiful paintings like these?");
                        dialogueManager.dialogue.sentences.Add("Well, I made these paintings myself.");
                        dialogueManager.dialogue.sentences.Add("OH OH... really? But then you have traveled the world!");
                        dialogueManager.dialogue.sentences.Add("Well, no, I got inspiration from Pinterest.");
                        dialogueManager.dialogue.sentences.Add("Nani?! But you should get out of your house, you should see the world. I am now old, tired, and well... I can't physically get out of this painting.");
                        dialogueManager.dialogue.sentences.Add("But you, you have this chance. So please, do a favor to this old man. I'd like to hear the sound of the waves. Bring me something that will remind me of the sea.");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);

                        uomoCounter = 1;
                    }
                    pickUpConchiglia.canPickUp = true;
                }
                else if (Input.GetMouseButtonDown(0) && selection.name == "Old Man" && conchigliaPortata == false && uomo.playerInRange == true && uomoCounter == 1)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Old Man");
                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("Old Man");

                        dialogueManager.dialogue.sentences.Add("Oh, miss, do we know each other?");
                        dialogueManager.dialogue.sentences.Add("But we spoke a little while ago.");
                        dialogueManager.dialogue.sentences.Add("Oh yes, sure, sure, how forgetful I am.");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);

                        uomoCounter = 2;
                    }
                }
                else if (Input.GetMouseButtonDown(0) && selection.name == "Old Man" && conchigliaPortata == false && uomo.playerInRange == true && uomoCounter == 2)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("Old Man");
                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("You know, old man, you remind me of my grandfather.");
                        dialogueManager.dialogue.sentences.Add("Oh, your grandfather must have been a charming and wealthy and virile man, but also humble and honest and...");
                        dialogueManager.dialogue.sentences.Add("Yes, you definitely remind me of my grandfather.");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);

                        uomoCounter = 3;
                    }
                }
                else if (Input.GetMouseButtonDown(0) && selection.name == "Old Man" && conchigliaPortata == false && uomo.playerInRange == true && uomoCounter == 3)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Old Man");

                        dialogueManager.dialogue.sentences.Add("I love this forest, the fog gives it a mystical sense, but I would like to tan at least once in my life.");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);

                        uomoCounter = 1;
                    }
                }

                else if (Input.GetMouseButtonDown(0) && selection.name == "Old Man" && conchigliaPortata == false && uomo.playerInRange == false)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.sentences.Add("Helloooooo...\nI think that old man is deaf, I should get close first.");

                        dialogueManager.StartDialogue(dialogueManager.dialogue);

                    }
                }

                else if (Input.GetMouseButtonDown(0) && selection.name == "Old Man" && conchigliaPortata == true && lockManager.itemSelection.portaleAperto == false)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Old Man");
                        dialogueManager.dialogue.names.Add("Old Man");
                        dialogueManager.dialogue.names.Add("Old Man");

                        dialogueManager.dialogue.sentences.Add("''In a distant time long ago,\na man tried to soar from a château.''");
                        dialogueManager.dialogue.sentences.Add("''He sought what shines with its own light,\nin the darkness of the night.''");
                        dialogueManager.dialogue.sentences.Add("''But when he flew above the sea,\nhe realized how many things he could see.''");


                        dialogueManager.StartDialogue(dialogueManager.dialogue);

                    }
                }
                else if (Input.GetMouseButtonDown(0) && selection.name == "Old Man" && conchigliaPortata == true && lockManager.itemSelection.portaleAperto == true)
                {
                    if (dialogueManager.inDialogue == false)
                    {
                        dialogueManager.dialogue.sentences.Clear();
                        dialogueManager.sentences.Clear();
                        dialogueManager.dialogue.names.Clear();
                        dialogueManager.names.Clear();

                        dialogueManager.dialogue.names.Add("Artemisia");
                        dialogueManager.dialogue.names.Add("Old Man?");
                        dialogueManager.dialogue.names.Add("Artemisia");

                        dialogueManager.dialogue.sentences.Add("Take care, old man");
                        dialogueManager.dialogue.sentences.Add("Anyway, I'm actually 20 years old. I'm just very stressed.");
                        dialogueManager.dialogue.sentences.Add("Oh.");


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

                        dialogueManager.dialogue.sentences.Add("God does not exist, and we are only useless multicellular envelopes.");
                        dialogueManager.dialogue.sentences.Add("...WHAT?!");
                        dialogueManager.dialogue.sentences.Add("Ehm... Beeeee!");


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
    }

    public void ViaggioInAutobus()
    {
        if (stazione1 == true)
        {

            bigliettoUI.SetActive(false);
            Invoke("PlayerTP", 1f);
            fadeInOut.FadeIn();

        }
        else if (stazione1 == false)
        {

            bigliettoUI.SetActive(false);
            Invoke("PlayerTP", 1f);
            fadeInOut.FadeIn();
        }

    }

    public void PlayerTP()
    {
        if (stazione1 == true)
        {
            stazione1 = false;
            player.transform.position = posizioneStazione2.position;
            player.GetComponent<Animator>().SetBool("IsWalking", false);
        }
        else if (stazione1 == false)
        {
            stazione1 = true;
            player.transform.position = posizioneStazione1.position;
            player.GetComponent<Animator>().SetBool("IsWalking", false);

        }

    }

}
