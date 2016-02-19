using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SphereGizmos : MonoBehaviour
{
	#if UNITY_EDITOR
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(transform.position, 0.005f);
	}
	#endif
}
