using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleToolRecipe : MonoBehaviour, ICraftingRecipe
{
    public GameObject[] simpleTool;
    public GameObject icon;

    public SimpleToolRecipe simpleCraftingRecipe => throw new System.NotImplementedException();

    public GameObject Icon(GameObject icon)
    {
        return icon;
    }

}
