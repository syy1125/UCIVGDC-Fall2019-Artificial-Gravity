using System;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
	private Transform _parent;
	private Transform Parent => _parent == null ? _parent = transform.parent : _parent;

	private CapsuleCollider _collider;

	private CapsuleCollider Collider =>
		_collider == null ? _collider = Parent.GetComponent<CapsuleCollider>() : _collider;

	public float MinY;
	public float MaxY;

	private float _angleY;

	private float AngleY
	{
		get => _angleY;
		set => _angleY = Mathf.Clamp(value, MinY, MaxY);
	}

	public LayerMask GroundMask;
	public GameObject SurfaceSnapArrow;

	private void OnEnable()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void Update()
	{
		AngleY += Input.GetAxisRaw("Mouse Y");

		Parent.Rotate(Vector3.up, Input.GetAxisRaw("Mouse X"));

		Vector3 oldUp = Parent.up;
		bool rotated = false;

		if (Input.GetAxisRaw("Snap") > 0)
		{
			Transform t = transform;

			if (Physics.Raycast(t.position, t.forward, out RaycastHit hit, Mathf.Infinity, GroundMask.value))
			{
				SurfaceSnapArrow.SetActive(true);
				SurfaceSnapArrow.transform.SetPositionAndRotation(
					hit.point,
					Quaternion.LookRotation(-hit.normal)
				);

				Vector3 newUp = new Vector3();
				if (Input.GetKeyDown(KeyCode.E))
				{
					newUp = hit.normal;
					rotated = true;
				}
				else if (Input.GetKeyDown(KeyCode.Q))
				{
					newUp = -hit.normal;
					rotated = true;
				}

				if (rotated)
				{
					Vector3 look = t.forward;
					Parent.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(look, newUp), newUp);
					Vector3 localLook = Parent.InverseTransformDirection(look);
					AngleY = Mathf.Atan2(
						         localLook.y, Mathf.Sqrt(localLook.x * localLook.x + localLook.z * localLook.z)
					         ) * Mathf.Rad2Deg;
				}
			}
		}
		else
		{
			SurfaceSnapArrow.SetActive(false);

			if (Input.GetKeyDown(KeyCode.E))
			{
				Parent.Rotate(new Vector3(-AngleY - 90f, 0f, 0f));
				AngleY = MinY;
				rotated = true;
			}

			if (Input.GetKeyDown(KeyCode.Q))
			{
				Parent.Rotate(new Vector3(-AngleY + 90f, 0f, 0f));
				AngleY = MaxY;
				rotated = true;
			}
		}

		if (rotated)
		{
			Parent.Translate((oldUp - Parent.up) * Collider.height / 2, Space.World);
		}
	}

	private void LateUpdate()
	{
		transform.localRotation = Quaternion.Euler(-AngleY, 0f, 0f);
	}

	private void OnDisable()
	{
		Cursor.lockState = CursorLockMode.None;
	}
}