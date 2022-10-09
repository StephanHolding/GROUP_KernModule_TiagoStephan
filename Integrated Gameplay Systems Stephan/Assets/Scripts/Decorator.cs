using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Decorator : RecipeItem
{
    // Constructor
    public Decorator(string _name)
    {
        name = _name;
    }
}
