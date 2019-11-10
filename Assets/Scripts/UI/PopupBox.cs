using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PopupBox : PuzzleElement
{
	[Header("References")]
	public ControlsObject Controls;

	[Header("Optional Trigger Options")]
	public PuzzleElement TriggeredBy; //i.e. A button press can open a popup box
	public PopupBox TriggerNextPopup; //Will open another popupbox (a chain of boxes is possible)
	private CanvasGroup _group;

	void Awake()
	{
		if (TriggeredBy != null)
		{
			TriggeredBy.ActivateEvent += new PuzzleElementEventHandler(OnActivate);
		}

		_group = GetComponent<CanvasGroup>();
		if (State == 1)
		{
			OnActivate();
		}
		else
		{
			_group.alpha = 0;
			_group.blocksRaycasts = false;
		}
	}

	private void OnEnable()
	{
		Controls.UI.DismissPopup.performed += HandleDismiss;
	}

	private void OnDisable()
	{
		Controls.UI.DismissPopup.performed -= HandleDismiss;
	}

	private void HandleDismiss(InputAction.CallbackContext context)
	{
		if (State == 1 && context.interaction is TapInteraction)
		{
			StartCoroutine(Dismiss());
		}
	}

	public void OnActivate()
	{
		State = 1;
		_group.alpha = 1;
		_group.blocksRaycasts = true;
		Player.ActivePopup = true;
	}

	public IEnumerator Dismiss()
	{
		State = 0;

		if (TriggerNextPopup != null)
		{
			// Prevent next PopupBox from using this frame's input to close itself
			yield return null;
			_group.alpha = 0;
			_group.blocksRaycasts = false;
			TriggerNextPopup.OnActivate();
		}
		else
		{
			_group.alpha = 0;
			_group.blocksRaycasts = false;
			Player.ActivePopup = false;
		}
	}

	public void ForceClose()
	{
		// Do not activate other boxes on dismissal
		State = 0;
		_group.alpha = 0;
		_group.blocksRaycasts = false;
		Player.ActivePopup = false;
	}
}