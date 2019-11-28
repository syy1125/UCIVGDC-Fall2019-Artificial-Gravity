using UnityEngine;

public class FlashlightPositionControl : MonoBehaviour
{
	public Transform FollowCamera;
	public float FollowSpeed;
	private Vector3 _offset;

	private void Start()
	{
		_offset = FollowCamera.InverseTransformPoint(FollowCamera.transform.position);
	}

	private void LateUpdate()
	{
		if (FollowCamera == null)
		{
			Destroy(gameObject);
			return;
		}

		Transform t = transform;

		Quaternion startRotation = t.rotation;
		Quaternion targetRotation = FollowCamera.rotation;
		t.rotation = Quaternion.Lerp(
			startRotation, targetRotation,
			FollowSpeed * Quaternion.Angle(startRotation, targetRotation) / 30f * Time.deltaTime
		);

		Vector3 startPosition = t.position;
		Vector3 targetPosition = FollowCamera.TransformPoint(_offset);
		t.position = Vector3.Lerp(
			startPosition, targetPosition,
			FollowSpeed * (targetPosition - startPosition).magnitude / 0.5f * Time.deltaTime
		);
	}
}