using UnityEngine;
using System.Collections;

namespace Presentation
{
	public class ThreeDimensionalSceneSlide : AbstarctPresentationSlide
	{
		[SerializeField] private Transform _scene;
		[SerializeField] private bool _isRotated = true;

		public override void Show()
		{
			_scene.localRotation = Quaternion.Euler(Vector3.zero);
			_scene.gameObject.SetActive(true);
			ItemMoveController.OnRotateSlides += RotateScene;
		}

		public override void Hide()
		{
			_scene.gameObject.SetActive(false);
			ItemMoveController.OnRotateSlides -= RotateScene;
		}

		private void RotateScene(float angleY)
		{
			if(_isRotated)
			{
				_scene.Rotate(new Vector3(0.0f, angleY, 0.0f));
			}
		}
	}
}
