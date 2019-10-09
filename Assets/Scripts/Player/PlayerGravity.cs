using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
	private Rigidbody _body;
	private Rigidbody Body => _body == null ? _body = GetComponent<Rigidbody>() : _body;

	public float Gravity = 10;

	private void Update()
	{
		Body.AddForce(-transform.up * Gravity, ForceMode.Acceleration);
	}
}