using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingSlotOne : MonoBehaviour, IDropHandler
{
    
    public BuildingsUIHandler buildingsUIHandler;
    public GameManager gameManager;
    public string firstSlot;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        
    }
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        buildingsUIHandler = gameManager.buildingUICanvasActivater.GetComponent<BuildingsUIHandler>();
        firstSlot = buildingsUIHandler.firstSlot;
        if(transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;
            if(dropped.tag == firstSlot)
            {
                Destroy(dropped);
                buildingsUIHandler.firstSlotCount --;
                buildingsUIHandler.firstCountText.text = buildingsUIHandler.firstSlotCount.ToString();
                if(buildingsUIHandler.firstSlotCount == 0)
                {
                    buildingsUIHandler.isFirstSlotActive = false;
                    buildingsUIHandler.CheckForZeroCount();
                }
            
            }
        }       
    }

}

