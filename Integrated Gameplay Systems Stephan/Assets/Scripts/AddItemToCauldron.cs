using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemToCauldron : Decorator
{
    protected readonly List<string> addedItems = new List<string>();
    public AddItemToCauldron(RecipeItem _recipeItem) : base(_recipeItem)
    {

    }

    // Constructor
    public void AddItem(string name)
    {
        addedItems.Add(name);
        recipeItem.Amount++;
    }
    public void ReturnItem(string name)
    {
        addedItems.Remove(name);
        recipeItem.Amount--;
    }
    public override void Display()
    {
        base.Display();
        foreach (string item in addedItems)
        {
           Debug.Log("Amount of Items in the cauldron: " + item);
        }
    }
}
