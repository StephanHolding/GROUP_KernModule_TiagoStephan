using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonoBehaviourEventReciever : MonoBehaviour
{

	public Base[] classes = new Base[]
	{
		new Cauldron()
	};

	private CommandManager commandManagerInstance;


	public void UI_Event(string typeAsString)
	{
		Type type = Type.GetType(typeAsString);
		commandManagerInstance.ExecuteCommand(type);
	}

	public void AddIngredientCommand(string ingredientName)
	{
		commandManagerInstance.ExecuteCommand<Command_AddIngredient>(ingredientName);
	}

	public void UI_Event_Undo()
	{
		commandManagerInstance.UndoLastCommand();
	}

	public void QuitApplication()
	{
		Application.Quit();
	}

	public void Retry()
	{
		FindClassInstance<Cauldron>().ClearCurrentIngredients();
		Logger.Log("");
	}

	private void Awake()
	{
		Logger.Init();

		commandManagerInstance = new CommandManager(FindClassInstance<Cauldron>());

		foreach (Base cls in classes)
		{
			cls.Awake();
		}
	}

	private void Start()
	{
		foreach (Base cls in classes)
		{
			cls.Start();
		}
	}

	private void Update()
	{
		foreach (Base cls in classes)
		{
			cls.Update();
		}
	}

	private T FindClassInstance<T>() where T : Base
	{
		for (int i = 0; i < classes.Length; i++)
		{
			if (classes[i].GetType() == typeof(T))
			{
				return classes[i] as T;
			}
		}

		return null;
	}

}
