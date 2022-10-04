using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#region Commands

public abstract class Command
{
	public abstract void Exectute();
	public abstract void Undo();
}

public class Command_AddIngredient : Command
{
	public override void Exectute()
	{
		//add ingredient to cauldron
	}

	public override void Undo()
	{
		throw new NotImplementedException();
	}
}

public class Command_Stir : Command
{
	public override void Exectute()
	{
		//stir the cauldron
	}

	public override void Undo()
	{
		throw new NotImplementedException();
	}
}

public class Command_Heat : Command
{
	public override void Exectute()
	{
		//heat the cauldron up
	}

	public override void Undo()
	{
		throw new NotImplementedException();
	}
}

#endregion

public static class CommandManager
{

	private static Stack<Command> executedCommands = new Stack<Command>();
	private static Dictionary<Type, Command> availableCommands;

	static CommandManager()
	{
		GameObject.FindGameObjectWithTag("Tag").

		availableCommands = new Dictionary<Type, Command>
		{
			{ typeof(Command_AddIngredient), new Command_AddIngredient() },
			{ typeof(Command_Heat), new Command_Heat() },
			{ typeof(Command_Stir), new Command_Stir() },
		};
	}

	public static void ExecuteCommand<T>() where T : Command
	{
		Command toExecute = availableCommands[typeof(T)];
		toExecute.Exectute();
		executedCommands.Push(toExecute);
	}

	public static void UndoLastCommand()
	{
		Command toUndo = executedCommands.Pop();
		toUndo.Undo();
	}
}
