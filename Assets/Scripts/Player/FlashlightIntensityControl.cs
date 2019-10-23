using UnityEngine;

public class FlashlightIntensityControl : MonoBehaviour
{
	public float FadeTime;
	public float MaxIntensity;
	public AnimationCurve FadeCurve;

	private float _startTime;
	private Light _light;

	private void Start()
	{
		_startTime = Time.time;
		_light = GetComponent<Light>();
	}

	private void Update()
	{
		if ((Time.time - _startTime) >= FadeTime)
		{
			_light.intensity = FadeCurve.Evaluate(1) * MaxIntensity;
			enabled = false;
		}
		else
		{
			_light.intensity = FadeCurve.Evaluate((Time.time - _startTime) / FadeTime) * MaxIntensity;
		}
	}
}