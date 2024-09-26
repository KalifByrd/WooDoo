using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem : MonoBehaviour 
{
    [SerializeField] private GameObject[] simpleToolRecipe;
    [SerializeField] private GameObject[] simpleCraftingTableRecipe;

    [SerializeField] private SimpleToolRecipe simpleToolRecipeScript;
    [SerializeField] private SimpleCraftingTableRecipe simpleCraftingTableRecipeScript;
    //private GameObject[] craftingSlots;
    public CraftingSlot craftingSlot;
    public GameObject resultIcon;
    [SerializeField] private List<GameObject[]> inventoryCraftingRecipes = new List<GameObject[]>();
    [SerializeField] private List<MonoBehaviour> ourRecipes = new List<MonoBehaviour>();
    [SerializeField] private GameObject currentCraftingSlotIcon;
    void Start()
    {
        // just for now comment out
        // un comment later
        // simpleToolRecipeScript = gameObject.GetComponent<SimpleToolRecipe>();
        // simpleToolRecipe = simpleToolRecipeScript.simpleTool;

        // simpleCraftingTableRecipeScript = gameObject.GetComponent<SimpleCraftingTableRecipe>();
        // simpleCraftingTableRecipe = simpleCraftingTableRecipeScript.simpleCraftingTable;

        // inventoryCraftingRecipes.Add(simpleToolRecipe);
        // ourRecipes.Add(simpleToolRecipeScript);

        // inventoryCraftingRecipes.Add(simpleCraftingTableRecipe);
        // ourRecipes.Add(simpleCraftingTableRecipeScript);

        // craftingSlot = GameObject.Find("Player").transform.GetChild(5).GetChild(0).GetChild(1).GetChild(1).GetChild(0).gameObject.GetComponent<CraftingSlot>();

        //always been commented out
        //craftingSlots = craftingSlot.craftingSlots;
    }
    public bool SearchInventoryCraftingRecipes()
    {
        
        for(int i = 0; i < inventoryCraftingRecipes.Count; i++)
        {
            Debug.Log("We are on itteration " + i + " of our crafting recapies");
            GameObject[] currentRecipe = inventoryCraftingRecipes[i];
            Debug.Log("The Recipe we are looking at is: " + currentRecipe);

            var currentRecipeScript = ourRecipes[i];
            Debug.Log("And we are looking at our " + currentRecipeScript + " recipe script");
            for(int j = 0; j < currentRecipe.Length; j++)
            {
                Debug.Log("We are on itteration " + j + " of our recipie array");
                GameObject currentRecipeIcon = currentRecipe[j];
                Debug.Log("the " + j +"th item in our array is: " + currentRecipeIcon);
                Debug.Log("the crafting slot has " + craftingSlot.craftingSlots[j].transform.childCount + " children");
                if(craftingSlot.craftingSlots[j].transform.childCount > 0)
                {
                    
                    currentCraftingSlotIcon = craftingSlot.craftingSlots[j].transform.GetChild(0).gameObject;
                    Debug.Log("there is an item in our crafting slot: " + currentCraftingSlotIcon);
                }
                else
                {
                    Debug.Log("there is no item in our crafting slot");
                    currentCraftingSlotIcon = null;
                }
                Debug.Log("we are comparing " + currentRecipeIcon + " with " + currentCraftingSlotIcon);
                
                if(currentRecipeIcon == null || currentCraftingSlotIcon == null)
                {
                    if(currentRecipeIcon == currentCraftingSlotIcon)
                    {
                        Debug.Log(currentRecipeIcon + " and " + currentCraftingSlotIcon + " are the same!");
                        if(j == currentRecipe.Length -1)
                        {
                            Debug.Log("ITs true");
                            resultIcon = gameObject.transform.GetChild(1).GetChild(i).GetChild(0).gameObject;
                            return true;
                        }
                        

                    }
                    else
                    {
                        Debug.Log(currentRecipeIcon + " and " + currentCraftingSlotIcon + " DNOT Equal!");
                        break;
                    }
                }
                else
                {
                    if(currentRecipeIcon.tag == currentCraftingSlotIcon.tag)
                    {
                        Debug.Log(currentRecipeIcon + " and " + currentCraftingSlotIcon + " are the same!");
                        if(j == currentRecipe.Length -1)
                        {
                            Debug.Log("ITs true");
                            resultIcon = gameObject.transform.GetChild(1).GetChild(i).GetChild(0).gameObject;
                            return true;
                        }

                    }
                    else
                    {
                        Debug.Log(currentRecipeIcon + " and " + currentCraftingSlotIcon + " DNOT Equal!");
                        break;
                    }
                }
                
            }
        }
        //resultIcon = null;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
