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

	private void Update()
	{
		
		Transform t = transform;

		/*
		This line makes large capsule rotations smooth but introduces single frame camera clipping.
		CapsuleCollider cc = GetComponent<CapsuleCollider>();
		cc.height = Mathf.Lerp(2,1,Vector3.Angle(-t.up,Gravity.Down)/160);
		*/
		if (Movement.Grounded)
		{
			Quaternion startRotation = t.rotation;
			Vector3 forwardBeforeRotate = Look.transform.forward;
			t.rotation = Quaternion.RotateTowards(
				startRotation, Quaternion.FromToRotation(-t.up, Gravity.Down) * startRotation, MaxDegreesDelta
			);
			Vector3 forwardAfterRotate = Look.transform.forward;
			float angleBetweenLookAndGravity = Vector3.Angle(Gravity.Down, Look.transform.forward);
			
			if(angleBetweenLookAndGravity > 90){
				//Counter-rotate if the player is looking above horizontal
				Look.RotateView(new Vector2(0,-1*Vector3.Angle(forwardAfterRotate,forwardBeforeRotate)));
			}

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
	private void OnDrawGizmos(){
		if(Look == null)
			return;

		//Gravity direction
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(transform.position,transform.position+Gravity.Down.normalized*10);
		//Camera direction
		Gizmos.color = Color.red;
		Gizmos.DrawLine(Look.transform.position,Look.transform.position+Look.transform.forward*10);
		//Player-down direction
		Gizmos.color = Color.cyan;
		Gizmos.DrawLine(transform.position,transform.position+transform.up*-10);
	}
}