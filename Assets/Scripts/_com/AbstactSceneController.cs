using UnityEngine;
using System.Collections;

public abstract class AbstactSceneController<T> : MonoBehaviour where T : MonoBehaviour
{
	public static T Instance;
	
	private void Awake()
	{
		Instance = this as T;
		
		OnAwake();
	}
	
	protected virtual void OnAwake() { }
}
