using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CraftingSlot : MonoBehaviour, IDropHandler
{
    public GameObject[] craftingSlots = {null, null, null, null};
    private bool isRecipe = false;
    public CraftingSystem craftingSystem;
    private Transform craftingResultParent;
    public GameObject resultIcon;
    private GameObject player;

    void Start()
    {
        player = PlayerReference.player;
        craftingSystem = GameObject.Find("GameManager").GetComponent<CraftingSystem>();
        craftingResultParent = player.transform.Find("PlayerUI/PlayerUICanvas/Inventory/ResultSlot/ItemButton");
        // player.transform.GetChild(5).GetChild(0).GetChild(1).GetChild(5).GetChild(0);
        GameObject firstCraftingSlot = player.transform.Find("PlayerUI/PlayerUICanvas/Inventory/InventoryCraftingSlot/ItemButton").gameObject;
        // player.transform.GetChild(5).GetChild(0).GetChild(1).GetChild(1).GetChild(0).gameObject;
        GameObject secondCraftingSlot = player.transform.Find("PlayerUI/PlayerUICanvas/Inventory/InventoryCraftingSlot (1)/ItemButton").gameObject;
        //player.transform.GetChild(5).GetChild(0).GetChild(1).GetChild(2).GetChild(0).gameObject;
        GameObject thirdCraftingSlot = player.transform.Find("PlayerUI/PlayerUICanvas/Inventory/InventoryCraftingSlot (2)/ItemButton").gameObject;
        // player.transform.GetChild(5).GetChild(0).GetChild(1).GetChild(3).GetChild(0).gameObject;
        GameObject fourthCraftingSlot = player.transform.Find("PlayerUI/PlayerUICanvas/Inventory/InventoryCraftingSlot (3)/ItemButton").gameObject;
        //player.transform.GetChild(5).GetChild(0).GetChild(1).GetChild(4).GetChild(0).gameObject;
        craftingSlots[0] = firstCraftingSlot;
        craftingSlots[1] = secondCraftingSlot;
        craftingSlots[2] = thirdCraftingSlot;
        craftingSlots[3] = fourthCraftingSlot;
        
    }
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        if(transform.childCount == 0)
        {
            GameObject droppped = eventData.pointerDrag;
            DraggableItem draggableItem = droppped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;

            StartCoroutine(DoSearchInventoryCraftingRecipes());
        }       
    }

    IEnumerator DoSearchInventoryCraftingRecipes()
    {
        yield return new WaitForEndOfFrame();
        isRecipe = craftingSystem.SearchInventoryCraftingRecipes();
        if(isRecipe)
        {
            Debug.Log("we have a recipe");
            if(craftingResultParent.childCount == 0)
            {
                Debug.Log("there is no old result");
                GameObject currentResult = Instantiate(craftingSystem.resultIcon);
                currentResult.transform.SetParent(craftingResultParent);
                currentResult.transform.localScale = new Vector3(0.53f, 0.53f);
            }
            // else
            // {
            //     Debug.Log("There is an old result");
            //     GameObject oldCraftingResult = craftingResultParent.GetChild(0).gameObject;
            //     Destroy(oldCraftingResult);
            //     GameObject currentResult = Instantiate(craftingSystem.resultIcon);
            //     currentResult.transform.SetParent(craftingResultParent);
            //     currentResult.transform.localScale = new Vector3(0.35f, 0.35f);
            // }
        }
        else
        {
            Debug.Log("No recipe");
            if(craftingResultParent.childCount > 0)
            {
                GameObject oldCraftingResult = craftingResultParent.GetChild(0).gameObject;
                Destroy(oldCraftingResult);
            }
        }
    }
}
