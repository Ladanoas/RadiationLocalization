using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Presentation
{
	public class PresentationContoller : AbstactSceneController<PresentationContoller>
	{
		public static event System.Action<int> OnSlideActive;

		[SerializeField] private PresentationData _data;
		private List<SlideData> _slides
		{
			get { return _data.Slides; }
		}
		public int SlidesCount
		{
			get { return _slides.Count; }
		}
		[SerializeField] private int _currentSlideId = -1;
		public int CurrentSlideId
		{
			get { return _currentSlideId; }
			set { _currentSlideId = Mathf.Clamp(value, 0, SlidesCount - 1); }
		}
		[SerializeField] private SlideData _currentSlide;

		private void Start()
		{
			StartCoroutine(ShowSlide(0));
		}

		public void GoForward()
		{
			StartCoroutine(ShowSlide(++CurrentSlideId));
		}

		public void GoBack()
		{
			StartCoroutine(ShowSlide(--CurrentSlideId));
		}

		private IEnumerator ShowSlide(int slideId)
		{
			if(_currentSlide.Slide!=null)
			{
				_currentSlide.Slide.Hide();
				yield return new WaitForSeconds(0.15f);
			}
			_currentSlideId = slideId;
			_currentSlide = _slides[_currentSlideId];
			_currentSlide.Slide.Show();
			if(OnSlideActive!=null)
			{
				OnSlideActive(_currentSlideId);
			}
		}
	}
}
