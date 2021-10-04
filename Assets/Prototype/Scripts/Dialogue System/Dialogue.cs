using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
public class Dialogue
{
    [TextArea(3, 10)]
    //public string[] sentences;
    public List<string> sentences = new List<string>();
    public List<string> names = new List<string>();

}
