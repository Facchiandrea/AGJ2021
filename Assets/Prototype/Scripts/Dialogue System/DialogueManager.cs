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
    public bool inDialogue = false;
    [HideInInspector]
    public Queue<string> sentences;
    [HideInInspector]
    public Queue<string> names;

    public Dialogue dialogue;

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
