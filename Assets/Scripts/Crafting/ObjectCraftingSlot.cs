using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectCraftingSlot : MonoBehaviour, IDropHandler
{
 public GameObject[] craftingSlots = {null, null, null, null, null, null, null, null, null, null};
    private bool isRecipe = false;
    public ObjectCraftingSystem objectCraftingSystem;
    private Transform craftingResultParent;
    public GameObject resultIcon;

    void Start()
    {
        
        objectCraftingSystem = GameObject.Find("GameManager").GetComponent<ObjectCraftingSystem>();
        craftingResultParent = gameObject.transform.parent.parent.GetChild(10).GetChild(0);
        GameObject firstCraftingSlot = gameObject.transform.parent.parent.GetChild(0).GetChild(0).gameObject;
        GameObject secondCraftingSlot = gameObject.transform.parent.parent.GetChild(1).GetChild(0).gameObject;
        GameObject thirdCraftingSlot = gameObject.transform.parent.parent.GetChild(2).GetChild(0).gameObject;
        GameObject fourthCraftingSlot = gameObject.transform.parent.parent.GetChild(3).GetChild(0).gameObject;
        GameObject fifthCraftingSlot = gameObject.transform.parent.parent.GetChild(4).GetChild(0).gameObject;
        GameObject sixthCraftingSlot = gameObject.transform.parent.parent.GetChild(5).GetChild(0).gameObject;
        GameObject seventhCraftingSlot = gameObject.transform.parent.parent.GetChild(6).GetChild(0).gameObject;
        GameObject eightCraftingSlot = gameObject.transform.parent.parent.GetChild(7).GetChild(0).gameObject;
        GameObject ninthCraftingSlot = gameObject.transform.parent.parent.GetChild(8).GetChild(0).gameObject;
        GameObject tenthCraftingSlot = gameObject.transform.parent.parent.GetChild(9).GetChild(0).gameObject;

        craftingSlots[0] = firstCraftingSlot;
        craftingSlots[1] = secondCraftingSlot;
        craftingSlots[2] = thirdCraftingSlot;
        craftingSlots[3] = fourthCraftingSlot;
        craftingSlots[4] = fifthCraftingSlot;
        craftingSlots[5] = sixthCraftingSlot;
        craftingSlots[6] = seventhCraftingSlot;
        craftingSlots[7] = eightCraftingSlot;
        craftingSlots[8] = ninthCraftingSlot;
        craftingSlots[9] = tenthCraftingSlot;
        
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
        isRecipe = objectCraftingSystem.SearchInventoryCraftingRecipes();
        if(isRecipe)
        {
            Debug.Log("we have a recipe");
            if(craftingResultParent.childCount == 0)
            {
                Debug.Log("there is no old result");
                GameObject currentResult = Instantiate(objectCraftingSystem.resultIcon);
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
