using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class PickUps : MonoBehaviour
{
    public GameObject inventorySlots;
    public GameObject pickUpUI;
    private bool canPickUp = false;
    public GameObject twigIcon;
    public GameObject pebbleIcon;
    public GameObject woodIcon;
    public GameObject stoneIcon;
    public GameObject woolIcon;
    public GameObject ironIcon;
    private List<GameObject> icons = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        icons.Add(twigIcon);
        icons.Add(pebbleIcon);
        icons.Add(woodIcon);
        icons.Add(stoneIcon);
        icons.Add(woolIcon);
        icons.Add(ironIcon);
        
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Someone entered");
        if(other.tag == "Player")
        {
            Debug.Log("player is here");
            pickUpUI.SetActive(true);
            canPickUp = true;
        }

    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("oh...they left.");
        pickUpUI.SetActive(false);
        canPickUp = false;
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if(canPickUp)
        {
            if(Input.GetKey("x"))
            {
                for(int i = 0; i < inventorySlots.transform.GetChildCount(); i++)
                {
                    GameObject slot = inventorySlots.transform.GetChild(i).gameObject;
                    for(int j = 0; j < slot.transform.GetChildCount(); j++)
                    {
                        GameObject button = slot.transform.GetChild(j).gameObject;
                        if(button.transform.childCount == 0)
                        {
                            for(int k = 0; k < icons.Count ; k++)
                            {
                                
                                GameObject icon = icons[k];
                                if(gameObject.tag == icon.tag)
                                {
                                    GameObject currentIcon = Instantiate(icon);
                                    currentIcon.transform.SetParent(button.transform);
                                    currentIcon.transform.localScale = new Vector3(0.35f, 0.35f);
                                    Destroy(gameObject);
                                    i =100;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
                
                
            }
        }
    }

}
