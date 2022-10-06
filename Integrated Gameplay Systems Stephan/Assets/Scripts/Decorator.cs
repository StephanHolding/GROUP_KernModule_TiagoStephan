using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Decorator : RecipeItem
{
    protected RecipeItem recipeItem;
    // Constructor
    public Decorator(RecipeItem _recipeItem)
    {
        recipeItem = _recipeItem;
    }
    public override void Display()
    {
        recipeItem.Display();
    }
}
