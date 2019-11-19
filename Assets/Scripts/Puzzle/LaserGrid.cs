using UnityEngine;

public class LaserGrid : PuzzleElement
{
	public ActivationType Activation = ActivationType.Standard;
	public PuzzleElement DisabledBy;
	private Collider LaserCollider;
	public GameObject LaserParent;
	private Light[] Lights;
	private AudioSource _source;

	void Awake()
	{
		Lights = GetComponentsInChildren<Light>();
		LaserCollider = GetComponent<Collider>();
		if (DisabledBy != null)
		{
			DisabledBy.ActivateEvent += new PuzzleElementEventHandler(OnActivate);
			DisabledBy.DeactivateEvent += new PuzzleElementEventHandler(OnDeactivate);
			DisabledBy.ToggleEvent += new PuzzleElementEventHandler(OnToggle);
		}
		_source = GetComponent<AudioSource>();
		_source.spatialize = true;
		if(State == 1){
			_source.Play();
		}
	}

	void Update()
	{
		//A Child is disabled because this current gameObject must be enabled to receive events.
		LaserParent.SetActive(State == 1);
		LaserCollider.enabled = (State == 1);
		foreach (Light l in Lights)
		{
			l.enabled = (State == 1);
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		Player player = collider.GetComponent<Player>();
		if (player != null)
		{
			player.KillPlayer();
		}
	}

	public void OnActivate()
	{
		if (Activation != ActivationType.OnlyDeactivate)
		{
			State = 0;
			_source.Play();
		}
	}

	public void OnDeactivate()
	{
		if (Activation != ActivationType.OnlyActivate)
		{
			State = 1;
			_source.Stop();
		}
	}

	public void OnToggle()
	{
		if (State == 0)
		{
			State = 1;
			_source.Play();
		}
		else if (State == 1)
		{
			State = 0;
			_source.Stop();
		}
	}
}