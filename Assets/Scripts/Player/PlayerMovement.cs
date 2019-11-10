using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	private Transform _transform;

	private Rigidbody _body;

	[Header("References")]
	[SerializeField]
	public ControlsObject Controls;
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

	private Vector3 _directionalInput;

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

			Vector3 scale = _transform.lossyScale;
			const float tolerance = 1e-6f;
			if (Mathf.Abs(scale.x - scale.y) > tolerance || Mathf.Abs(scale.x - scale.z) > tolerance)
			{
				Debug.LogWarning(
					"The player does not have uniform scaling in all three dimensions.\n"
					+ "This may cause wonky behaviour with ground detection."
				);
			}

			return Physics.CapsuleCast(
				point1, point2,
				Collider.radius * (scale.x / 3 + scale.y / 3 + scale.z / 3),
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

	private void FixedUpdate()
	{
		var input = Controls.Gameplay.Movement.ReadValue<Vector2>();
		var jump = Controls.Gameplay.Jump.ReadValue<float>();

		if (Grounded)
		{
			input *= WalkSpeed;
			Vector3 localVelocity = _transform.InverseTransformVector(_body.velocity);
			localVelocity.x = input.x;
			localVelocity.z = input.y;
			_body.velocity = _transform.TransformVector(localVelocity);

			if (Time.time > _lastJump + JumpCooldown && jump > 0)
			{
				_body.AddForce(_transform.up * JumpStrength, ForceMode.VelocityChange);
				_lastJump = Time.time;
			}
		}
		else
		{
			input *= AirborneForce;
			_body.AddForce(_transform.TransformVector(input.x, jump, input.y), ForceMode.Acceleration);
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