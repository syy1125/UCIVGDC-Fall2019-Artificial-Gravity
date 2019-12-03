using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveUI : MonoBehaviour
{
	public static ObjectiveUI Instance { get; private set; }

	[Header("References")]
	public Text ObjectiveText;

	[Header("Config")]
	[TextArea]
	public string ObjectivePrefix;
	public float TextTypeInterval;

	private string _objective;

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

	private void Start()
	{
		_objective = "";
		UpdateObjective();
	}

	private void UpdateObjective()
	{
		ObjectiveText.text = $"{ObjectivePrefix} {_objective}";
	}
	
	public void SetObjective(string objective)
	{
		if (_highlightCoroutine != null)
		{
			StopCoroutine(_highlightCoroutine);
			_highlightCoroutine = null;
		}

		_highlightCoroutine = StartCoroutine(HighlightObjective(objective));
	}

	private IEnumerator HighlightObjective(string objective)
	{
		while (_objective.Length > 0)
		{
			_objective = _objective.Substring(0, _objective.Length - 1);
			UpdateObjective();
			yield return new WaitForSecondsRealtime(TextTypeInterval);
		}

		while (_objective.Length < objective.Length)
		{
			_objective = objective.Substring(0, _objective.Length + 1);
			UpdateObjective();
			yield return new WaitForSecondsRealtime(TextTypeInterval);
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}
}