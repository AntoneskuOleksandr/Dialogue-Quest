using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public Character character1;
    public Character character2;

    public int whoSpeak;

    [TextArea(3, 10)]
    public string line;

    public Sprite BackGround;
}

[System.Serializable]
public class Dialogue
{ 
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}


public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }
}
