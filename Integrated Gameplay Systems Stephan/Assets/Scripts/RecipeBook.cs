using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBook 
{
	public class Recipe 
	{
		public string potionName;
		public string[] ingredients;

		public Recipe(string potionName, params string[] ingredients)
		{
			this.ingredients = ingredients;
			this.potionName = potionName;
		}
	}

	private Dictionary<string, Ingredient> allIngredients = new Dictionary<string, Ingredient>();

	private Recipe[] allRecipes;
	private List<Recipe> discoveredRecipes = new List<Recipe>();
	private const string DISCOVERED_RECIPE_KEY = "disc_res_key";
	private const int MAX_INGREDIENT_COUNT = 4;

	public RecipeBook()
	{
		FillIngredientsDictionary();
		FillRecipesArray();
	}

	public void Init()
	{
		//if (SerializationManager.Has(DISCOVERED_RECIPE_KEY))
		//	discoveredRecipes = SerializationManager.Get<List<Recipe>>(DISCOVERED_RECIPE_KEY);
		//else
		//	discoveredRecipes = new List<Recipe>();


		//SerializationManager.Set(DISCOVERED_RECIPE_KEY, discoveredRecipes);
	}

	private void FillIngredientsDictionary()
	{
		allIngredients = new Dictionary<string, Ingredient>()
		{
			{"Stir", new GenericIngredient("Stir") },
			{"Heat", new GenericIngredient("Heat") },
			{"Apple", new GenericIngredient("Apple") },
			{"Berry", new GenericIngredient("Berry") },
			{"Water", new GenericIngredient("Water") },
			{"Rum", new GenericIngredient("Rum") },
			{"Rose Petal", new GenericIngredient("Rose Petal")},
			{"Leaf of the Elder Tree", new GenericIngredient("Leaf of the Elder Tree") },
			{"Gunpowder", new CombustableIngrdient("Gunpowder") },
			{"Heart of a Virgin", new GenericIngredient("Heart of a Virgin") },
		};
	}

	private void FillRecipesArray()
	{
		allRecipes = new Recipe[]
		{
			new Recipe("Appelsap", "Apple", "Water"),
			new Recipe("Healing potion", "Water", "Berry", "Leaf of the Elder Tree"),
			new Recipe("Poison", "Rum", "Rum", "Rum", "Rum"),
			new Recipe("Explosive Poison", "Rum", "Rum", "Rum", "Gunpowder"),
			new Recipe("Love potion", "Water", "Rose Petal", "Heart of a Virgin", "Stir"),
			new Recipe("Water Vapor", "Water", "Heat")
		};
	}

	public bool IsRecipe(List<Ingredient> currentIngredients, out string potionName)
	{
		for (int i = 0; i < allRecipes.Length; i++)
		{
			if (currentIngredients.Count == allRecipes[i].ingredients.Length)
			{
				bool found = true;

				for (int j = 0; j < currentIngredients.Count; j++)
				{
					if (currentIngredients[j].IngredientName != allRecipes[i].ingredients[j])
					{
						found = false;
					}
				}

				if (found)
				{
					potionName = allRecipes[i].potionName;
					return true;
				}
			}
		}

		potionName = "";
		return false;
	}

	public bool ShouldFail(int ingredientCount)
	{
		return ingredientCount >= MAX_INGREDIENT_COUNT;
	}

	public string GetFailEffect(List<Ingredient> ingredients)
	{
		for (int i = 0; i < ingredients.Count; i++)
		{
			if (ingredients[i].GetType() == typeof(CombustableIngrdient))
			{
				return "Kaboom";
			}
		}

		return "Potion creation failed.";
	}

	public Ingredient GetIngredient(string ingredientName)
	{
		return allIngredients[ingredientName];
	}
}
