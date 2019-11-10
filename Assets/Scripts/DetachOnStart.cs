using UnityEngine;

public class DetachOnStart : MonoBehaviour
{
	private void Start()
	{
		transform.SetParent(null, true);
	}
}