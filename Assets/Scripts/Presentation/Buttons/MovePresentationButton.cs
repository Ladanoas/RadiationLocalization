using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Presentation
{
	public class MovePresentationButton : AbstractButton
	{
		[SerializeField] protected Button _button;

		private void OnEnable()
		{
			PresentationContoller.OnSlideActive += RefreshState;
		}
		
		private void OnDisable()
		{
			PresentationContoller.OnSlideActive += RefreshState;
		}

		protected virtual void RefreshState(int slideId) { }
	}
}
