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
    public bool inDialogue = false;

    private Queue<string> sentences;

    void Awake()
    {
        sentences = new Queue<string>();

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
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        //StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        inDialogue = false;
        blackPanel.SetActive(false);
        animator.SetBool("isOpen", false);
        Time.timeScale = 1;
    }
}
