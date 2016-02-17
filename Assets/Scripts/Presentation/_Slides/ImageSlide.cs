using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Presentation
{
	public class ImageSlide : AbstarctPresentationSlide
	{
		[SerializeField] private float _rate = 4.0f;
		[SerializeField] private SpriteRenderer _spriteRenderer;
		[SerializeField] private List<Sprite> _sprites = new List<Sprite>();
		private bool _isShowed = false;
		private int _currentSpriteId = 0;
		private int CurrentSpriteId
		{
			get { return _currentSpriteId; }
			set { _currentSpriteId = (value>=_sprites.Count) ? 0 : value; }
		}

		public override void Show()
		{
			_isShowed = false;
			_currentSpriteId = 0;
			StartCoroutine(ShowNextSprite());
		}

		private IEnumerator ShowNextSprite()
		{
			if(!_isShowed)
			{
				_isShowed = true;
			}
			else
			{
				_spriteRenderer.SetAlpha(0.0f, 0.1f);
				yield return new WaitForSeconds(0.15f);
			}

			_spriteRenderer.sprite = _sprites[CurrentSpriteId++];
			_spriteRenderer.SetAlpha(1.0f, 0.1f);

			if(_sprites.Count>1)
			{
				yield return new WaitForSeconds(_rate);
				StartCoroutine(ShowNextSprite());
			}
		}

		public override void Hide()
		{
			StopAllCoroutines();
			_spriteRenderer.SetAlpha(0.0f, 0.1f);
		}
	}
}
