using System.Collections;
using UnityEngine;

public class InsertKeycard : Interactable
{
	[Header("References")]
	public Transform KeycardTransform;
	public Renderer Renderer;

	[Header("Config")]
	public Color KeycardColor;
	public float FadeInTime;
	public float InsertTime;

	private Color _color;
	private bool _used;

	private void Reset()
	{
		Interaction = InteractType.OnlyOnce;
	}

	private void Start()
	{
		_color = KeycardColor;
		_color.a = 0;
		Renderer.material.color = _color;

		_used = false;
	}

	public override void OnInteract()
	{
//		if (_used || !PlayerInventory.Instance.HasItem(UnlockedByItem)) return;
//		_used = true;
//		PlayerInventory.Instance.RemoveItem(UnlockedByItem);
		StartCoroutine(Insert());
	}

	private IEnumerator Insert()
	{
		float startTime = Time.time;
		while (Time.time - startTime < FadeInTime)
		{
			_color.a = (Time.time - startTime) / FadeInTime;
			Renderer.material.color = _color;
			yield return null;
		}

		_color.a = 1;
		Renderer.material.color = _color;

		startTime = Time.time;
		Vector3 start = KeycardTransform.localPosition;
		Vector3 end = start + new Vector3(0, 0, KeycardTransform.localScale.z * 1.2f);
		while (Time.time - startTime < InsertTime)
		{
			KeycardTransform.localPosition = Vector3.Lerp(start, end, (Time.time - startTime) / InsertTime);
			yield return null;
		}

		KeycardTransform.localPosition = end;

		ActivateOthers();
	}
}