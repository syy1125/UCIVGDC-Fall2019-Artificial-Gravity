using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryController : MonoBehaviour
{
	public string ActiveLevel;

	private void Awake()
	{
		if (SceneManager.GetActiveScene().name != ActiveLevel)
		{
			Destroy(gameObject);
		}
	}
}