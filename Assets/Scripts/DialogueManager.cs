using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;  // Parent object for all dialogue UI elements
    public TMP_Text nameText;
    public Image portraitImage;
    public TMP_Text dialogueText;
    public Button nextButton;

    public DialogueLine[] dialogueLines;
    private DialogueQueue<DialogueLine> dialogueQueue = new DialogueQueue<DialogueLine>();

    void Start()
    {
        nextButton.onClick.AddListener(DisplayNextDialogue);

        // Load dialogues into the queue
        foreach (DialogueLine line in dialogueLines)
        {
            dialogueQueue.Enqueue(line);
        }

        DisplayNextDialogue();
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
            dialogueUI.SetActive(false); // Hide all dialogue UI
        }
    }
}
