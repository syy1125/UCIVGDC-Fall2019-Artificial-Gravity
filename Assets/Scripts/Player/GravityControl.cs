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
	public GameObject SurfaceSnapArrowPrefab;

	[Header("Config")]
	public LayerMasks Masks;

	private GameObject _arrow;
	public string CancelGravitySnapKey = "f";
	public float DurationToActivateGravSnap;
	private float _gravSnapTimer = 0;
	private bool _leftMouseHeld = false;

	private void Start()
	{
		_arrow = Instantiate(SurfaceSnapArrowPrefab);
		_arrow.SetActive(false);
	}

	private void Update()
	{
		
		Transform t = Look.transform;
		
		Vector3? newDown = t.forward;

		if(Player.KeyDown(KeyCode.Mouse0)){
			//Mark button as held and begin tracking button held time.
			_gravSnapTimer = 0;
			_leftMouseHeld = true;
		}
		

		if(_leftMouseHeld){
			if(Player.KeyDown(CancelGravitySnapKey)){
				//Cancel the gravity snap AND don't track button held time until the key is pressed again
				_leftMouseHeld = false;
			} else {
				_gravSnapTimer += Time.deltaTime;
				if(_gravSnapTimer >= DurationToActivateGravSnap){

					//Overide newDown = transform.forward if left mouse has been held for long enough
					if (Physics.Raycast(t.position, t.forward, out RaycastHit hit, Mathf.Infinity, Masks.GroundMask.value))
					{
						_arrow.SetActive(true);
						_arrow.transform.SetPositionAndRotation(
							hit.point,
							Quaternion.LookRotation(-hit.normal)
						);
						newDown = -hit.normal;
					}
					else
					{
						newDown = null;
					}
				} 
			}
		} else {
			_arrow.SetActive(false);
		}

		if(Input.GetKeyUp(KeyCode.Mouse0) && newDown != null){
			_leftMouseHeld = false;
			if(Player.AllowInput()){
				//Only do gravity snap if input is currently allowed
				Gravity.enabled = true;
				Gravity.Down = newDown.Value;
			}
		} else if (Player.KeyDown(KeyCode.Mouse1))
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