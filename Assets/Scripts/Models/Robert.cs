using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robert : MonoBehaviour, ITalkable
{
    [TextArea]
    public string[] dialogueText;
    [TextArea]
    public string dialogueNameText;

    public string[] GetDialogueText()
    {
        return dialogueText;
    }

    public string GetDialogueNameText(){
        return dialogueNameText;
    }
}
