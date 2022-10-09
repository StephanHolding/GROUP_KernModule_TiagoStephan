using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static class Logger
{

	private static TextMeshProUGUI logText;
	private static TextMeshProUGUI recipeText;

	public static void Init()
	{
		GameObject logTextObject = GameObject.Find("Logger Text");
		GameObject recipeTextObject = GameObject.Find("Recipe Text");
		logText = logTextObject.GetComponent<TextMeshProUGUI>();
		recipeText = recipeTextObject.GetComponent<TextMeshProUGUI>();
	}

	public static void Log(string message)
	{
		logText.text = message;
	}
	public static void UpdateRecipes(string message) 
	{
		recipeText.text += message;
	}

}
