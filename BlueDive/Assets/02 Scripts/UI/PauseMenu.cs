using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused { get; private set; } = false;
    [SerializeField] private GameObject pauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }


    public void ResumeGame()
    {
        Time.timeScale = 1f;
        IsPaused = false;
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false); 
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; 
        IsPaused = true;
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(true);
    }
}
