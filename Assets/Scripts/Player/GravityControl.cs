using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

/// <summary>
/// Responsible for manipulating the direction of gravity when the player activates the appropriate controls
/// </summary>
public class GravityControl : MonoBehaviour
{
	[Header("References")]
	public ControlsObject Controls;
	public PlayerLook Look;
	public ArtificialGravity Gravity;
	public GameObject SurfaceSnapArrowPrefab;

	[Header("Config")]
	public LayerMasks Masks;

	private GameObject _arrow;
	private Transform _lookTransform;

	private bool _leftMouseHeld;
	private Vector3? _newDown;

	private void Start()
	{
		_arrow = Instantiate(SurfaceSnapArrowPrefab);
		_arrow.SetActive(false);
		_lookTransform = Look.transform;
	}

	private void OnEnable()
	{
		Controls.Gameplay.SetGravity.started += HandleStartSetGravity;
		Controls.Gameplay.SetGravity.performed += HandlePerformSetGravity;
		Controls.Gameplay.CancelGravity.performed += HandleCancelGravity;
		Controls.Gameplay.DirectionalGravity.performed += HandleDirectionalGravity;
	}

	private void OnDisable()
	{
		Controls.Gameplay.SetGravity.started -= HandleStartSetGravity;
		Controls.Gameplay.SetGravity.performed -= HandlePerformSetGravity;
		Controls.Gameplay.CancelGravity.performed -= HandleCancelGravity;
		Controls.Gameplay.DirectionalGravity.performed -= HandleDirectionalGravity;
	}

	private void HandleStartSetGravity(InputAction.CallbackContext context)
	{
		_leftMouseHeld = true;
		if (context.interaction is SlowTapInteraction)
		{
			_arrow.SetActive(true);
		}
	}

	private void HandlePerformSetGravity(InputAction.CallbackContext context)
	{
		if (_leftMouseHeld && _newDown != null)
		{
			Gravity.enabled = true;
			Gravity.Down = _newDown.Value;
		}

		_leftMouseHeld = false;
	}

	private void HandleCancelGravity(InputAction.CallbackContext context)
	{
		_leftMouseHeld = false;
	}

	private void HandleDirectionalGravity(InputAction.CallbackContext context)
	{
		if (context.interaction is TapInteraction)
		{
			var move = Controls.Gameplay.Movement.ReadValue<Vector2>();
			var jump = Controls.Gameplay.Jump.ReadValue<float>();
			var input = new Vector3(move.x, jump, move.y);

			if (input.magnitude <= float.Epsilon)
			{
				Gravity.enabled = false;
			}
			else
			{
				Gravity.enabled = true;
				Gravity.Down = _lookTransform.TransformVector(input);
			}
		}
	}

	private void Update()
	{
		_newDown = _lookTransform.forward;

		if (_leftMouseHeld && _arrow.activeSelf)
		{
			// Override newDown = transform.forward if left mouse has been held for long enough
			if (Physics.Raycast(
				_lookTransform.position, _lookTransform.forward, out RaycastHit hit, Mathf.Infinity,
				Masks.GroundMask.value
			))
			{
				_arrow.SetActive(true);
				_arrow.transform.SetPositionAndRotation(
					hit.point,
					Quaternion.LookRotation(-hit.normal)
				);
				_newDown = -hit.normal;
			}
			else
			{
				_newDown = null;
			}
		}
		else
		{
			_arrow.SetActive(false);
		}
	}
}