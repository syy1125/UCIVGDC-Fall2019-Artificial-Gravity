using UnityEngine;
using UnityEngine.Serialization;

public class AirResistance : MonoBehaviour
{
	public float LateralFactor = 5;
	public float VerticalFactor = 1;

	private Transform _transform;
	private Transform Transform => _transform == null ? _transform = transform : _transform;
	private Rigidbody _body;
	private Rigidbody Body => _body == null ? _body = GetComponent<Rigidbody>() : _body;

	private void Update()
	{
		Vector3 localVelocity = Transform.InverseTransformVector(Body.velocity);
		Vector3 resistance = -new Vector3(
			localVelocity.x * LateralFactor,
			localVelocity.y * VerticalFactor,
			localVelocity.z * LateralFactor
		);
		Body.AddForce(Transform.TransformVector(resistance));
	}
}
