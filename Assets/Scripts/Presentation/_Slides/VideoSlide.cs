using UnityEngine;
using System.Collections;

namespace Presentation
{
	public class VideoSlide : AbstarctPresentationSlide
	{
		[SerializeField] private VideoClip _clip;

		public override void Show()
		{
			VideoPlayer.Instance.IsActive = true;
			VideoPlayer.Instance.Play(_clip, VideoPlayer.Instance.DummyShow);
		}

		public override void Hide()
		{
			VideoPlayer.Instance.IsActive = false;
		}
	}
}
