using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public GameObject startingScreen;
    public GameObject audioScreen;
    public GameObject creditScreen;


    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void AudioButton()
    {

    }
    public void CreditsButton()
    {

    }

}
