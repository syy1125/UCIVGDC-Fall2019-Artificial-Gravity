using UnityEngine;
using UnityEngine.UI;

public class GravitonSurgeChargeBar : MonoBehaviour
{
	[Header("References")]
	private GravitonSurge _surge;

	private GravitonSurge GetSurge()
	{
		if (_surge != null) return _surge;
		if (Player.Instance == null) return null;
		return _surge = Player.Instance.GetComponentInChildren<GravitonSurge>();
	}

	private Image _bar;

	void Start()
	{
		_bar = GetComponent<Image>();
	}

	private void Update()
	{
		GravitonSurge surge = GetSurge();
		if (surge == null) return;
		_bar.fillAmount = surge.Charge / surge.MaxDuration;
	}
}