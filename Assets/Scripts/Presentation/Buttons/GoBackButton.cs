using UnityEngine;
using System.Collections;

namespace Presentation
{
	public class GoBackButton : MovePresentationButton
	{
		protected override void ButtonClick()
		{
			PresentationContoller.Instance.GoBack();
		}

		protected override void RefreshState(int slideId)
		{
			_button.interactable = (slideId!=0);
		}
	}
}
