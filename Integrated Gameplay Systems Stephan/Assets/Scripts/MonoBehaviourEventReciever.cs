using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoBehaviourEventReciever : MonoBehaviour
{

	public Base[] classes = new Base[]
	{
		new Cauldron()
	};


	public void UI_Event(string typeAsString)
	{
		Type type = Type.GetType(typeAsString);
		CommandManager.ExecuteCommand(type);
	}

	public void AddIngredientCommand(string ingredientName)
	{
		CommandManager.ExecuteCommand<Command_AddIngredient>(ingredientName);
	}

	public void UI_Event_Undo()
	{
		CommandManager.UndoLastCommand();
	}

	private void Awake()
	{
		CommandManager.Init(FindClassInstance<Cauldron>());

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
