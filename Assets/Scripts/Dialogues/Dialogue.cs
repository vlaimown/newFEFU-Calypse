using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    public string[] name;
    [TextArea(6, 10)]
    public string[] sentenses;
    public Sprite[] icons;
}
