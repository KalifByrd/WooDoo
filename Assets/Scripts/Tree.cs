using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Tree : MonoBehaviour
{
    private int health = 3;
    public GameObject interactionUI;
    private bool canChopTree = false;
    private bool hasPressedX = false; // ADDED LINE
    public GameObject wood;
    public Transform woodParent;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Someone entered");
        if (other.tag == "Player")
        {
            if (other.GetComponent<CustomTag>().HasTag("HoldingAxe") || other.GetComponent<CustomTag>().HasTag("HoldingSimpleTool"))
            {
                interactionUI.SetActive(true);
                canChopTree = true;
            }

        }

    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("oh...they left.");
        interactionUI.SetActive(false);
        canChopTree = false;
        hasPressedX = false; // ADDED LINE
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canChopTree)
        {
            if (Input.GetKeyDown(KeyCode.X)) // CHANGED LINE
            {
                if (!hasPressedX) // ADDED IF STATEMENT
                {
                    health--;
                    Debug.Log("Our tree health is: " + health);
                    Instantiate(wood, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity, woodParent);
                    hasPressedX = true;
                }

                if (health <= 0)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                hasPressedX = false;
            }
        }

    }
}