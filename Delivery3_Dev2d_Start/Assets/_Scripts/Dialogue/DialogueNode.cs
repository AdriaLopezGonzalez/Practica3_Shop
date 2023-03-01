using UnityEngine;

[CreateAssetMenu(fileName = "newNode",
    menuName = "Dialogues/Node", order = 1)]
public class DialogueNode : ScriptableObject
{
    public string SpeechText;
    public DialogueOptions[] Options;
    //falten options
}

[System.Serializable]
public class DialogueOptions
{
    public string Text;
    public DialogueNode NextNode;

}