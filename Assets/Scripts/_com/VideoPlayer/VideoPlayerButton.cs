using UnityEngine;
using System.Collections;

public class VideoPlayerButton : AbstractButton
{
	private enum ButtonType { play, stop, pause }

	[SerializeField] private ButtonType _buttonType;

	protected override void ButtonClick()
	{
		switch(_buttonType)
		{
		case ButtonType.play:
			VideoPlayer.Instance.Play();
			break;
		case ButtonType.pause:
			VideoPlayer.Instance.Pause();
			break;
		case ButtonType.stop:
			VideoPlayer.Instance.Stop();
			break;
		}
	}
}
