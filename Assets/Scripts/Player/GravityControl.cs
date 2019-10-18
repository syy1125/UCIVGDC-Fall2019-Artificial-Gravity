using System;
using UnityEngine;

/// <summary>
/// Responsible for manipulating the direction of gravity when the player activates the appropriate controls
/// </summary>
public class GravityControl : MonoBehaviour
{
	[Header("References")]
	public PlayerLook Look;
	public PlayerGravity Gravity;
	public GameObject SurfaceSnapArrow;
	
	[Header("Config")]
	public LayerMask GroundMask;

	private void Update()
	{
		Transform t = Look.transform;
		Vector3 newDown = t.forward;
		
		if (Input.GetAxisRaw("Snap") > 0)
		{
			if (Physics.Raycast(t.position, t.forward, out RaycastHit hit, Mathf.Infinity, GroundMask.value))
			{
				SurfaceSnapArrow.SetActive(true);
				SurfaceSnapArrow.transform.SetPositionAndRotation(
					hit.point,
					Quaternion.LookRotation(-hit.normal)
				);
				newDown = -hit.normal;
			}
		}
		else
		{
			SurfaceSnapArrow.SetActive(false);
		}

		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			Gravity.Down = newDown;
		}
	}
}
