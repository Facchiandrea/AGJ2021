﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodistruzione : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(AutodistruzioneCoroutine());
    }

    public IEnumerator AutodistruzioneCoroutine()
    {
        yield return new WaitForSecondsRealtime(1f);
        gameObject.SetActive(false);

    }
}