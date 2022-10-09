using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cauldron : Base
{

	private RecipeBook recipeBook;
	private List<Ingredient> currentIngredients = new List<Ingredient>();
	private const string CURRENT_INGREDIENTS_KEY = "curr_ing_key";

	public Cauldron()
	{
		recipeBook = new RecipeBook();
	}

	public override void Awake()
	{

		//if (SerializationManager.Has(CURRENT_INGREDIENTS_KEY))
		//	currentIngredients = SerializationManager.Get<Stack<Ingredient>>(CURRENT_INGREDIENTS_KEY);
		//else
		//	currentIngredients = new Stack<Ingredient>();

		//foreach(Ingredient ingredient in currentIngredients)
		//{
		//	Debug.Log(ingredient.IngredientName);
		//}

		//SerializationManager.Set(CURRENT_INGREDIENTS_KEY, currentIngredients);
		recipeBook.Init();
	}

	public void AddDecorator(string ingredientName)
	{
		currentIngredients.Add(recipeBook.GetIngredient(ingredientName));

		Logger.Log("Added " + ingredientName);

		if (recipeBook.IsRecipe(currentIngredients, out string potionName))
		{
			Logger.Log("Created " + potionName);
			currentIngredients.Clear();
		}
		else
		{
			if (recipeBook.ShouldFail(currentIngredients.Count))
			{
				Logger.Log(recipeBook.GetFailEffect(currentIngredients));
			}
		}
	}

	public void RemoveLastDecorator()
	{
		currentIngredients.RemoveAt(currentIngredients.Count - 1);
		Logger.Log("Removed last ingredient");
	}

	public void ClearCurrentIngredients()
	{
		currentIngredients.Clear();
	}

}
