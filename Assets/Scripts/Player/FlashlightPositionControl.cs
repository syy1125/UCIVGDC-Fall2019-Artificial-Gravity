using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class FlashlightPositionControl : MonoBehaviour
{
	private Transform _mainCamera;
	public float FollowSpeed;
	private Vector3 _offset;

	private void Start()
	{
		Debug.Assert(Camera.main != null);
		_mainCamera = Camera.main.transform;
		_offset = _mainCamera.InverseTransformPoint(_mainCamera.transform.position);
	}

	private void Update()
	{
		Transform t = transform;

		Quaternion startRotation = t.rotation;
		Quaternion targetRotation = _mainCamera.rotation;
		t.rotation = Quaternion.Lerp(
			startRotation, targetRotation,
			FollowSpeed * Quaternion.Angle(startRotation, targetRotation) / 30f * Time.deltaTime
		);

		Vector3 startPosition = t.position;
		Vector3 targetPosition = _mainCamera.TransformPoint(_offset);
		t.position = Vector3.Lerp(
			startPosition, targetPosition,
			FollowSpeed * (targetPosition - startPosition).magnitude / 0.5f * Time.deltaTime
		);
	}
}