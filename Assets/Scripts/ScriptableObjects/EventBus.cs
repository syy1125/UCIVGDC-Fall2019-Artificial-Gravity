using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Event Bus", fileName = "Event")]
public class EventBus : ScriptableObject
{
	public event Action OnTriggered;

	public void Invoke()
	{
		OnTriggered?.Invoke();
	}
}