using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace LevelsData
{
	public class LevelsDictionary
	{
		private static List<LevelData> _levels = new List<LevelData>()
		{
			{ new LevelData(LevelId.Presentation, "Presentation") }
		};

		public static LevelId CurrentLevel
		{
			get { return GetLevelIdByName(Application.loadedLevelName); }
		}

		public static LevelData GetLevelDataById(LevelId level)
		{
			LevelData result = _levels.FirstOrDefault( a => a.Level==level );
			if(result!=null)
			{
				return result;
			}
			else
			{
				Debug.LogException(new System.Exception("Not found level data for LevelId = " + level.ToString()));
				return null;
			}
		}
		
		public static LevelId GetLevelIdByName(string levelName)
		{
			LevelData result = _levels.FirstOrDefault( a => a.LevelName==levelName );
			if(result!=null)
			{
				return result.Level;
			}
			else
			{
				Debug.LogException(new System.Exception("Not found level with name = " + levelName.ToString()));
				return (LevelId)0;
			}
		}
	}
}