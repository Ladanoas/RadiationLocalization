using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Presentation
{
	public class PresentationContoller : AbstactSceneController<PresentationContoller>
	{
		public static event System.Action<int> OnSlideActive;

		[SerializeField] private Text _titleText;
		[SerializeField] private Text _descriptionText;
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
		private SlideData _currentSlide = null;
		private SerializationSlideData _currentSlideData = null;
		private int _descriptionTextCounter = 0;

		private void Start()
		{
			StartCoroutine(ShowSlide(0));
		}

		public void GoForward()
		{
			StopAllCoroutines();
			StartCoroutine(ShowSlide(++CurrentSlideId));
		}

		public void GoBack()
		{
			StopAllCoroutines();
			StartCoroutine(ShowSlide(--CurrentSlideId));
		}

		private IEnumerator ShowSlide(int slideId)
		{
			if(_currentSlide!=null)
			{
				_currentSlide.Slide.Hide();
				HideText();
				yield return new WaitForSeconds(0.15f);
			}
			_currentSlideId = slideId;
			_currentSlide = _slides[_currentSlideId];
			_currentSlideData = PresentationData.Instance.GetSerializationSlideData(_currentSlide.Id);
			_currentSlide.Slide.Show();
			ShowText();
			if(OnSlideActive!=null)
			{
				OnSlideActive(_currentSlideId);
			}
		}

		private void ShowText()
		{
			_titleText.text = _currentSlideData.SlideTitle;
			_titleText.SetAlpha(1.0f, 0.1f);

			_descriptionText.text = "";
			_descriptionText.SetAlpha(1.0f);
			_descriptionTextCounter = 0;
			StartCoroutine(ShowDescriptionText());
		}

		private IEnumerator ShowDescriptionText()
		{
			if(_descriptionTextCounter<_currentSlideData.SlideDescription.Length)
			{
				_descriptionText.text += _currentSlideData.SlideDescription[_descriptionTextCounter++];

				yield return new WaitForSeconds(0.03f);
				StartCoroutine(ShowDescriptionText());
			}
		}

		private void HideText()
		{
			_titleText.SetAlpha(0.0f, 0.1f);
			_descriptionText.SetAlpha(0.0f, 0.1f);
		}
	}
}
