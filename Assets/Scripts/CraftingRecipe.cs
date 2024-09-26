using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICraftingRecipe
{

    SimpleToolRecipe simpleCraftingRecipe {get;}
    GameObject Icon(GameObject icon);
}
