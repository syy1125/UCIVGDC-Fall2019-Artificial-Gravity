using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Transform _parent;
	private Transform Parent => _parent == null ? _parent = transform : _parent;

	private Rigidbody _body;
	private Rigidbody Body => _body == null ? _body = GetComponentInParent<Rigidbody>() : _body;

	[Header("References")]
	public ArtificialGravity Gravity;
	public CapsuleCollider Collider;

	[Header("Config")]
	public float WalkSpeed;
	public float AirborneForce;
	public float JumpStrength;
	public float JumpCooldown;
	public LayerMasks Masks;
	[Range(0, 1)]
	public float GroundDetectionRange;

	private int _groundContactCount;
	private float _lastJump;

	public bool Grounded
	{
		get
		{
			if (_groundContactCount <= 0) return false;
			Transform t = transform;
			return Physics.CheckCapsule(
				t.TransformPoint(Collider.center + Vector3.up * Collider.height / 2)
				+ Gravity.Down * GroundDetectionRange,
				t.TransformPoint(Collider.center + Vector3.down * Collider.height / 2)
				+ Gravity.Down * GroundDetectionRange,
				Collider.radius,
				Masks.GroundMask.value
			);
		}
	}

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
		if (Grounded && Time.time > _lastJump + JumpCooldown && Input.GetAxisRaw("Jump") > 0)
		{
			Body.AddForce(transform.up * JumpStrength, ForceMode.VelocityChange);
			_lastJump = Time.time;
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (((1 << other.gameObject.layer) & Masks.GroundMask.value) != 0)
		{
			++_groundContactCount;
		}
	}

	private void OnCollisionExit(Collision other)
	{
		if (((1 << other.gameObject.layer) & Masks.GroundMask.value) != 0)
		{
			--_groundContactCount;
		}
	}
}