using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private CanvasGroup cg;

    private void Awake()
    {
        cg = GetComponent<CanvasGroup>();
    }

    public void ToggleResume()
    {
        cg.alpha = 0f;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }

    public void ToggleSettings()
    {

    }

    public void ToggleMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ToggleExitGame()
    {
        Application.Quit();
    }
}
