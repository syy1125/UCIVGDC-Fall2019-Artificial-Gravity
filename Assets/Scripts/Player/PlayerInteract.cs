using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
	/*
	    This module raycasts from the player camera and calls OnInteract()
	    on any object tagged as "Interactable"
	 */

	[Header("References")]
	public ControlsObject Controls;

	[Header("Config")]
	private Transform _headTransform;
	public float InteractDistance = 2.5f;

	public static string HoverText = ""; //This will be read by a Text UI object

	private Interactable _focusedInteractable;

	public Interactable FocusedInteractable
	{
		get => _focusedInteractable;
		set
		{
			if (_focusedInteractable == value) return;
			
			if (_focusedInteractable != null)
			{
				_focusedInteractable.SetGlow(false);
			}

			_focusedInteractable = value;
			
			if (_focusedInteractable != null)
			{
				_focusedInteractable.SetGlow(true);
			}
		}
	}

	void Awake()
	{
		_headTransform = GetComponentInChildren<Camera>().transform;
		_focusedInteractable = null;
	}

	// Update is called once per frame
	void Update()
	{
		RayCast();
	}

	private void RayCast()
	{
		if (Physics.Raycast(_headTransform.position, _headTransform.forward, out RaycastHit hit, InteractDistance))
		{
			FocusedInteractable = hit.collider.gameObject.GetComponent<Interactable>();

			if (FocusedInteractable != null)
			{
				if (Controls.Gameplay.Interact.triggered)
				{
					FocusedInteractable.OnInteract();
				}

				HoverText = FocusedInteractable.HoverText();
			}
			else
			{
				HoverText = "";
			}
		}
		else
		{
			HoverText = "";
			FocusedInteractable = null;
		}
	}

	void OnDrawGizmos()
	{
		if (!_headTransform)
		{
			return;
		}

		Gizmos.color = Color.green;

		Gizmos.DrawWireSphere(_headTransform.position + _headTransform.forward * InteractDistance, .05f);
		Gizmos.DrawLine(_headTransform.position, _headTransform.position + _headTransform.forward * InteractDistance);
	}
}