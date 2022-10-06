using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RecipeItem
{
    private int amount;
    public int Amount
    {
        get { return amount; }
        set { amount = value; }
    }
    public abstract void Display();
}

