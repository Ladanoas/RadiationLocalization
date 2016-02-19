using UnityEngine;
using System.Collections;

public abstract class AbstractButton : MonoBehaviour
{
	[SerializeField] private bool IsShowed = true;

	private void Awake()
	{
		transform.localScale = (IsShowed) ? transform.localScale : Vector3.zero;
	}	

	public void MouseClick()
	{
		ButtonClick();
	}
	
	protected virtual void ButtonClick() { }

	public void Show(float time = 0.0f)
	{
		if(IsShowed)
			return;

		IsShowed = true;
		if(time>0.0f)
		{
			LeanTween.scale(gameObject, Vector3.one, time);
		}
		else
		{
			transform.localScale = Vector3.one;
		}

	}

	public void Hide(float time = 0.0f)
	{
		if(!IsShowed)
			return;

		IsShowed = false;
		if(time>0.0f)
		{
			LeanTween.scale(gameObject, Vector3.zero, time);
		}
		else
		{
			transform.localScale = Vector3.zero;
		}
	}
}
