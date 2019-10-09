using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Transform _parent;
	private Transform Parent => _parent == null ? _parent = transform : _parent;

	private Rigidbody _body;
	private Rigidbody Body => _body == null ? _body = GetComponentInParent<Rigidbody>() : _body;

	[Header("Walking")]
	public float WalkSpeed;

	[Header("Jumping")]
	public LayerMask GroundMask;
	public float JumpStrength;

	private int _groundContactCount;
	private bool Grounded => _groundContactCount > 0;

	private void Update()
	{
		var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		if (input.magnitude > 1)
		{
			input.Normalize();
		}

		input *= WalkSpeed;

		Body.velocity = Parent.TransformDirection(input.x, Parent.InverseTransformDirection(Body.velocity).y, input.y);
	}

	private void FixedUpdate()
	{
		if (Input.GetAxisRaw("Jump") > 0 && Grounded)
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