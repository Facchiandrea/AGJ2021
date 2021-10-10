﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockManager : MonoBehaviour
{
    public ItemSelection itemSelection;
    public bool lockPuzzleActive = false;
    public GameObject puzzlePanel;
    public GameObject portaleIncatenato;
    public GameObject aperto;
    public GameObject scatenato;


    public TextMeshProUGUI num1TXT;
    public TextMeshProUGUI num2TXT;
    public TextMeshProUGUI num3TXT;

    public bool oraPuoiCliccare = false;

    public int counter1;
    public int counter2;
    public int counter3;

    private void Start()
    {
        counter1 = 0;
        counter2 = 0;
        counter3 = 0;
        num1TXT.text = counter1.ToString();
        num2TXT.text = counter2.ToString();
        num3TXT.text = counter3.ToString();

    }

    private void Update()
    {
        if (counter1 == 2 && counter2 == 6 && counter3 == 4)
        {
            counter1 = 0;
            itemSelection.portaleAperto = true;
            ExitPuzzle();
            StartCoroutine(Dissolvi());
            scatenato.SetActive(true);

            if (AudioManager.instance != null)
            {
                AudioManager.instance.Play("Click_Lucchetto_sfx");
            }
        }
    }

    public IEnumerator Dissolvi()
    {
        float progress = 0;

        while (progress < 1f)
        {
            float newAlpha = Mathf.Lerp(1f, 0f, (progress / 1f));
            portaleIncatenato.GetComponent<SpriteRenderer>().color = new Color(portaleIncatenato.GetComponent<SpriteRenderer>().color.r, portaleIncatenato.GetComponent<SpriteRenderer>().color.g, portaleIncatenato.GetComponent<SpriteRenderer>().color.b, newAlpha);
            progress += Time.deltaTime;
            yield return null;
        }
        new WaitForSeconds(1f);
        portaleIncatenato.GetComponent<SpriteRenderer>().color = new Color(portaleIncatenato.GetComponent<SpriteRenderer>().color.r, portaleIncatenato.GetComponent<SpriteRenderer>().color.g, portaleIncatenato.GetComponent<SpriteRenderer>().color.b, 0);
        aperto.SetActive(true);
        scatenato.SetActive(false);
        oraPuoiCliccare = true;

        yield return null;

    }
    public void PuzzleLockStart()
    {
        lockPuzzleActive = true;
        puzzlePanel.SetActive(true);
    }


    public void ExitPuzzle()
    {
        lockPuzzleActive = false;
        puzzlePanel.SetActive(false);
    }

    public void Button1Click()
    {
        counter1++;
        if (counter1 >= 10)
        {
            counter1 = 0;
        }
        num1TXT.text = counter1.ToString();
    }
    public void Button2Click()
    {
        counter2++;
        if (counter2 >= 10)
        {
            counter2 = 0;
        }
        num2TXT.text = counter2.ToString();

    }
    public void Button3Click()
    {
        counter3++;
        if (counter3 >= 10)
        {
            counter3 = 0;
        }
        num3TXT.text = counter3.ToString();
    }

}
