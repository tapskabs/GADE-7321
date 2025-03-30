using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;  // Parent object for dialogue UI
    public TMP_Text nameText;
    public Image portraitImage;
    public TMP_Text dialogueText;
    public Button nextButton;

    public DialogueScriptableObject dialogueData; // Now using a Scriptable Object
    private DialogueQueue<DialogueLine> dialogueQueue = new DialogueQueue<DialogueLine>();

    void Start()
    {
        nextButton.onClick.AddListener(DisplayNextDialogue);

        // Load dialogues from the Scriptable Object
        if (dialogueData != null && dialogueData.dialogueLines.Length > 0)
        {
            foreach (DialogueLine line in dialogueData.dialogueLines)
            {
                dialogueQueue.Enqueue(line);
            }
            DisplayNextDialogue();
        }
        else
        {
            Debug.LogError("No dialogue data assigned!");
            dialogueUI.SetActive(false);
        }
    }

    public void DisplayNextDialogue()
    {
        if (!dialogueQueue.IsEmpty())
        {
            DialogueLine currentLine = dialogueQueue.Dequeue();
            nameText.text = currentLine.speakerName;
            portraitImage.sprite = currentLine.speakerPortrait;
            dialogueText.text = currentLine.dialogueText;
        }
        else
        {
            Debug.Log("Dialogue Finished!");
            dialogueUI.SetActive(false); // Hide dialogue UI when done
        }
    }
}

