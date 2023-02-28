using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTrigger : MonoBehaviour
{
    public Conversation DialogueData;

    private void Start()
    {
        StartDialogue();
    }

    public void StartDialogue()
    {
        DialogueManager.StartDialogue(DialogueData, gameObject);
    }
}