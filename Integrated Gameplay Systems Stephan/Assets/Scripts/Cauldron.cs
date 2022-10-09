using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cauldron : Base
{

	private RecipeBook recipeBook;
	private Queue<Ingredient> currentIngredients = new Queue<Ingredient>();
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
		currentIngredients.Enqueue(recipeBook.GetIngredient(ingredientName));

		if (recipeBook.IsRecipe(currentIngredients.ToList(), out string potionName))
		{
			Logger.Log("Wajo we hebben " + potionName + " gemaakt");
			currentIngredients.Clear();
		}
		else
		{
			if (recipeBook.ShouldFail(currentIngredients.Count))
			{
				Logger.Log("Ah kanker");
			}
		}
	}

	public void RemoveLastDecorator()
	{
		currentIngredients.Dequeue();
	}

}
