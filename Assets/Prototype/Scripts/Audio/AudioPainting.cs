using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPainting : MonoBehaviour
{
    public string ambientMusicName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator") && AudioManager.instance != null)
        {
            AudioManager.instance.FadeIn(ambientMusicName);
            AudioManager.instance.FadeOutAllSounds();
        }
    }
}
