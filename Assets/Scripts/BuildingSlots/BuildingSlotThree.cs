using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingSlotThree : MonoBehaviour, IDropHandler
{
    
    public BuildingsUIHandler buildingsUIHandler;
    public GameManager gameManager;
    public string thirdSlot;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        
    }
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        buildingsUIHandler = gameManager.buildingUICanvasActivater.GetComponent<BuildingsUIHandler>();
        thirdSlot = buildingsUIHandler.thirdSlot;
        if(transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;
            if(dropped.tag == thirdSlot)
            {
                Destroy(dropped);
                buildingsUIHandler.thirdSlotCount --;
                buildingsUIHandler.thirdCountText.text = buildingsUIHandler.thirdSlotCount.ToString();
                if(buildingsUIHandler.thirdSlotCount == 0)
                {
                    buildingsUIHandler.isThirdSlotActive = false;
                    buildingsUIHandler.CheckForZeroCount();
                }
            }
        }       
    }

}

