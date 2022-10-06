using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public static class SerializationManager
{

	private static Dictionary<string, object> objectsToSave;

	private static string FullPath { get { return Path.Combine(path, fileName + extension); } }
	private static readonly string path = Application.persistentDataPath;
	private static readonly string fileName = "GameSave";
	private static readonly string extension = ".sav";

	static SerializationManager()
	{
		Application.quitting += Application_quitting;

		if (!FileIsPresent())
			objectsToSave = new Dictionary<string, object>();
		else
			objectsToSave = Load();
	}


	public static void Set(string _key, object _objectToSave)
	{
		if (!objectsToSave.ContainsKey(_key))
		{
			objectsToSave.Add(_key, _objectToSave);
		}
		else
		{
			objectsToSave[_key] = _objectToSave;
		}
	}

	public static T Get<T>(string _key)
	{
		if (objectsToSave.ContainsKey(_key))
		{
			return (T)objectsToSave[_key];
		}
		else
		{
			Debug.LogError("Object of type " + typeof(T) + " with key: " + _key + " was not found.");
			return default;
		}
	}

	public static void Save()
	{
		string JSON = JsonConvert.SerializeObject(objectsToSave, Formatting.Indented);
		File.WriteAllText(FullPath, JSON);
	}

	private static Dictionary<string, object> Load()
	{
		string JSON = File.ReadAllText(FullPath);
		return JsonConvert.DeserializeObject<Dictionary<string, object>>(JSON);
	}

	private static bool FileIsPresent()
	{
		return File.Exists(FullPath);
	}

	private static void Application_quitting()
	{
		Save();
	}
}