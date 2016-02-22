using UnityEngine;
using System.Collections;

namespace Presentation
{
	public class PresentationSlide5 : ThreeDimensionalSceneSlide
	{
		public override void Show()
		{
			base.Show();
			Ground.Instance.OnShow();
		}

		public override void Hide()
		{
			base.Hide();
			Ground.Instance.OnHide();
		}
	}
}
