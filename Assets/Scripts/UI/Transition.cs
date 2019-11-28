using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
	public PersistentGameplayScenes GameplayScenes;
	// Start is called before the first frame update
	public float TransitionDuration;
	private Image Overlay;
	public bool TransitionIntoLevel = false;
	public static Transition Instance;

	void Awake()
	{
		Instance = this;
		Overlay = GetComponent<Image>();
		if (TransitionIntoLevel)
		{
			StartCoroutine(LoadScene("", true));
		}
	}

	public static IEnumerator LoadLevel(string levelName)
	{
		Instance.Overlay.enabled = true;
		Instance.Overlay.CrossFadeAlpha(0, 0, true);
		Instance.Overlay.CrossFadeAlpha(1, Instance.TransitionDuration, true);
		yield return new WaitForSecondsRealtime(Instance.TransitionDuration);

		// Dont destroy the canvas until loading is done
		GameObject transitionCanvas = Instance.transform.parent.gameObject;
		DontDestroyOnLoad(transitionCanvas);
		
		yield return SceneManager.LoadSceneAsync(levelName);
		foreach (string sceneName in Instance.GameplayScenes.SceneNames)
		{
			yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
		}
		
		Destroy(transitionCanvas);
	}

	public static IEnumerator LoadScene(string sceneName, bool reversed)
	{
		if (Instance == null)
		{
			if (sceneName != "")
				SceneManager.LoadScene(sceneName);
			yield break;
		}

		Image Overlay = Instance.Overlay;
		float Duration = Instance.TransitionDuration;
		Overlay.enabled = true;
		float timer = 0;
		while (timer < Duration)
		{
			timer += Time.deltaTime;
			if (!reversed)
			{
				//transparent to opaque
				Color c = Overlay.color;
				Overlay.color = new Color(c.r, c.g, c.b, timer / Duration);
			}
			else
			{
				//opaque to transparent
				Color c = Overlay.color;
				Overlay.color = new Color(c.r, c.g, c.b, 1 - (timer / Duration));
			}

			yield return new WaitForEndOfFrame();
		}

		if (sceneName != "")
		{
			SceneManager.LoadScene(sceneName);
		}
	}
}