using UnityEngine;
using System.Collections;

namespace Presentation
{
	public class ItemMoveController : MonoBehaviour
	{
		public static event System.Action<float> OnRotateSlides;

		[SerializeField] private float _keyboardRotateSpeed = 2.0f;
		[SerializeField] private float _mouseRotateSpeed = 0.5f;
		private Vector3 _cachedMousePosition;

		private void Update()
		{
			if(!MouseInput())
			{
				KeyboardInput();
			}
		}

		private bool MouseInput()
		{
			if(Input.GetMouseButtonDown(1))
			{
				_cachedMousePosition = Input.mousePosition;
			}
			if(Input.GetMouseButton(1))
			{
				RotateItem(- (Input.mousePosition.x - _cachedMousePosition.x) * _mouseRotateSpeed);
				_cachedMousePosition = Input.mousePosition;
				return true;
			}
			return false;
		}

		private void KeyboardInput()
		{
			if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			{
				RotateItem(_keyboardRotateSpeed);
			}
			if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			{
				RotateItem(- _keyboardRotateSpeed);
			}
		}

		private void RotateItem(float angleY)
		{
			if(OnRotateSlides!=null)
			{
				OnRotateSlides(angleY);
			}
		}
	}
}
