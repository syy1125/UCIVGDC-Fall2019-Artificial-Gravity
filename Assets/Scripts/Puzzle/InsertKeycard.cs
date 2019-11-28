using System.Collections;
using UnityEngine;

// This class was used instead of an animation controller because the animation controller never does what I want it to.
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

	private void Reset()
	{
		Interaction = InteractType.OnlyOnce;
	}

	protected override void Start()
	{
		_color = KeycardColor;
		_color.a = 0;
		Renderer.material.color = _color;
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