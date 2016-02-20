using UnityEngine;
using System.Collections;

public class AppCloseButton : AbstractButton
{
	protected override void ButtonClick()
	{
		Application.Quit();
	}
}
