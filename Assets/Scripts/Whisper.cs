using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whisper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsSpeaking()
    {
        return gameObject.GetComponent<CustomTag>().HasTag("Speaking");
    }

    public List<string> IntroDialogue()
    {
        List<string> dialogue = new List<string>();
        dialogue.Add("Hello?");
        dialogue.Add("You're not dreaming.");
        dialogue.Add("You're in the void . . .");
        dialogue.Add("Open your eyes!");
        return dialogue;
    }
}
