using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3, 10)]
    //public string[] sentences;
    public List<string> sentences = new List<string>();
}
