using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCraftingSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] simpleLadderRecipe;
    [SerializeField] private GameObject[] simpleShearsRecipe;
    [SerializeField] private GameObject[] simpleBedRecipe;

    [SerializeField] private SimpleLadderRecipe simpleLadderRecipeScript;
    [SerializeField] private SimpleShearsRecipe simpleShearsRecipeScript;
    [SerializeField] private SimpleBedRecipe simpleBedRecipeScript;
    //private GameObject[] craftingSlots;
    public ObjectCraftingSlot objectCraftingSlot;
    public GameObject resultIcon;
    [SerializeField] private List<GameObject[]> objectCraftingRecipes = new List<GameObject[]>();
    [SerializeField] private List<MonoBehaviour> ourRecipes = new List<MonoBehaviour>();
    [SerializeField] private GameObject currentCraftingSlotIcon;
    void Start()
    {
        simpleLadderRecipeScript = gameObject.GetComponent<SimpleLadderRecipe>();
        simpleLadderRecipe = simpleLadderRecipeScript.simpleLadder;

        simpleShearsRecipeScript = gameObject.GetComponent<SimpleShearsRecipe>();
        simpleShearsRecipe = simpleShearsRecipeScript.simpleShears;

        simpleBedRecipeScript = gameObject.GetComponent<SimpleBedRecipe>();
        simpleBedRecipe = simpleBedRecipeScript.simpleBed;


        objectCraftingRecipes.Add(simpleLadderRecipe);
        ourRecipes.Add(simpleLadderRecipeScript);

        objectCraftingRecipes.Add(simpleShearsRecipe);
        ourRecipes.Add(simpleShearsRecipeScript);

        objectCraftingRecipes.Add(simpleBedRecipe);
        ourRecipes.Add(simpleBedRecipeScript);


        //craftingSlots = craftingSlot.craftingSlots;
    }
    public bool SearchInventoryCraftingRecipes()
    {
        
        for(int i = 0; i < objectCraftingRecipes.Count; i++)
        {
            Debug.Log("We are on itteration " + i + " of our crafting recapies");
            GameObject[] currentRecipe = objectCraftingRecipes[i];
            Debug.Log("The Recipe we are looking at is: " + currentRecipe);

            var currentRecipeScript = ourRecipes[i];
            Debug.Log("And we are looking at our " + currentRecipeScript + " recipe script");
            for(int j = 0; j < currentRecipe.Length; j++)
            {
                Debug.Log("We are on itteration " + j + " of our recipie array");
                GameObject currentRecipeIcon = currentRecipe[j];
                Debug.Log("the " + j +"th item in our array is: " + currentRecipeIcon);
                Debug.Log("the crafting slot has " + objectCraftingSlot.craftingSlots[j].transform.childCount + " children");
                if(objectCraftingSlot.craftingSlots[j].transform.childCount > 0)
                {
                    
                    currentCraftingSlotIcon = objectCraftingSlot.craftingSlots[j].transform.GetChild(0).gameObject;
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
                            resultIcon = gameObject.transform.GetChild(2).GetChild(i).GetChild(0).gameObject;
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
                        Debug.Log(j +" and " + currentRecipe.Length);
                        if(j == currentRecipe.Length -1)
                        {
                            Debug.Log("ITs true");
                            resultIcon = gameObject.transform.GetChild(2).GetChild(i).GetChild(0).gameObject;
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