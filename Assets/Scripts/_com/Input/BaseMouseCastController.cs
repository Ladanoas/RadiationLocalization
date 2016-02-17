using UnityEngine;
using System.Collections;

public class BaseMouseCastController : MonoBehaviour 
{
	[SerializeField] private Camera _camera;
	public bool IsActive = false;
	
	private void Update()
	{
		if(IsActive)
		{
			OnUpdate();
		}
	}

	protected virtual void OnUpdate() { }
	
	protected BaseSceneModel GetFocusedModel()
	{
		Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit))
		{
			return hit.collider.gameObject.GetComponent<BaseSceneModel>();
		}
		return null;
	}
}
