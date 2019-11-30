using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEntryTrigger : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			SceneManager.SetActiveScene(gameObject.scene);
		}
	}
}