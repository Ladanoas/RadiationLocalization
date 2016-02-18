using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;

public class AppInit : SingletonMonoBehaviour<AppInit>
{
	protected override void OnCreate()
	{
		Application.targetFrameRate = 60;
		Resolution resolution = Screen.resolutions[Screen.resolutions.Length - 1];
		Screen.SetResolution(resolution.width, resolution.height, true);
	}
}
