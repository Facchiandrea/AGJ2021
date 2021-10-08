using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    public GameObject blackPanel;
    public GameObject portrait;
    public GameObject dialogueParent;
    public bool inDialogue = false;
    [HideInInspector]
    public Queue<string> sentences;
    [HideInInspector]
    public Queue<string> names;
    public Dialogue dialogue;

    public GameObject artemisiaPortrait;
    public GameObject tutorialPortrait;
    public GameObject ragazzoPortrait;
    public GameObject bambinoPortrait;
    public GameObject uomoPortrait;
    public GameObject pecoraPortrait;

    public NPCInteractor NPCInteractor;

    void Awake()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        if (instance == null)
            instance = this;
    }

    private void Update()
    {
        if (inDialogue && Input.GetMouseButtonDown(0))
        {
            DisplayNextSentence();
        }
    }
    public void StartDialogue(Dialogue dialogue)
    {
        Time.timeScale = 0;
        inDialogue = true;
        blackPanel.SetActive(true);
        animator.SetBool("isOpen", true);


        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
        }


    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();

        //StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        StartCoroutine(TypeName(name));

    }

    IEnumerator TypeSentence(string sentence)
    {
        /*dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }*/
        dialogueText.text = sentence;
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("Avanti_Dialogo_sfx");
        }

        if (dialogueText.text == "It seems to be like... hocus pocus?" && NPCInteractor.compariPortale) //CONTROLLARE
        {
            NPCInteractor.uomo.portale.SetActive(true);
            NPCInteractor.compariPortale = false;
            Debug.Log("portale comparso");
        }


        yield return null;

    }
    IEnumerator TypeName(string name)
    {
        /*nameText.text = "";
        foreach (char letter in name.ToCharArray())
        {
            nameText.text += letter;
            yield return null;
        }*/

        nameText.text = name;
        if (nameText.text == "Artemisia")
        {
            artemisiaPortrait.SetActive(true);
            tutorialPortrait.SetActive(false);
            bambinoPortrait.SetActive(false);
            uomoPortrait.SetActive(false);
            ragazzoPortrait.SetActive(false);
            pecoraPortrait.SetActive(false);

            dialogueParent.transform.localScale = new Vector3(1, 1, 1);
            nameText.transform.localScale = new Vector3(1, 1, 1);
            dialogueText.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (nameText.text == "???")
        {
            artemisiaPortrait.SetActive(false);
            tutorialPortrait.SetActive(true);
            bambinoPortrait.SetActive(false);
            uomoPortrait.SetActive(false);
            ragazzoPortrait.SetActive(false);
            pecoraPortrait.SetActive(false);

            dialogueParent.transform.localScale = new Vector3(-1, 1, 1);
            nameText.transform.localScale = new Vector3(-1, 1, 1);
            dialogueText.transform.localScale = new Vector3(-1, 1, 1);

        }
        else if (nameText.text == "Tut Orial")
        {
            artemisiaPortrait.SetActive(false);
            tutorialPortrait.SetActive(true);
            bambinoPortrait.SetActive(false);
            uomoPortrait.SetActive(false);
            ragazzoPortrait.SetActive(false);
            pecoraPortrait.SetActive(false);

            dialogueParent.transform.localScale = new Vector3(-1, 1, 1);
            nameText.transform.localScale = new Vector3(-1, 1, 1);
            dialogueText.transform.localScale = new Vector3(-1, 1, 1);

        }
        else if (nameText.text == "Ragazzo") //CONTROLLARE
        {
            artemisiaPortrait.SetActive(false);
            tutorialPortrait.SetActive(false);
            bambinoPortrait.SetActive(false);
            uomoPortrait.SetActive(false);
            ragazzoPortrait.SetActive(true);
            pecoraPortrait.SetActive(false);

            dialogueParent.transform.localScale = new Vector3(-1, 1, 1);
            nameText.transform.localScale = new Vector3(-1, 1, 1);
            dialogueText.transform.localScale = new Vector3(-1, 1, 1);

        }
        else if (nameText.text == "Rebeeecca" || nameText.text == "Beeeatrice" || nameText.text == "Beeeth" || nameText.text == "Baaarbara")
        {
            artemisiaPortrait.SetActive(false);
            tutorialPortrait.SetActive(false);
            bambinoPortrait.SetActive(false);
            uomoPortrait.SetActive(false);
            ragazzoPortrait.SetActive(false);
            pecoraPortrait.SetActive(true);

            dialogueParent.transform.localScale = new Vector3(-1, 1, 1);
            nameText.transform.localScale = new Vector3(-1, 1, 1);
            dialogueText.transform.localScale = new Vector3(-1, 1, 1);

        }

        else if (nameText.text == "Prince") //CONTROLLARE
        {
            artemisiaPortrait.SetActive(false);
            tutorialPortrait.SetActive(false);
            bambinoPortrait.SetActive(true);
            uomoPortrait.SetActive(false);
            ragazzoPortrait.SetActive(false);
            pecoraPortrait.SetActive(false);

            dialogueParent.transform.localScale = new Vector3(-1, 1, 1);
            nameText.transform.localScale = new Vector3(-1, 1, 1);
            dialogueText.transform.localScale = new Vector3(-1, 1, 1);

        }
        else if (nameText.text == "King") //CONTROLLARE
        {
            artemisiaPortrait.SetActive(false);
            tutorialPortrait.SetActive(false);
            bambinoPortrait.SetActive(true);
            uomoPortrait.SetActive(false);
            ragazzoPortrait.SetActive(false);
            pecoraPortrait.SetActive(false);

            dialogueParent.transform.localScale = new Vector3(-1, 1, 1);
            nameText.transform.localScale = new Vector3(-1, 1, 1);
            dialogueText.transform.localScale = new Vector3(-1, 1, 1);

        }

        else if (nameText.text == "Old Man") //CONTROLLARE
        {
            artemisiaPortrait.SetActive(false);
            tutorialPortrait.SetActive(false);
            bambinoPortrait.SetActive(false);
            uomoPortrait.SetActive(true);
            ragazzoPortrait.SetActive(false);
            pecoraPortrait.SetActive(false);

            dialogueParent.transform.localScale = new Vector3(-1, 1, 1);
            nameText.transform.localScale = new Vector3(-1, 1, 1);
            dialogueText.transform.localScale = new Vector3(-1, 1, 1);

        }

        yield return null;
    }


    void EndDialogue()
    {
        inDialogue = false;
        blackPanel.SetActive(false);
        animator.SetBool("isOpen", false);
        Time.timeScale = 1;
    }
}
