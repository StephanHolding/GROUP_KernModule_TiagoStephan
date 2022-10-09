using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBook 
{
	public class Recipe 
	{
		public Recipe(string[] ingredients) 
		{
			
		}
	}
	Dictionary<string, Decorator> allIngredients = new Dictionary<string, Decorator>();

	//add list with all possible recipes
	List<Recipe> allRecipes = new List<Recipe>();

	//add list with all discovered recipes


	public RecipeBook(Recipe[] recipes)
	{
		FillBook();
		//retrieve discovered recipe list from Serialization Manager
		//List = SerializationManager.Get 
	}

	private void FillBook()
	{
		GenericDecorator apple = new GenericDecorator("Apple");
		GenericDecorator berry = new GenericDecorator("Berry");
		GenericDecorator water = new GenericDecorator("Water");
		CombustableDecorator heartOfAVirgin = new CombustableDecorator("Heart of a virgin");
		CombustableDecorator gunPowder = new CombustableDecorator("Gunpowder");

		allIngredients.Add("Apple", apple);
		allIngredients.Add("Berry", berry);
		allIngredients.Add("Water", water);
		allIngredients.Add("Heart of a virgin", heartOfAVirgin);
		allIngredients.Add("Gunpowder", gunPowder);
	}

	public bool IsRecipe(/* List with all the recipe items currently in the cauldron*/)
	{
		return true;
	}

}
