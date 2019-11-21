using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveUI : MonoBehaviour
{
	public static ObjectiveUI Instance { get; private set; }

	[Header("References")]
	public Text ObjectiveText;
	public Transform EnlargedObjectiveText;
	
	[Header("Config")]
	public float HighlightTime;
	public AnimationCurve HighlightCurve;

	private Coroutine _highlightCoroutine;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
	}

	public void SetObjective(string objective)
	{
		ObjectiveText.text = objective;

		if (_highlightCoroutine != null)
		{
			StopCoroutine(_highlightCoroutine);
			_highlightCoroutine = null;
		}

		_highlightCoroutine = StartCoroutine(HighlightObjective());
	}

	private IEnumerator HighlightObjective()
	{
		Transform textTransform = ObjectiveText.transform;
		Vector3 initialPosition = textTransform.position;
		Vector3 initialScale = textTransform.localScale;

		float startTime = Time.time;
		while ((Time.time - startTime) < HighlightTime)
		{
			float lerpParameter = HighlightCurve.Evaluate((Time.time - startTime) / HighlightTime);
			textTransform.position = Vector3.Lerp(EnlargedObjectiveText.position, initialPosition, lerpParameter);
			textTransform.localScale = Vector3.Lerp(EnlargedObjectiveText.localScale, initialScale, lerpParameter);
			yield return null;
		}

		textTransform.position = initialPosition;
		textTransform.localScale = initialScale;
		_highlightCoroutine = null;
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}
}