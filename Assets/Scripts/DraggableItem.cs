using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool isBeingDragged;
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;
    
    public GameObject playerUICanvas;
    private Transform craftingResultParent;
    private Transform firstCraftingSlot;
    private Transform secondCraftingSlot;
    private Transform thirdCraftingSlot;
    private Transform fourthCraftingSlot;

    public Transform objectCraftingResultParent;
    public Transform firstObjectCraftingSlot;
    public Transform secondObjectCraftingSlot;
    public Transform thirdObjectCraftingSlot;
    public Transform fourthObjectCraftingSlot;
    public Transform fifthObjectCraftingSlot;
    public Transform sixthObjectCraftingSlot;
    public Transform seventhObjectCraftingSlot;
    public Transform eigthObjectCraftingSlot;
    public Transform ninthObjectCraftingSlot;
    public Transform tenthObjectCraftingSlot;

    private GameObject player;
    

    public GameObject item;
    void Start()
    {
        player = PlayerReference.player;
        // un comment later
        // playerUICanvas = GameObject.Find("PlayerUICanvas");
        // craftingResultParent = GameObject.Find("Player").transform.GetChild(5).GetChild(0).GetChild(1).GetChild(5).GetChild(0);
        // firstCraftingSlot = GameObject.Find("Player").transform.GetChild(5).GetChild(0).GetChild(1).GetChild(1).GetChild(0);
        // secondCraftingSlot = GameObject.Find("Player").transform.GetChild(5).GetChild(0).GetChild(1).GetChild(2).GetChild(0);
        // thirdCraftingSlot = GameObject.Find("Player").transform.GetChild(5).GetChild(0).GetChild(1).GetChild(3).GetChild(0);
        // fourthCraftingSlot = GameObject.Find("Player").transform.GetChild(5).GetChild(0).GetChild(1).GetChild(4).GetChild(0);

        // objectCraftingResultParent = GameObject.Find("GameManager").transform.GetChild(3).GetChild(1).GetChild(10).GetChild(0);
        // firstObjectCraftingSlot = GameObject.Find("GameManager").transform.GetChild(3).GetChild(1).GetChild(0).GetChild(0);
        // secondObjectCraftingSlot = GameObject.Find("GameManager").transform.GetChild(3).GetChild(1).GetChild(1).GetChild(0);
        // thirdObjectCraftingSlot = GameObject.Find("GameManager").transform.GetChild(3).GetChild(1).GetChild(2).GetChild(0);
        // fourthObjectCraftingSlot = GameObject.Find("GameManager").transform.GetChild(3).GetChild(1).GetChild(3).GetChild(0);
        // fifthObjectCraftingSlot = GameObject.Find("GameManager").transform.GetChild(3).GetChild(1).GetChild(4).GetChild(0);
        // sixthObjectCraftingSlot = GameObject.Find("GameManager").transform.GetChild(3).GetChild(1).GetChild(5).GetChild(0);
        // seventhObjectCraftingSlot = GameObject.Find("GameManager").transform.GetChild(3).GetChild(1).GetChild(6).GetChild(0);
        // eigthObjectCraftingSlot = GameObject.Find("GameManager").transform.GetChild(3).GetChild(1).GetChild(7).GetChild(0);
        // ninthObjectCraftingSlot = GameObject.Find("GameManager").transform.GetChild(3).GetChild(1).GetChild(8).GetChild(0);
        // tenthObjectCraftingSlot = GameObject.Find("GameManager").transform.GetChild(3).GetChild(1).GetChild(9).GetChild(0);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(player.transform.Find("PlayerUI/PlayerUICanvas"));
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        //if(GameObject.Find("GridParent").transform.GetChild(0).)
        if(parentAfterDrag.tag == "CraftingSlot")
        {
            if(craftingResultParent.childCount > 0)
            {
                Destroy(craftingResultParent.GetChild(0).gameObject);
            }
            if(objectCraftingResultParent.childCount > 0)
            {
                Destroy(objectCraftingResultParent.GetChild(0).gameObject);
            }
        }
        if(parentAfterDrag.tag == "ResultSlot")
        {
            if(firstCraftingSlot.childCount > 0)
            {
                Destroy(firstCraftingSlot.GetChild(0).gameObject);
            }
            if(secondCraftingSlot.childCount > 0)
            {
                Destroy(secondCraftingSlot.GetChild(0).gameObject);
            }
            if(thirdCraftingSlot.childCount > 0)
            {
                Destroy(thirdCraftingSlot.GetChild(0).gameObject);
            }
            if(fourthCraftingSlot.childCount > 0)
            {
                Destroy(fourthCraftingSlot.GetChild(0).gameObject);
            }


            if(firstObjectCraftingSlot.childCount > 0)
            {
                Destroy(firstObjectCraftingSlot.GetChild(0).gameObject);
            }
            if(secondObjectCraftingSlot.childCount > 0)
            {
                Destroy(secondObjectCraftingSlot.GetChild(0).gameObject);
            }
            if(thirdObjectCraftingSlot.childCount > 0)
            {
                Destroy(thirdObjectCraftingSlot.GetChild(0).gameObject);
            }
            if(fourthObjectCraftingSlot.childCount > 0)
            {
                Destroy(fourthObjectCraftingSlot.GetChild(0).gameObject);
            }
            if(fifthObjectCraftingSlot.childCount > 0)
            {
                Destroy(fifthObjectCraftingSlot.GetChild(0).gameObject);
            }
            if(sixthObjectCraftingSlot.childCount > 0)
            {
                Destroy(sixthObjectCraftingSlot.GetChild(0).gameObject);
            }
            if(seventhObjectCraftingSlot.childCount > 0)
            {
                Destroy(seventhObjectCraftingSlot.GetChild(0).gameObject);
            }
            if(eigthObjectCraftingSlot.childCount > 0)
            {
                Destroy(eigthObjectCraftingSlot.GetChild(0).gameObject);
            }
            if(ninthObjectCraftingSlot.childCount > 0)
            {
                Destroy(ninthObjectCraftingSlot.GetChild(0).gameObject);
            }
            if(tenthObjectCraftingSlot.childCount > 0)
            {
                Debug.Log("remove some health");
            }
            
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        isBeingDragged = true;
        Debug.Log("Being Dragged");
        transform.position = Input.mousePosition;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
