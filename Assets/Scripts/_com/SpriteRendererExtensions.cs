using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public static class SpriteRendererExtensions
{
	#region alpha
	public static void SetAlpha(this SpriteRenderer spriteRenderer, float alpha, float time = 0.0f, System.Action completeCallback = null)
	{
		if(time>0.0f)
		{
			LeanTween.value(spriteRenderer.gameObject, spriteRenderer.color.a, alpha, time)
				.setEase(LeanTweenType.linear)
				.setOnUpdate( (float value) => { spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, value); } )
				.setOnComplete( () => { if(completeCallback!=null) completeCallback(); } );
		}
		else
		{
			spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, alpha);
			if(completeCallback!=null)
			{
				completeCallback();
			}
		}
	}

	public static void SetAlpha(this Text text, float alpha, float time = 0.0f, System.Action completeCallback = null)
	{
		if(time>0.0f)
		{
			LeanTween.value(text.gameObject, text.color.a, alpha, time)
				.setEase(LeanTweenType.linear)
				.setOnUpdate( (float value) => { text.color = new Color(text.color.r, text.color.g, text.color.b, value); } )
				.setOnComplete( () => { if(completeCallback!=null) completeCallback(); } );
		}
		else
		{
			text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
			if(completeCallback!=null)
			{
				completeCallback();
			}
		}
	}
	#endregion
}
