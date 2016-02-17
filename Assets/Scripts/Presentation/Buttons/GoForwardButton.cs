using UnityEngine;
using System.Collections;

namespace Presentation
{
	public class GoForwardButton : MovePresentationButton
	{
		protected override void ButtonClick()
		{
			PresentationContoller.Instance.GoForward();
		}

		protected override void RefreshState(int slideId)
		{
			_button.interactable = (slideId!=(PresentationContoller.Instance.SlidesCount - 1));
		}
	}
}
