using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetecter : MonoBehaviour
{
    //[SerializeField] private LayerMask itemLayer;
    //[SerializeField] private LayerMask dialogueLayer;

    //private DialogueManager dialogueManager;

    //private void Start()
    //{
    //    dialogueManager = FindObjectOfType<DialogueManager>();
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (((1 << collision.gameObject.layer) & itemLayer) != 0)
    //    {
    //        IItem item = collision.GetComponent<IItem>();
    //        if (item != null)
    //        {
    //            HandleItemPickup(item);
    //        }
    //    }

    //    if (((1 << collision.gameObject.layer) & dialogueLayer) != 0)
    //    {
    //        DialogueData dialogueData = collision.GetComponent<DialogueData>();
    //        if (dialogueData != null)
    //        {
    //            HandleDialogue(dialogueData);
    //        }
    //    }
    //}

    //private void HandleItemPickup(IItem item)
    //{
    //    item.Use();
    //    Debug.Log("Item used: " + item.GetItemName());
    //}

    //private void HandleDialogue(DialogueData dialogueData)
    //{
    //    if (dialogueManager != null)
    //    {
    //        dialogueManager.ShowDialogue(dialogueData.GetDialogueText());
    //    }
    //}
    [SerializeField] private LayerMask itemLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // IItem 인터페이스를 구현한 객체 감지
        IItem item = collision.GetComponent<IItem>();
        if (item != null)
        {
            HandleItemPickup(item);
        }
    }

    private void HandleItemPickup(IItem item)
    {
        item.Use();
        Debug.Log($"Item used: {item.GetItemName()}");
    }
}
