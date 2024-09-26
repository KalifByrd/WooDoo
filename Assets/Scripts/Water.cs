using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public AnimationAndMovementController animationAndMovementController;
    public GameObject player;
    void Start()
    {
        animationAndMovementController = GameObject.Find("Player").GetComponent<AnimationAndMovementController>();
        player = GameObject.Find("Player");
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("I'm the trigger, someone has entered: " + other.tag);
        if(other.tag == "Player")
        {
            animationAndMovementController.swimExitTriggered = false;
            animationAndMovementController.swimTriggered = true;
            player.GetComponent<Animator>().SetBool("IsSwimIdle", true);
            

            Debug.Log("trigger should be true: " + animationAndMovementController.swimTriggered);
        }

    }
}
