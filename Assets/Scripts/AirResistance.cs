using UnityEngine;
using UnityEngine.Serialization;

public class AirResistance : MonoBehaviour
{
	[Header("References")]
	public ArtificialGravity Gravity;
	
	[Header("Config")]
	public float LateralFactor = 5;
	public float VerticalFactor = 1;

	private Transform _transform;
	private Transform Transform => _transform == null ? _transform = transform : _transform;
	private Rigidbody _body;
	private Rigidbody Body => _body == null ? _body = GetComponent<Rigidbody>() : _body;

	private void Update()
	{
		Vector3 velocity = Body.velocity;
		Vector3 verticalVelocity = Vector3.Project(velocity, Gravity.Down);
		Vector3 lateralVelocity = Vector3.ProjectOnPlane(velocity, Gravity.Down);
		
		Body.AddForce(-(lateralVelocity * LateralFactor + verticalVelocity * VerticalFactor));
	}
}
