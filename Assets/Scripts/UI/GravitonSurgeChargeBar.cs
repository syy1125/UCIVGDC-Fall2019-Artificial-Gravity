using UnityEngine;
using UnityEngine.UI;

public class GravitonSurgeChargeBar : MonoBehaviour
{
	[Header("References")]
	public GravitonSurge Surge;
	public Image Bar;

	private void Update()
	{
		Bar.fillAmount = Surge.Charge / Surge.MaxDuration;
	}
}