using UnityEngine;
using UnityEngine.UI;

public class GravitonSurgeChargeBar : MonoBehaviour
{
	[Header("References")]
	private GravitonSurge _surge;
	private Image _bar;

	void Start(){
		_surge = Player.Instance.GetComponentInChildren<GravitonSurge>();
		_bar = GetComponent<Image>();
	}
	private void Update()
	{
		_bar.fillAmount = _surge.Charge / _surge.MaxDuration;
	}
}