using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageCutScene : Skippable
{
    [Header("Cutscene Settings")]
    [SerializeField] private Image[] panels;       
    [SerializeField] private float panelDisplayTime = 2f; 
    [SerializeField] private float fadeDuration = 1f;    

    private int currentPanelIndex = 0; 
    private bool isSkipping = false;

    private void Start()
    {
        foreach (var panel in panels)
        {
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0f);
            panel.gameObject.SetActive(false); 
        }

        StartCoroutine(PlayCutScene());
    }

    private IEnumerator PlayCutScene()
    {
        while (currentPanelIndex < panels.Length)
        {
            if (isSkipping) break;

            var currentPanel = panels[currentPanelIndex];

            currentPanel.gameObject.SetActive(true);
            yield return FadeInImage(currentPanel);

            yield return new WaitForSeconds(panelDisplayTime);

            currentPanelIndex++;
        }

        OnCutSceneEnd();
    }

    private IEnumerator FadeInImage(Image panel)
    {
        float elapsed = 0f;
        Color color = panel.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsed / fadeDuration);
            panel.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        panel.color = new Color(color.r, color.g, color.b, 1f); 
    }

    public override void Skip()
    {
        if (isSkipping) return;

        isSkipping = true;
        StopAllCoroutines();

        foreach (var panel in panels)
        {
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 1f);
            panel.gameObject.SetActive(true);
        }

        OnCutSceneEnd();
    }

    private void OnCutSceneEnd()
    {
        FadeManager.Instance.FadeIn(() =>
        {
            Debug.Log("Next Scene Loaded.");
            // SceneManager.LoadScene("NextScene");
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Skip();
        }
    }
}
