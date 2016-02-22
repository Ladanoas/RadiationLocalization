using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SphereGizmos : MonoBehaviour
{
	[SerializeField] private Color _gismoColor = Color.yellow;
	[SerializeField] private float _gismoScale = 0.005f;

	#if UNITY_EDITOR
	private void OnDrawGizmos()
	{
		Gizmos.color = _gismoColor;
		Gizmos.DrawSphere(transform.position, _gismoScale);
	}
	#endif
}
