using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hills : MonoBehaviour
{
    public GameObject player;
    public AnimationAndMovementController animationAndMovementController;
    private bool spacePressed;
    private bool canUseLadder = false;
    private bool hasPressedSpace = false;
    //[SerializeField] Transform _handPosition, _standPosition;
    // [SerializeField]
    // private float yOffset = 6.5f;
    
    void Start()
    {
        player = PlayerReference.player;
        animationAndMovementController = player.GetComponent<AnimationAndMovementController>();
        
        //animationAndMovementController.newHandPos = new Vector3(_handPosition.position.x, _handPosition.position.y - yOffset, _handPosition.position.z);
    }
    void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player" && animationAndMovementController.swimTriggered && Input.GetKey("space"))
        {
            Debug.Log("I'm the hill trigger, someone has entered: " + other.tag);
            //player.transform.position += player.transform.forward * 1.2f;
            
            // player.SetActive(false);
            // player.transform.position += player.transform.forward * 1f;
            // player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1.7f, player.transform.position.z);
            // player.SetActive(true);
            //animationAndMovementController.swimTriggered = false;
            
            animationAndMovementController.swimExitTriggered = true;
            animationAndMovementController.swimTriggered = false;
            //animationAndMovementController._activeLedge = this;
            
            Debug.Log("trigger should be false: " + animationAndMovementController.swimTriggered);
        }
        if(other.tag == "Player")
        {
            if (other.GetComponent<CustomTag>().HasTag("HoldingLadder"))
            {
                canUseLadder = true;
            }
        }

    }
    void OnTriggerExit(Collider other)
    {
        
        
        canUseLadder = false;
        hasPressedSpace = false; // ADDED LINE
    }
    void Update()
    {
        if (canUseLadder && !animationAndMovementController.swimTriggered)
        {
            if (Input.GetKeyDown(KeyCode.Space)) // CHANGED LINE
            {
                if (!hasPressedSpace) // ADDED IF STATEMENT
                {
                    player.gameObject.SetActive(false);
                    player.gameObject.transform.position += player.gameObject.transform.forward * 1f;
                    player.gameObject.transform.position = new Vector3(player.gameObject.transform.position.x, player.gameObject.transform.position.y + 1.7f, player.gameObject.transform.position.z);
                    player.gameObject.SetActive(true);
                    canUseLadder = false;
                }
            }
            else
            {
                hasPressedSpace = false;
            }
        }

    }

}
