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
        dialogue.Add("Hello.");
        dialogue.Add("Once again, you find yourself in the void.");
        dialogue.Add("Rest assured, we have all been here.");
        dialogue.Add("As we are all a part of the universe, which makes us … well, the universe!");
        dialogue.Add("Observe me as I observe you, a cosmic dance of perception. The universe observes itself. Isn't it mind-boggling?");
        dialogue.Add(". . .");
        dialogue.Add("Perplexed, are you?");
        dialogue.Add("You’ll learn.");
        dialogue.Add("We all do, through life, through death, through the in-between places…");
        dialogue.Add("Take comfort in the knowledge that everything is mutable. Within the void, we must find the light within ourselves. We are the universe remember? Change is at our will.");
        dialogue.Add("And what did your dearest ones call you? How shall we address you in this shared reality?");
        //dialogue.Add("Hello");
        return dialogue;
    }
}
