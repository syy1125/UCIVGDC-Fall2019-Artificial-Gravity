using System;
using UnityEngine;

/// <summary>
/// Responsible for manipulating the direction of gravity when the player activates the appropriate controls
/// </summary>
public class GravityControl : MonoBehaviour
{
	[Header("References")]
	public PlayerLook Look;
	public ArtificialGravity Gravity;
	public GameObject SurfaceSnapArrow;

	[Header("Config")]
	public LayerMasks Masks;

	private void Update()
	{
		Transform t = Look.transform;
		
		Vector3 newDown = t.forward;
		if (Input.GetAxisRaw("Snap") > 0)
		{
			if (Physics.Raycast(t.position, t.forward, out RaycastHit hit, Mathf.Infinity, Masks.GroundMask.value))
			{
				SurfaceSnapArrow.SetActive(true);
				SurfaceSnapArrow.transform.SetPositionAndRotation(
					hit.point,
					Quaternion.LookRotation(-hit.normal)
				);
				newDown = -hit.normal;
			}
			else
			{
				return;
			}
		}
		else
		{
			SurfaceSnapArrow.SetActive(false);
		}

		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			Gravity.enabled = true;
			Gravity.Down = newDown;
		}
		else if (Input.GetKeyDown(KeyCode.Mouse1))
		{
			var input = new Vector3(
				Input.GetAxisRaw("Horizontal"),
				Input.GetAxisRaw("Jump"),
				Input.GetAxisRaw("Vertical")
			);

			if (input.magnitude <= float.Epsilon)
			{
				Gravity.enabled = false;
			}
			else
			{
				Gravity.enabled = true;
				Gravity.Down = t.TransformVector(input);
			}
		}
	}
}