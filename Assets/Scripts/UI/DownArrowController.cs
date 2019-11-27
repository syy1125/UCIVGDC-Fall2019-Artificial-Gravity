using UnityEngine;

public class DownArrowController : MonoBehaviour
{
	private ArtificialGravity _playerGravity;
	private Camera _playerCamera;

	private void Update()
	{
		if (Player.Dead)
		{
			_playerGravity = null;
			_playerCamera = null;
			return;
		}

		if (_playerGravity == null || _playerCamera == null)
		{
			_playerGravity = Player.Instance.GetComponent<ArtificialGravity>();
			_playerCamera = Player.Instance.GetComponentInChildren<Camera>();
		}

		transform.rotation = Quaternion.LookRotation(
			_playerCamera.transform.InverseTransformVector(_playerGravity.Down)
		);
	}
}