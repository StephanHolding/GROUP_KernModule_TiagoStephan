using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : Base
{
	Stack<RecipeItem> recipeItems = new Stack<RecipeItem>();
	public void AddDecorator(RecipeItem recipeItem)
	{
		//add ingredient decorator to decorator list
		//ask recipe book if current decorator list equals a potion or not
	}

	public void RemoveDecorator(/* the decorator that should be removed*/)
	{
		//remove a decorator from the list.
	}

}
