using System.Collections;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	private static MusicPlayer _instance;
	
	public AudioClip[] Clips;

	private AudioSource _player;

	private void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else if (_instance != this)
		{
			Destroy(gameObject);
		}
	}

	private IEnumerator Start()
	{
		_player = GetComponent<AudioSource>();

		while (true)
		{
			foreach (AudioClip clip in Clips)
			{
				_player.clip = clip;
				_player.Play();
				yield return new WaitWhile(() => _player.isPlaying);
			}
		}
	}
	
	
}
