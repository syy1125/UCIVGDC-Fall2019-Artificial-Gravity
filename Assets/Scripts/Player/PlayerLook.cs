using System;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
	private Transform _parent;
	private Transform Parent => _parent == null ? _parent = transform.parent : _parent;

	public float MinY;
	public float MaxY;

	private float _angleY;

	public float AngleY
	{
		get => _angleY;
		set => _angleY = Mathf.Clamp(value, MinY, MaxY);
	}


	private void OnEnable()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	private void Update()
	{
		if(Player.AllowInput())
		{
			AngleY += Input.GetAxisRaw("Mouse Y");
			Parent.Rotate(Vector3.up, Input.GetAxisRaw("Mouse X"));
		}
		
	}
	
	private void LateUpdate()
	{
		transform.localRotation = Quaternion.Euler(-AngleY, 0f, 0f);
	}

	private void OnDisable()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
}