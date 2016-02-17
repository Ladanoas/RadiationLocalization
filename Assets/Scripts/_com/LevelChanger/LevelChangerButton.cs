using UnityEngine;
using System.Collections;

public class LevelChangerButton : AbstractButton
{
	[SerializeField] protected LevelId _levelId;

	protected override void ButtonClick()
	{
		StartLoadLevel();
	}

	protected virtual void StartLoadLevel()
	{
		LevelChanger.Instance.StartLoadLevel(_levelId);
	}
}
