using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreenController : MonoBehaviour
{
	[Header("References")]
	public GameObject Player;
	public Button RespawnButton;

	[Header("Config")]
	public float FadeTime;

	private AsyncOperation _respawnOp;
	
	private IEnumerator Start()
	{
		var state = Player.GetComponent<PlayerState>();
		yield return new WaitUntil(() => state.isDead());

		// Detach camera from player to avoid rendering cutting off at death
		var playerCamera = Player.GetComponentInChildren<Camera>();
		playerCamera.transform.SetParent(null);
		playerCamera.GetComponent<PlayerLook>().enabled = false;
		Player.SetActive(false);
		
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
