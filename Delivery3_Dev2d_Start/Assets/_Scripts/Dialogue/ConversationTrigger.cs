using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTrigger : MonoBehaviour
{
    public Conversation DialogueData;
    public Conversation DialogueDataAfterTransaction;

    private void Start()
    {
        StartDialogue();
    }

    public void StartDialogue()
    {
        DialogueManager.StartDialogue(DialogueData, gameObject);
    }

    public void StartDialogueAfterTransaction()
    {
        DialogueManager.StartDialogue(DialogueDataAfterTransaction, gameObject);
    }
}