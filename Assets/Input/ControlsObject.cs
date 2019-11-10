using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

[CreateAssetMenu(menuName = "Scriptable Objects/Controls", fileName = "Controls")]
public class ControlsObject : ScriptableObject
{
	private ControlsWrapper _controls;

	private static ControlsWrapper CreateWrapper()
	{
		var user = new InputUser();
		var controls = new ControlsWrapper();

		if (controls.controlSchemes.Count > 0)
		{
			foreach (InputDevice device in InputSystem.devices)
			{
				if (controls.controlSchemes[0].SupportsDevice(device))
				{
					user = InputUser.PerformPairingWithDevice(device, user);
				}
			}

			user.ActivateControlScheme(controls.controlSchemes[0]);
			user.AssociateActionsWithUser(controls);
		}

		controls.Enable();
		return controls;
	}

	private ControlsWrapper Controls => _controls ?? (_controls = CreateWrapper());

	public ControlsWrapper.GameplayActions Gameplay => Controls.Gameplay;
	public ControlsWrapper.UIActions UI => Controls.UI;
}