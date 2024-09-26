using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starfolk : MonoBehaviour
{
    public bool canSpeak = false;
    public GameObject interactionUI;
    private bool hasPressedI = false; // ADDED LINE
    public GameManager gameManager;
    public GameObject dialogueBubble;

    public bool isFirstHomeDialogue1 = false;
    public bool isFirstHomeTaskComplete = false;
    public GameObject home;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool IsSpeaking()
    {
        return gameObject.GetComponent<CustomTag>().HasTag("Speaking");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Someone entered");
        if (other.tag == "Player")
        {
            gameObject.GetComponent<CustomTag>().AddTag("Speaking");
            interactionUI.SetActive(true);
            canSpeak = true;
            

        }

    }
    

    void OnTriggerExit(Collider other)
    {
        Debug.Log("oh...they left.");
        if (other.tag == "Player")
        {
            interactionUI.SetActive(false);
            canSpeak = false;
            hasPressedI = false; // ADDED LINE
            dialogueBubble.SetActive(false);
            gameObject.GetComponent<CowAIMovement>().enabled = true;
            gameManager.current = 1;
            if(gameObject.GetComponent<CustomTag>().HasTag("Speaking"))
            {
                gameObject.GetComponent<CustomTag>().RemoveTag("Speaking");
                if(gameObject.GetComponent<CustomTag>().HasTag("Speaking"))
                {
                    gameObject.GetComponent<CustomTag>().RemoveTag("Speaking");
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpeak)
        {
            if (Input.GetKeyDown(KeyCode.I)) // CHANGED LINE
            {
                if (!hasPressedI) // ADDED IF STATEMENT
                {
                    
                    hasPressedI = true;
                    
                    gameManager.SetSpeakerNameDisplayText(gameObject);
                    gameManager.StartDialogue(WhatDialogue());
                    dialogueBubble.SetActive(true);
                    gameObject.GetComponent<CowAIMovement>().enabled = false;
                    gameObject.GetComponent<Animator>().enabled = false;
                    gameObject.GetComponent<Animator>().enabled = true;
                    interactionUI.SetActive(false);
                    
                    
                    
                    
                }

                
            }
            else
            {
                hasPressedI = false;
            }
        }

    }
    public List<string> WhatDialogue()
    {
        if(!isFirstHomeDialogue1)
        {
           return FirstHomeDialogue1();
        }
        if(!isFirstHomeTaskComplete)
        {
            return FirstHomeTaskDialogue();
        }

        else
        {
            List<string> itvoid = new List<string>();
            return itvoid;
        }
    }
    
    public List<string> FirstHomeTaskDialogue()
    {
        List<string> dialogue = new List<string>();
        
        dialogue.Add("DID YOU FINISH THE HOUSE?");
        dialogue.Add("oh....no?");
        dialogue.Add("okay!");
        
        

        return dialogue;
    }
    public List<string> FirstHomeDialogue1()
    {
        List<string> dialogue = new List<string>();
        dialogue.Add("HIIIIIIII");
        dialogue.Add("........");
        dialogue.Add("oh..... he he..");
        dialogue.Add("hi");
        dialogue.Add("uh, where am I?");
        dialogue.Add("y- you dont know?");
        dialogue.Add("WHAT A FUN ADVENTURE!");
        dialogue.Add("RIGHT?");
        dialogue.Add("It's cold, I need somewhere to stay. Can you help?");
        isFirstHomeDialogue1 = true;
        gameManager.broadcast.SetActive(true);
        gameManager.boradcastText.text = "You have a new task!";
        gameManager.kiwiFirstHomeTaskObj.SetActive(true);
        gameManager.craftingGuideUIStarfolkHomeBtn.SetActive(true);
        gameManager.HideBroadcast();

        return dialogue;
    }
    public List<string> CompleteFirstHomeDialogue1()
    {
        List<string> dialogue = new List<string>();
        dialogue.Add("WOW!");
        dialogue.Add("THIS IS NOIICCEEEE!");
        dialogue.Add("Thank you...");
        dialogue.Add("Anyways, The Demo is over. Wake up. Wake UP!");
        dialogue.Add("Who am I talking to?");
        dialogue.Add("Why, them, silly!");
        dialogue.Add("Who is them?");
        dialogue.Add("....");

        return dialogue;
    }

}
