using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static class Logger
{

	private static TextMeshProUGUI uiText;

	public static void Init()
	{
		GameObject textObject = GameObject.Find("Logger Text");
		uiText = textObject.GetComponent<TextMeshProUGUI>();
	}

	public static void Log(string message)
	{
		uiText.text = message;
	}

}
