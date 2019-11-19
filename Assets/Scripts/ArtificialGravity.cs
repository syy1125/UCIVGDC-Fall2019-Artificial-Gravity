using UnityEngine;

public class ArtificialGravity : MonoBehaviour
{
	private Rigidbody _body;
	private Rigidbody Body => _body == null ? _body = GetComponent<Rigidbody>() : _body;

	public float Gravity = 10;
	// When linked, gravity is effectively the linked script's gravity
	private ArtificialGravity _link;
	
	private Vector3 _down = Vector3.down;
	
	
	// Does not take link into account
	public Vector3 Down
	{
		get => _down;
		set => _down = value.normalized;
	}

	// Takes link into account
	private Vector3 EffectiveDown => _link == null ? Down : _link.Down;
	private float EffectiveGravity => _link == null ? Gravity : _link.Gravity;

	// `target` is the controller
	public void ToggleLink(ArtificialGravity target)
	{
		if (_link == null)
		{
			_link = target;
		}
		else
		{
			_link = null;
		}
	}

	private void FixedUpdate()
	{
		Body.AddForce(EffectiveDown * EffectiveGravity, ForceMode.Acceleration);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawRay(transform.position, EffectiveDown);
	}
}