using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreenController : MonoBehaviour
{
	// https://docs.unity3d.com/ScriptReference/AsyncOperation-progress.html
	private const float SCENE_ACTIVATION_READY_PROGRESS_THRESHOLD = 0.9f;

	[Header("References")]
	public Button RespawnButton;
	public EventBus PlayerDeathEvent;

	[Header("Config")]
	public float FadeTime;

	private void OnEnable()
	{
		PlayerDeathEvent.OnTriggered += HandlePlayerKilled;
	}

	private void OnDisable()
	{
		PlayerDeathEvent.OnTriggered -= HandlePlayerKilled;
	}

	private void HandlePlayerKilled()
	{
		StartCoroutine(DoHandlePlayerKilled());
	}

	private IEnumerator DoHandlePlayerKilled()
	{
		yield return new WaitUntil(() => Player.Dead);

		var group = GetComponent<CanvasGroup>();
		group.blocksRaycasts = true;

		AsyncOperation loadOp = SceneManager.LoadSceneAsync(
			SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Additive
		);
		loadOp.allowSceneActivation = false;

		float startTime = Time.time;
		while (Time.time - startTime < FadeTime)
		{
			group.alpha = (Time.time - startTime) / FadeTime;
			yield return null;
		}

		group.alpha = 1;

		yield return new WaitUntil(() => loadOp.progress >= SCENE_ACTIVATION_READY_PROGRESS_THRESHOLD);

		foreach (GameObject root in SceneManager.GetActiveScene().GetRootGameObjects())
		{
			Destroy(root);
		}

		group.interactable = true;
		RespawnButton.onClick.AddListener(Respawn);

		void Respawn()
		{
			RespawnButton.onClick.RemoveListener(Respawn);

			SceneManager.sceneLoaded += SwitchActiveScene;
			loadOp.allowSceneActivation = true;
			SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

			group.interactable = false;
			group.blocksRaycasts = false;
			group.alpha = 0;
		}

		void SwitchActiveScene(Scene scene, LoadSceneMode mode)
		{
			if (scene.name != SceneManager.GetActiveScene().name) return;
			
			SceneManager.sceneLoaded -= SwitchActiveScene;
			SceneManager.SetActiveScene(scene);
		}
	}
}