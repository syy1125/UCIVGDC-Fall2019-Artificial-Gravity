﻿using UnityEngine;

public class ArtificialGravity : MonoBehaviour
{
	private Rigidbody _body;
	private Rigidbody Body => _body == null ? _body = GetComponent<Rigidbody>() : _body;

	public float Gravity = 10;
	private Vector3 _down = Vector3.down;
	public Vector3 Down
	{
		get => _down;
		set => _down = value.normalized;
	}

	private void FixedUpdate()
	{
		Body.AddForce(Down * Gravity, ForceMode.Acceleration);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawRay(transform.position, Down);
	}
}