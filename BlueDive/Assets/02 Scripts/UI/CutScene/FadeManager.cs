using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance;

    [Header("Fade Settings")]
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 유지
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void FadeIn(System.Action onComplete = null)
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.DOFade(1f, fadeDuration).OnComplete(() =>
        {
            onComplete?.Invoke();
        });
    }

    public void FadeOut(System.Action onComplete = null)
    {
        fadeImage.DOFade(0f, fadeDuration).OnComplete(() =>
        {
            fadeImage.gameObject.SetActive(false);
            onComplete?.Invoke();
        });
    }

    public void InstantFadeIn()
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1f);
    }

    public void InstantFadeOut()
    {
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0f);
        fadeImage.gameObject.SetActive(false);
    }
}
