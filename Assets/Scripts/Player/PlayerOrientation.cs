using UnityEngine;

public class PlayerOrientation : MonoBehaviour
{
	[Header("References")]
	public PlayerGravity Gravity;

	[Header("Config")]
	public float RotationRate;

	private void FixedUpdate()
	{
		Transform t = transform;
		Quaternion r = t.rotation;
		
		Quaternion rotationDifference = Quaternion.FromToRotation(-t.up, Gravity.Down);
		Quaternion resultRotation = rotationDifference * r;
		r = Quaternion.RotateTowards(r, resultRotation, RotationRate * Time.fixedDeltaTime);
		t.rotation = r;
	}
}