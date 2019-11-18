using System;
using UnityEngine;

public class Player : MonoBehaviour
{
	public static Player Instance;
	private static PlayerLook _look;
	public ControlsObject Controls;

	private static bool _dead;
	private static bool _paused;
	private static bool _activePopup;

	public static event Action OnPlayerKilled;

	public static bool Dead
	{
		get => _dead;
		private set
		{
			_dead = value;
			UpdateControlActive();
		}
	}

	public static bool Paused
	{
		get => _paused;
		set
		{
			_paused = value;
			UpdateControlActive();
		}
	}

	public static bool ActivePopup
	{
		get => _activePopup;
		set
		{
			_activePopup = value;
			UpdateControlActive();
		}
	}


	// Start is called before the first frame update
	void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}
		
		Instance = this;
		Dead = false;
		Paused = false;
		ActivePopup = false;

		_look = GetComponentInChildren<PlayerLook>();
	}

	public void KillPlayer()
	{
		Dead = true;
		var playerCamera = GetComponentInChildren<Camera>();
		playerCamera.transform.SetParent(null, true);
		gameObject.SetActive(false);
		OnPlayerKilled?.Invoke();
	}

	private static void UpdateControlActive()
	{
		if (AllowInput())
		{
			Instance.Controls.Gameplay.Enable();
		}
		else
		{
			Instance.Controls.Gameplay.Disable();
		}
	}

	private static bool AllowInput()
	{
		return !Paused && !Dead && !ActivePopup;
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}
}