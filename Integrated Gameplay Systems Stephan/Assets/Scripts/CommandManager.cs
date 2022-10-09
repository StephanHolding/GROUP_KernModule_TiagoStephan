using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#region Commands

public abstract class Command
{
	public Command(Cauldron _cauldron)
	{
		cauldronInstance = _cauldron;
	}

	protected Cauldron cauldronInstance;

	public abstract void Exectute(params object[] args);
	public abstract void Undo();
}

public class Command_AddIngredient : Command
{
	public Command_AddIngredient(Cauldron _cauldron) : base(_cauldron)
	{

	}

	public override void Exectute(params object[] args)
	{
		cauldronInstance.AddDecorator(args[0] as string);
	}

	public override void Undo()
	{
		throw new NotImplementedException();
	}
}

public class Command_Test : Command
{
	public Command_Test(Cauldron _cauldron) : base(_cauldron)
	{

	}

	public override void Exectute(params object[] args)
	{
		Debug.Log("works!");
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
	private static Cauldron cauldron;

	public static void Init(Cauldron _cauldron)
	{
		cauldron = _cauldron;

		availableCommands = new Dictionary<Type, Command>
		{
			{ typeof(Command_AddIngredient), new Command_AddIngredient(cauldron) },
			{ typeof(Command_Test), new Command_Test(cauldron) },
		};
	}

	public static void ExecuteCommand<T>(params object[] args) where T : Command
	{
		ExecuteCommand(typeof(T), args);
	}

	public static void ExecuteCommand(Type _type, params object[] args)
	{
		Command toExecute = availableCommands[_type];
		toExecute.Exectute(args);
		executedCommands.Push(toExecute);
	}

	public static void UndoLastCommand()
	{
		Command toUndo = executedCommands.Pop();
		toUndo.Undo();
	}
}
