using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    Animator _animator;

    [SerializeField]
    TextMeshProUGUI Name;
    [SerializeField]
    TextMeshProUGUI Speech;

    [SerializeField]
    TextMeshProUGUI[] Options;

    static DialogueManager Instance;

    private DialogueNode _currentNode;

    private GameObject _talker;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
        _animator = GetComponent<Animator>();
    }

    internal static void StartDialogue(Conversation conversation, GameObject talker)
    {
        Instance._StartDialogue(conversation, talker);

    }
    private void _StartDialogue(Conversation conversation, GameObject talker)
    {
        _talker = talker;
        Show();
        Name.text = conversation.Name;
        _currentNode = conversation.StartNode;
        ShowNode(_currentNode);
    }

    public void Show()
    {
        _animator.SetBool("Show", true);
    }

    public void Hide()
    {
        _animator.SetBool("Show", false);
    }

    void ShowNode(DialogueNode node)
    {
        Speech.text = node.SpeechText;

        for (int i = 0; i < Options.Length; i++)
        {
            if(i< node.Options.Length)
            {
                Options[i].text = node.Options[i].Text;
                Options[i].transform.parent.gameObject.SetActive(true);
            }
            else
            {
                Options[i].transform.parent.gameObject.SetActive(false);
            }
        }
    }

    public void OnOptionChosen(int option)
    {
        
        DialogueNode nextNode = _currentNode.Options[option].NextNode;

        if(nextNode is EndNode)
        {
            EndNode endNode = nextNode as EndNode;
            endNode.Finish(_talker);
            Hide();
        }
        else
        {
            ShowNode(nextNode);
            _currentNode = nextNode;
        }
        
    }

}
