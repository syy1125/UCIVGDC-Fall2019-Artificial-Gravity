using UnityEngine;

public class PlayerOrientation : MonoBehaviour
{
	[Header("References")]
	public ArtificialGravity Gravity;
	public PlayerMovement Movement;
	public PlayerLook Look;

	[Header("Config")]
	public float RotationRate;
	public LayerMasks Masks;
	/// <summary>
	/// If there are platforms within this radius, airborne player will not orient to the direction they are looking in
	/// </summary>
	public float DisableOrientRadius;

	private float MaxDegreesDelta => RotationRate * Time.fixedDeltaTime;

	private void FixedUpdate()
	{
		Transform t = transform;
		if (Movement.Grounded)
		{
			Quaternion startRotation = t.rotation;
			t.rotation = Quaternion.RotateTowards(
				startRotation, Quaternion.FromToRotation(-t.up, Gravity.Down) * startRotation, MaxDegreesDelta
			);
		}
		else if (!Physics.CheckSphere(t.position, DisableOrientRadius, Masks.GroundMask.value))
		{
			Vector3 oldUp = t.up;
			t.rotation = Quaternion.RotateTowards(
				t.rotation, Look.transform.rotation, MaxDegreesDelta
			);
			Look.AngleY += Vector3.Angle(oldUp, t.forward) - 90;
		}
	}
}