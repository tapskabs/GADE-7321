using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public TMP_Text nameText;
    public TMP_Text speciesText;
    public Image portraitImage;
    public TMP_Text dialogueText;
    public Button nextButton;

    public DialogueScriptableObject dialogueData;
    private DialogueQueue<DialogueLine> dialogueQueue = new DialogueQueue<DialogueLine>();

    void Start()
    {
        nextButton.onClick.AddListener(DisplayNextDialogue);

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
            speciesText.text = $"Role: {currentLine.species}"; 
            portraitImage.sprite = currentLine.speakerPortrait;
            dialogueText.text = currentLine.dialogueText;
            SFXManager.Instance.PlaySFX("click");
        }
        else
        {
            Debug.Log("Dialogue Finished!");
            dialogueUI.SetActive(false);
        }
    }
}
