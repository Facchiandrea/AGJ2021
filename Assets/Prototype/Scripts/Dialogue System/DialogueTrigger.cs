using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
	public Dialogue dialogue;

    private void OnTriggerEnter(Collider other)
    {
        //Time.timeScale = 0;
        if (other.gameObject.tag == "Player")
            TriggerDialogue();
    }

    public void TriggerDialogue()
	{
		DialogueManager.instance.StartDialogue(dialogue);
	}
}