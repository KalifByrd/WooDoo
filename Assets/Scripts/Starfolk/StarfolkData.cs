using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Starfolk", menuName = "Starfolk")]
public class StarfolkData : ScriptableObject
{
    public string starfolkName;
    public Color starfolkColor;
    public Color starfolkNameColor;
    public DialogueData dialogue;
}
