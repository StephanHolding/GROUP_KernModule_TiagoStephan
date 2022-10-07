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

	public abstract void Exectute();
	public abstract void Undo();
}

public class Command_AddIngredient : Command
{
	public Command_AddIngredient(Cauldron _cauldron) : base(_cauldron)
	{

	}

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
	public Command_Stir(Cauldron _cauldron) : base(_cauldron)
	{

	}

	public override void Exectute()
	{
		//stir the cauldron
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

	public override void Exectute()
	{
		Debug.Log("works!");
	}

	public override void Undo()
	{
		throw new NotImplementedException();
	}
}

public class Command_Heat : Command
{
	public Command_Heat(Cauldron _cauldron) : base(_cauldron)
	{

	}

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
	private static Cauldron cauldron;

	public static void Init(Cauldron _cauldron)
	{
		cauldron = _cauldron;

		availableCommands = new Dictionary<Type, Command>
		{
			{ typeof(Command_AddIngredient), new Command_AddIngredient(cauldron) },
			{ typeof(Command_Heat), new Command_Heat(cauldron) },
			{ typeof(Command_Stir), new Command_Stir(cauldron) },
			{ typeof(Command_Test), new Command_Test(cauldron) },
		};
	}

	public static void ExecuteCommand<T>() where T : Command
	{
		ExecuteCommand(typeof(T));
	}

	public static void ExecuteCommand(Type _type)
	{
		Command toExecute = availableCommands[_type];
		toExecute.Exectute();
		executedCommands.Push(toExecute);
	}

	public static void UndoLastCommand()
	{
		Command toUndo = executedCommands.Pop();
		toUndo.Undo();
	}
}
