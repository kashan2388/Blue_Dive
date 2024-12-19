using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueTextUI;
    [SerializeField] private float typingSpeed = 0.05f;
    [SerializeField] private float panelAutoHideDelay = 2.0f;

    private Tween typingTween;
    private Tween autoHideTween;

    private void Start()
    {
        dialoguePanel.SetActive(false); 
    }

    public void ShowDialogue(string dialogue)
    {
        if (typingTween != null && typingTween.IsActive())
        {
            typingTween.Kill(); 
        }

        if (autoHideTween != null && autoHideTween.IsActive())
        {
            autoHideTween.Kill(); 
        }

        dialoguePanel.SetActive(true);
        dialogueTextUI.text = ""; 
        int totalLength = dialogue.Length;


        typingTween = DOTween.To(
            () => 0, 
            value => dialogueTextUI.text = dialogue.Substring(0, value), 
            totalLength, 
            totalLength * typingSpeed 
        ).SetEase(Ease.Linear).OnComplete(() =>
        {
            autoHideTween = DOVirtual.DelayedCall(panelAutoHideDelay, () =>
            {
                dialoguePanel.SetActive(false);
            });
        });
    }


    public void SkipTyping(string dialogue)
    {
        if (typingTween != null && typingTween.IsActive())
        {
            typingTween.Kill();
        }

        if (autoHideTween != null && autoHideTween.IsActive())
        {
            autoHideTween.Kill(); 
        }

        dialogueTextUI.text = dialogue; 

        autoHideTween = DOVirtual.DelayedCall(panelAutoHideDelay, () =>
        {
            dialoguePanel.SetActive(false);
        });
    }
}
