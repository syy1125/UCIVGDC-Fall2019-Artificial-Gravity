using UnityEngine;

public class FlashlightControl : MonoBehaviour
{
	private Camera _mainCamera;
	public float FollowSpeed;
	private Vector3 _offset;

	private void Start()
	{
		_mainCamera = Camera.main;
		_offset = _mainCamera.transform.InverseTransformVector(transform.position - _mainCamera.transform.position);
	}

	private void Update()
	{
		transform.rotation = Quaternion.Lerp(
			transform.rotation, _mainCamera.transform.rotation, FollowSpeed * Time.deltaTime
		);
		Vector3 worldOffset = _mainCamera.transform.TransformVector(_offset);
		transform.position = Vector3.Lerp(
			transform.position, _mainCamera.transform.position + worldOffset, FollowSpeed * Time.deltaTime
		);
	}
}