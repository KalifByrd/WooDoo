using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleHome : MonoBehaviour
{
    [SerializeField] private GameObject indicator;
    [SerializeField] private Material indicatorMaterial;
    // Start is called before the first frame update
    public GameObject interior;
    public int index = 0;
    public bool isHomeStarted = false;

    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Someone entered: " + other);
        if(indicator.activeInHierarchy && other.tag != "Grass" && other.tag != "MouseIndicator")
        {
            
            indicatorMaterial.SetColor("_Color", Color.red);
            Debug.Log("should be red");

        }
        else if(other.tag == "Player")
        {
            Debug.Log("player is here");
            // interactionUI.SetActive(true);
            // canInteract = true;
        }

    }
    void OnTriggerStay(Collider other)
    {
        if(indicator.activeInHierarchy && other.tag != "Grass" && other.tag != "MouseIndicator")
        {
           Debug.Log("the stay is: " + other);
            indicatorMaterial.SetColor("_Color", Color.red);
            Debug.Log("should be red");

        }
        else if(other.tag == "Player")
        {
            Debug.Log("player is here");
            // interactionUI.SetActive(true);
            // canInteract = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(indicator.activeInHierarchy && other.tag != "Grass" && other.tag != "MouseIndicator")
        {
            indicatorMaterial.SetColor("_Color", Color.green);
            Debug.Log("should be green");
        }
        Debug.Log("oh...they left.");
        // interactionUI.SetActive(false);
        if(other.tag == "Player")
        {
            // objectUI.SetActive(false);
            // interactionUI.SetActive(false);
            // isObjectUIPressed = false;
            // canInteract = false;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
