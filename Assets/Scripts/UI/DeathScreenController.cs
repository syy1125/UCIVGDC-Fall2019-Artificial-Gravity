using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = System.Diagnostics.Debug;

public class DeathScreenController : MonoBehaviour
{
	// https://docs.unity3d.com/ScriptReference/AsyncOperation-progress.html
	private const float SCENE_ACTIVATION_READY_PROGRESS_THRESHOLD = 0.9f;

	[Header("References")]
	public Button RespawnButton;
	public EventBus PlayerDeathEvent;
	public PersistentGameplayScenes PersistentScenes;

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

		// Move camera (and therefore audio listener) to a sepa
		Scene tempScene = SceneManager.CreateScene("Temporary Scene");
		Camera mainCamera = Camera.main;
		Debug.Assert(mainCamera != null, "Camera.main != null");
		SceneManager.MoveGameObjectToScene(mainCamera.gameObject, tempScene);
		
		foreach (GameObject root in SceneManager.GetActiveScene().GetRootGameObjects())
		{
			Destroy(root);
		}

		ForEachNonPersistentScene(
			scene =>
			{
				if (scene == tempScene) return;
				
				foreach (GameObject root in scene.GetRootGameObjects())
				{
					Destroy(root);
				}
			}
		);
		
		group.interactable = true;
		RespawnButton.onClick.AddListener(Respawn);

		void Respawn()
		{
			RespawnButton.onClick.RemoveListener(Respawn);

			ForEachNonPersistentScene(
				scene => SceneManager.UnloadSceneAsync(scene)
			);

			SceneManager.sceneLoaded += SwitchActiveScene;
			loadOp.allowSceneActivation = true;

			group.interactable = false;
			group.blocksRaycasts = false;
			group.alpha = 0;
		}

		void SwitchActiveScene(Scene scene, LoadSceneMode mode)
		{
			if (scene.name != SceneManager.GetActiveScene().name) return;

			SceneManager.sceneLoaded -= SwitchActiveScene;
			SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
			SceneManager.SetActiveScene(scene);
		}
	}

	private void ForEachNonPersistentScene(Action<Scene> action)
	{
		for (int i = 0; i < SceneManager.sceneCount; i++)
		{
			Scene scene = SceneManager.GetSceneAt(i);
			if (SceneManager.GetActiveScene().Equals(scene)) continue;
			if (!scene.isLoaded) continue;
			if (PersistentScenes.SceneNames.Contains(scene.name)) continue;

			action(scene);
		}
	}
}