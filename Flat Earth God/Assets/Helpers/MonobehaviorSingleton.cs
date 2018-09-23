using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{

	private static T instance;

	public static T Instance
	{
		get { return instance; }
	}

	protected virtual void Awake()
	{
		if (instance == null)
		{
			Debug.Log("Instance of "+this.GetType()+" is null, Trying to find object in scene");
			instance = FindObjectOfType<T>();
			if(instance==null)
			{
				Debug.LogError("Instance of " + this.GetType() + " not foundin Scene");
			}
		}
		else
		{
			Debug.LogWarning("Duplicate instance of " + this.GetType() + " Destroying instance");
			Destroy(this);
		}
	}
}

public class PersistantSingleton<T> : Singleton<T> where T : MonoBehaviour
{
	protected override void Awake()
	{
		base.Awake();
		DontDestroyOnLoad(this);
	}
}
