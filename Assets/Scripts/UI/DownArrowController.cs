using UnityEngine;

public class DownArrowController : MonoBehaviour
{
	private void Update()
	{
		if (Player.Instance != null)
		{
			var gravity = Player.Instance.GetComponent<ArtificialGravity>();
			Transform cameraTransform = Player.Instance.GetComponentInChildren<Camera>().transform;
			if (gravity != null)
			{
				transform.rotation = Quaternion.LookRotation(
					cameraTransform.InverseTransformVector(gravity.Down)
				);
			}
		}
	}
}