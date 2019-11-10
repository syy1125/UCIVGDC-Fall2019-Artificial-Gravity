using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PauseMenuController : MonoBehaviour
{
	[Header("References")]
	public ControlsObject Controls;
	public string PauseKey;
	private CanvasGroup _canvasGroup;

	public GameObject DefaultButton;
	private EventSystem _eventSystem;

	private void Awake()
	{
		_canvasGroup = GetComponent<CanvasGroup>();
		_eventSystem = EventSystem.current;
	}

	private void OnEnable()
	{
		Controls.UI.Pause.performed += HandleTogglePause;
	}

	private void OnDisable()
	{
		Controls.UI.Pause.performed -= HandleTogglePause;
	}

	private void HandleTogglePause(InputAction.CallbackContext context)
	{
		if (Player.Dead) return;
		if (!(context.interaction is TapInteraction)) return;
		if (!Player.Paused)
		{
			Pause();
		}
		else
		{
			Unpause();
		}
	}

	public void Pause()
	{
		Time.timeScale = 0;
		_canvasGroup.alpha = 1;
		_canvasGroup.blocksRaycasts = true;
		_canvasGroup.interactable = true;
		_eventSystem.SetSelectedGameObject(DefaultButton);
		Player.Paused = true;
	}

	public void Unpause()
	{
		Time.timeScale = 1;
		_canvasGroup.alpha = 0;
		_canvasGroup.blocksRaycasts = false;
		_canvasGroup.interactable = false;
		_eventSystem.SetSelectedGameObject(null);
		Player.Paused = false;
	}

	public void MainMenuPress()
	{
		_canvasGroup.interactable = false;
		Time.timeScale = 1;
		StartCoroutine(Transition.LoadLevel("Main Menu", false));
	}
}