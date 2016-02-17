using UnityEngine;
using System.Collections;

public class AppCloseButton : AbstractButton
{
	protected override void ButtonClick()
	{
		Debug.Log("quit");
		Application.Quit();
	}
}
