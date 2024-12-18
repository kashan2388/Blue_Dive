using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueData : MonoBehaviour, IItem
{
    [TextArea]
    [SerializeField] private string dialogueText;
    [SerializeField] private string itemName = "Dialogue";
    public string GetDialogueText()
    {
        return dialogueText;
    }
    public string GetItemName()
    {
        return itemName;
    }
    public void Use()
    {
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        if (dialogueManager != null)
        {
            dialogueManager.ShowDialogue(dialogueText);

            gameObject.SetActive(false);
        }
    }
}

