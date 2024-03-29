﻿using UnityEditor;
using UnityEngine;

public class GravitonSurge : MonoBehaviour
{
	[Header("References")]
	public ControlsObject Controls;
	public ArtificialGravity Gravity;

	[Header("Config")]
	public float Multiplier;
	public float MaxDuration;
	public float RechargeDelay;
	public float RechargeRate;

	private float _baseGravity;
	private float _surgeGravity;
	public float Charge { get; private set; }
	private float _lastActive;

	private void Start()
	{
		_baseGravity = Gravity.Gravity;
		_surgeGravity = _baseGravity * Multiplier;
		Charge = MaxDuration;
	}

	private void Update()
	{
		if (Controls.Gameplay.GravitonSurge.ReadValue<float>() > float.Epsilon && Charge > 0)
		{
			Gravity.Gravity = _surgeGravity;
			Charge -= Time.deltaTime;
			_lastActive = Time.time;
		}
		else
		{
			Gravity.Gravity = _baseGravity;
			if (Time.time - _lastActive > RechargeDelay)
			{
				Charge = Mathf.Min(Charge + Time.deltaTime * RechargeRate, MaxDuration);
			}
		}
	}
}