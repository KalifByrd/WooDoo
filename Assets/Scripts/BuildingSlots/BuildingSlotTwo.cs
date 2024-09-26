using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingSlotTwo : MonoBehaviour, IDropHandler
{
    
    public BuildingsUIHandler buildingsUIHandler;
    public GameManager gameManager;
    public string secondSlot;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        buildingsUIHandler = gameManager.buildingUICanvasActivater.GetComponent<BuildingsUIHandler>();
        secondSlot = buildingsUIHandler.secondSlot;
        
        if(transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;
            if(dropped.tag == secondSlot)
            {
                Destroy(dropped);
                buildingsUIHandler.secondSlotCount --;
                buildingsUIHandler.secondCountText.text = buildingsUIHandler.secondSlotCount.ToString();
                if(buildingsUIHandler.secondSlotCount == 0)
                {
                    buildingsUIHandler.isSecondSlotActive = false;
                    buildingsUIHandler.CheckForZeroCount();
                }
            }
        }       
    }

}

