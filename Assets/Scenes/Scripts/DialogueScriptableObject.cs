using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue/Dialogue Scriptable Object")]
public class DialogueScriptableObject : ScriptableObject
{
    public DialogueLine[] dialogueLines;
}
