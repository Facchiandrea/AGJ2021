using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public bool inPause;
    public bool inMenuOption;
    public GameObject fadePanel;
    public DialogueManager dialogueManager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inPause && inMenuOption == false)
            {
                Continue();
            }
            else if (inPause && inMenuOption == true)
            {
                optionsMenu.SetActive(false);
                pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 0;
                inPause = true;
                optionsMenu.SetActive(false);
                pauseMenu.SetActive(true);
            }
        }
    }

    public void ToOptions()
    {
        inMenuOption = true;
        optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void Continue()
    {
        if (dialogueManager.inDialogue == false)
        {
            Time.timeScale = 1;
        }
        inPause = false;
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }
    public void ReturnToMenu()
    {
        StartCoroutine(ChangeSceneCoroutine());
        AudioManager.instance.StopAllSounds();
        fadePanel.SetActive(true);
    }

    public IEnumerator ChangeSceneCoroutine()
    {
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        yield return null;
    }

}
