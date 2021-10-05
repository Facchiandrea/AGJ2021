using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public GameObject startingScreen;
    public GameObject audioScreen;
    public GameObject creditScreen;
    public bool inAudioOptions;
    public bool inCredits;
    public GameObject fadeIn;

    private void Start()
    {
        AudioManager.instance.FadeIn("MenuMusic");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
        {
            if (inAudioOptions)
            {
                inAudioOptions = false;
                inCredits = false;
                startingScreen.SetActive(true);
                audioScreen.SetActive(false);
                creditScreen.SetActive(false);

            }
            else if (inCredits)
            {
                inAudioOptions = false;
                inCredits = false;
                startingScreen.SetActive(true);
                audioScreen.SetActive(false);
                creditScreen.SetActive(false);

            }
            else
            {
                Quitting();
            }
        }
    }

    public void Play()
    {
        AudioManager.instance.FadeOutAllSounds();
        Invoke("LoadNextScene", 2f);
        fadeIn.SetActive(true);

    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(1);

    }


    public void Quitting()
    {
        Application.Quit();
    }
    public void AudioButton()
    {
        inAudioOptions = true;
        inCredits = false;

        startingScreen.SetActive(false);
        audioScreen.SetActive(true);
        creditScreen.SetActive(false);
    }
    public void CreditsButton()
    {
        inAudioOptions = false;
        inCredits = true;

        startingScreen.SetActive(false);
        audioScreen.SetActive(false);
        creditScreen.SetActive(true);
    }

}
