using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

[CreateAssetMenu(menuName = "Scriptable Objects/Controls", fileName = "Controls")]
public class ControlsObject : ScriptableObject
{
	private ControlsWrapper _controls;

	private static ControlsWrapper CreateWrapper()
	{
		var controls = new ControlsWrapper();
		controls.Enable();
		return controls;
	}

	private ControlsWrapper Controls => _controls ?? (_controls = CreateWrapper());

	public ControlsWrapper.GameplayActions Gameplay => Controls.Gameplay;
	public ControlsWrapper.UIActions UI => Controls.UI;
}