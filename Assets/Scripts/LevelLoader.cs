using System.Collections;
using System.Linq;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	// When the player picks up these items, it readies the next level
	public string[] LoadTriggers;
	// When the player triggers this event bus (generally through an interactable), it loads the next level
	public EventBus ActivationTrigger;
	public EventBus CancelTrigger;
	public string NextLevel;

	private IEnumerator Start()
	{
		yield return new WaitUntil(
			() => PlayerInventory.Instance != null
			      && LoadTriggers.All(trigger => PlayerInventory.Instance.HasItem(trigger))
		);

		AsyncOperation loadOp = SceneManager.LoadSceneAsync(NextLevel, LoadSceneMode.Additive);
		loadOp.allowSceneActivation = false;

		var activated = false;
		var cancelled = false;
		ActivationTrigger.OnTriggered += HandleActivationTrigger;
		CancelTrigger.OnTriggered += HandleCancelTrigger;

		void HandleActivationTrigger()
		{
			ActivationTrigger.OnTriggered -= HandleActivationTrigger;
			activated = true;
		}

		void HandleCancelTrigger()
		{
			CancelTrigger.OnTriggered -= HandleCancelTrigger;
			cancelled = true;
		}

		yield return new WaitUntil(() => activated || cancelled);

		loadOp.allowSceneActivation = true;
		SceneManager.sceneLoaded += HandleSceneLoaded;

		void HandleSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			if (scene.name != NextLevel) return;
			
			SceneManager.sceneLoaded -= HandleSceneLoaded;

			if (cancelled)
			{
				SceneManager.UnloadSceneAsync(scene);
			}
			else
			{
				SceneManager.SetActiveScene(scene);
				foreach (GameObject obj in GameObject.FindGameObjectsWithTag("LevelEntrance"))
				{
					obj.SetActive(false);
				}
			}
		}
	}
}