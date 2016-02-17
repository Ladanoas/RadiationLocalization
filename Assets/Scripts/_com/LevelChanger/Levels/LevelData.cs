using UnityEngine;
using System.Collections;

namespace LevelsData
{
	public class LevelData
	{
		public LevelId Level;
		public string LevelName;		//название сцены
		
		public LevelData(LevelId level, string levelName)
		{
			Level = level;
			LevelName = levelName;
		}
	}
}