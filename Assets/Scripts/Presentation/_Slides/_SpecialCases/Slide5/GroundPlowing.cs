using UnityEngine;
using System.Collections;

public class GroundPlowing : MonoBehaviour
{
	[SerializeField] private Transform _wp;
	[SerializeField] private int _thicknessX = 10;
	[SerializeField] private int _thicknessZ = 10;

	private void Update()
	{
		Cast();
	}

	private void Cast()
	{
		RaycastHit hit;
		if(Physics.Raycast(transform.position, Vector3.down, out hit, 100) && hit.collider!=null)
		{
			_wp.transform.position = hit.point;
			Ground.Instance.Powling(_wp.transform.localPosition, _thicknessX, _thicknessZ);
		}
	}

}
