using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import TextMeshPro namespace

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;  // Use TMP_Text instead of Text
    public Image portraitImage;
    public TMP_Text dialogueText;  // Use TMP_Text instead of Text
    public Button nextButton;

    public DialogueLine[] dialogueLines; // Assign in Inspector
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
            nextButton.gameObject.SetActive(false);
        }
    }
}
