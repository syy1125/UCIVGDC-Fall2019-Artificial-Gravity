using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Transform _transform;

	private Rigidbody _body;

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
			Vector3 point1 =
				_transform.TransformPoint(Collider.center + Vector3.up * (Collider.height / 2 - Collider.radius))
				- Gravity.Down * GroundDetectionRange;
			Vector3 point2 =
				_transform.TransformPoint(Collider.center + Vector3.down * (Collider.height / 2 - Collider.radius))
				- Gravity.Down * GroundDetectionRange;
			return Physics.CapsuleCast(
				point1, point2,
				Collider.radius,
				Gravity.Down,
				GroundDetectionRange * 2,
				Masks.GroundMask.value
			);
		}
	}

	private void Start()
	{
		_transform = transform;
		_body = GetComponent<Rigidbody>();
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
			_body.velocity = _transform.TransformDirection(
				input.x, _transform.InverseTransformDirection(_body.velocity).y, input.z
			);
		}
		else
		{
			input *= AirborneForce;
			_body.AddForce(_transform.TransformDirection(input), ForceMode.Acceleration);
		}
	}

	private void FixedUpdate()
	{
		if (Grounded && Time.time > _lastJump + JumpCooldown && Input.GetAxisRaw("Jump") > 0)
		{
			_body.AddForce(transform.up * JumpStrength, ForceMode.VelocityChange);
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