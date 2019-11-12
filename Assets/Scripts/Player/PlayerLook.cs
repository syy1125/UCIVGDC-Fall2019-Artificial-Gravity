using System;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
	private Transform _parent;
	
	[Header("References")]
	public ControlsObject Controls;

	[Header("Config")]
	public float MinY;
	public float MaxY;

	private float _angleY;

	public float AngleY
	{
		get => _angleY;
		set => _angleY = Mathf.Clamp(value, MinY, MaxY);
	}

	private bool _controlsActive;

	private void Start()
	{
		_parent = transform.parent;
	}

	private void Update()
	{
		if (Controls.Gameplay.enabled)
		{
			if (!_controlsActive)
			{
				LockCursor();
				_controlsActive = true;
			}
		}
		else if (_controlsActive)
		{
			UnlockCursor();
			_controlsActive = false;
		}
		
		var input = Controls.Gameplay.Look.ReadValue<Vector2>();
		RotateView(input);
		transform.localRotation = Quaternion.Euler(-AngleY, 0f, 0f);

	}
	public void RotateView(Vector2 input){
		AngleY += input.y;
		_parent.Rotate(Vector3.up, input.x);
	}
	private static void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	private static void UnlockCursor()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
	
	
}