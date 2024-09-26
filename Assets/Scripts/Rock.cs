using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private int health = 3;
    public GameObject interactionUI;
    private bool canMineRock = false;
    private bool hasPressedX = false; // ADDED LINE
    public GameObject stone;
    public GameObject iron;
    public Transform stoneParent;
    public Transform ironParent;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Someone entered");
        if (other.tag == "Player")
        {
            if (other.GetComponent<CustomTag>().HasTag("HoldingPickaxe") || other.GetComponent<CustomTag>().HasTag("HoldingSimpleTool"))
            {
                interactionUI.SetActive(true);
                canMineRock = true;
            }

        }

    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("oh...they left.");
        interactionUI.SetActive(false);
        canMineRock = false;
        hasPressedX = false; // ADDED LINE
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMineRock)
        {
            if (Input.GetKeyDown(KeyCode.X)) // CHANGED LINE
            {
                if (!hasPressedX) // ADDED IF STATEMENT
                {
                    health--;
                    Debug.Log("Our Rock health is: " + health);
                    Instantiate(stone, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity, stoneParent);

                    hasPressedX = true;
                    int index = Random.Range(1, 4);
                    if(index == 1)
                    {
                        Instantiate(iron, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity, ironParent);
                    }
                    if(index == 2)
                    {
                        Instantiate(iron, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity, ironParent);
                        Instantiate(iron, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity, ironParent);
                    }
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
