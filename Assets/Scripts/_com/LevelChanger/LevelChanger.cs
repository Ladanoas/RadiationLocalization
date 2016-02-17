using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using LevelsData;

public class LevelChanger : SingletonMonoBehaviour<LevelChanger>
{
	public static event Action<LevelId> OnLevelLoaded;

	private static bool IsLoadingStarted = false;

	public void StartLoadLevel(LevelId level)
	{
		if(!IsLoadingStarted)
		{
			IsLoadingStarted = true;
			LoadLevel(level);
		}
	}

	private void LoadLevel(LevelId level)
	{
		Application.LoadLevel(LevelsDictionary.GetLevelDataById(level).LevelName);
	}

	private void OnLevelWasLoaded(int levelId)
	{
		IsLoadingStarted = false;
		if(OnLevelLoaded!=null)
		{
			OnLevelLoaded(LevelsDictionary.CurrentLevel);
		}
	}
}
