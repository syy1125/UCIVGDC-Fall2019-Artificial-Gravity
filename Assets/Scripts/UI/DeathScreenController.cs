using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreenController : MonoBehaviour
{
	[Header("References")]
	public Button RespawnButton;

	[Header("Config")]
	public float FadeTime;

	private AsyncOperation _respawnOp;
	
	private IEnumerator Start()
	{
		yield return new WaitUntil(() => Player.Dead);

		var group = GetComponent<CanvasGroup>();
		group.interactable = true;
		group.blocksRaycasts = true;

		_respawnOp = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
		_respawnOp.allowSceneActivation = false;
		RespawnButton.onClick.AddListener(Respawn);
		
		float startTime = Time.time;
		while (Time.time - startTime < FadeTime)
		{
			group.alpha = (Time.time - startTime) / FadeTime;
			yield return null;
		}
		group.alpha = 1;

		RespawnButton.gameObject.SetActive(true);
	}

	private void Respawn()
	{
		_respawnOp.allowSceneActivation = true;
	}
}
