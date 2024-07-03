using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject taskPanel;
    public Text talkText;
    public Text nameText;
    public bool isAction;
    bool isNpc;
    int dialogueIndex = 0;
    string[] currentDialogue;

    public void ShowDialogue(string nameText, string[] text)
    {
        isAction = true;
        this.nameText.text = nameText;
        currentDialogue = text;
        taskPanel.SetActive(isAction);
        ShowNextDialogue();
    }

    public void ShowNextDialogue()
    {
        if (dialogueIndex < currentDialogue.Length)
        {
            talkText.text = currentDialogue[dialogueIndex];
            dialogueIndex++;
        }
        else
        {
            dialogueIndex = 0;
            isAction = false;
            taskPanel.SetActive(isAction);
        }
    }

}
