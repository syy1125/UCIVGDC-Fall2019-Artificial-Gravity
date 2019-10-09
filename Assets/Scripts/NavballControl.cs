using UnityEngine;

public class NavballControl : MonoBehaviour
{
	public GameObject Player;
	public GameObject PlayerCamera;

	private void Update()
	{
		transform.rotation = Quaternion.Inverse(PlayerCamera.transform.localRotation);
	}
}