using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [SerializeField] private Image character1Icon;
    [SerializeField] private Image character2Icon;
    [SerializeField] private TextMeshProUGUI character1Name;
    [SerializeField] private TextMeshProUGUI character2Name;
    [SerializeField] private TextMeshProUGUI dialogueArea;

    private Queue<DialogueLine> lines = new Queue<DialogueLine>();

    public bool isDialogueActive = false;

    public float typingSpeed = 0.05f;

    private bool isTyping = false;
    private DialogueLine currentLine;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueActive = true;
        lines.Clear();
        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }

        currentLine = lines.Dequeue();

        SetValuesForCharacters();

        StartCoroutine(TypeSentence(currentLine));
    }

    public void DisplayNextDialogueLine()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueArea.text = currentLine.line;
            isTyping = false;
        }
        else
        {
            if (lines.Count == 0)
            {
                EndDialogue();
                return;
            }

            currentLine = lines.Dequeue();

            SetValuesForCharacters();

            StopAllCoroutines();

            StartCoroutine(TypeSentence(currentLine));
        }
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        isTyping = true;
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    private void SetValuesForCharacters()
    {
        if (currentLine.character1 != null)
        {
            character1Icon.gameObject.SetActive(true);

            character1Icon.sprite = currentLine.character1.characterIcon;
            character1Name.text = currentLine.character1.characterName;
        }
        else
            character1Icon.gameObject.SetActive(false);


        if (currentLine.character2 != null)
        {
            character2Icon.gameObject.SetActive(true);

            character2Icon.sprite = currentLine.character2.characterIcon;
            character2Name.text = currentLine.character2.characterName;
        }
        else
            character2Icon.gameObject.SetActive(false);
    }

    private void EndDialogue()
    {
        isDialogueActive = false;

        character1Icon.gameObject.SetActive(false);
        character2Icon.gameObject.SetActive(false);
        dialogueArea.text = "The End";
    }
}