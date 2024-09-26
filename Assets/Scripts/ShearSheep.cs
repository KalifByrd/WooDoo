using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShearSheep : MonoBehaviour
{
    private int shearAmount = 3;
    public GameObject interactionUI;
    private bool canShearSheep = false;
    private bool hasPressedX = false; // ADDED LINE
    public GameObject wool;
    public Transform woolParent;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Someone entered");
        if (other.tag == "Player")
        {
            if (other.GetComponent<CustomTag>().HasTag("HoldingShears"))
            {
                interactionUI.SetActive(true);
                canShearSheep = true;
            }

        }

    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("oh...they left.");
        interactionUI.SetActive(false);
        canShearSheep = false;
        hasPressedX = false; // ADDED LINE
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canShearSheep)
        {
            if (Input.GetKeyDown(KeyCode.X)) // CHANGED LINE
            {
                if (!hasPressedX) // ADDED IF STATEMENT
                {
                    shearAmount--;
                    
                    Debug.Log("Our Sheeps shear amount is: " + shearAmount);
                    hasPressedX = true;

                    int index = Random.Range(1, 4);
                    if (shearAmount <= 0)
                    {
                        Debug.Log("This sheep cannot be sheared anymore!");
                    }
                    if (index == 1)
                    {
                        Instantiate(wool, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity, woolParent);
                        Instantiate(wool, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity, woolParent);
                        Instantiate(wool, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity, woolParent);
                    }
                    else if(index == 2)
                    {
                        Instantiate(wool, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity, woolParent);
                        Instantiate(wool, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity, woolParent);
                    }
                    else
                    {
                        Instantiate(wool, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity, woolParent);
                    }
                    
                    
                    
                }

                
            }
            else
            {
                hasPressedX = false;
            }
        }

    }
}
