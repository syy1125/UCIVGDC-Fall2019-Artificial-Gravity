using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Transform _parent;
	private Transform Parent => _parent == null ? _parent = transform : _parent;

	private Rigidbody _body;
	private Rigidbody Body => _body == null ? _body = GetComponentInParent<Rigidbody>() : _body;

	[Header("Walking")]
	public float WalkSpeed;
	public float AirborneForce;

	[Header("Jumping")]
	public LayerMask GroundMask;
	public float JumpStrength;

	private int _groundContactCount;
	private bool Grounded => _groundContactCount > 0;

	private void Update()
	{
		var input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		if (input.magnitude > 1)
		{
			input.Normalize();
		}

		if (Grounded)
		{
			input *= WalkSpeed;
			Body.velocity = Parent.TransformDirection(
				input.x, Parent.InverseTransformDirection(Body.velocity).y, input.z
			);
		}
		else
		{
			input *= AirborneForce;
			Body.AddForce(Parent.TransformDirection(input), ForceMode.Acceleration);
		}
	}

	private void FixedUpdate()
	{
		if (Grounded && Input.GetAxisRaw("Jump") > 0)
		{
			Body.AddForce(transform.up * JumpStrength, ForceMode.VelocityChange);
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (((1 << other.gameObject.layer) & GroundMask.value) != 0)
		{
			++_groundContactCount;
		}
	}

	private void OnCollisionExit(Collision other)
	{
		if (((1 << other.gameObject.layer) & GroundMask.value) != 0)
		{
			--_groundContactCount;
		}
	}
}