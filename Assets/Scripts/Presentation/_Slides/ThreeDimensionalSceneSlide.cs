﻿using UnityEngine;
using System.Collections;

namespace Presentation
{
	public class ThreeDimensionalSceneSlide : AbstarctPresentationSlide
	{
		[SerializeField] private Transform _scene;

		public override void Show()
		{
			_scene.localRotation = Quaternion.Euler(Vector3.zero);
			_scene.gameObject.SetActive(true);
			ItemMoveController.OnRotateSlides += RotateScene;
			//LeanTween.scale(_scene, Vector3.one, 0.1f);
		}

		public override void Hide()
		{
			_scene.gameObject.SetActive(false);
			ItemMoveController.OnRotateSlides -= RotateScene;
			//LeanTween.scale(_scene, Vector3.zero, 0.1f)
			//	.setOnComplete( () => _scene.SetActive(false) );
		}

		private void RotateScene(float angleY)
		{
			_scene.Rotate(new Vector3(0.0f, angleY, 0.0f));
		}
	}
}
