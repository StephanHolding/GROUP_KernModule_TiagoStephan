using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ingredient : Decorator
{
	// Constructor
	public Ingredient(string _name)
	{
		IngredientName = _name;
	}

	public string IngredientName { get; private set; }
}

