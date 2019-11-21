using System.Collections;
using UnityEngine;

public class Story1 : MonoBehaviour
{
	[TextArea]
	public string InitialObjective;
	public PopupBox PopupAfterRespawn;
	public PopupBox FinalPopup;
	[TextArea]
	public string FinalObjective;
	
	private IEnumerator Start()
	{
		foreach (Transform child in Player.Instance.transform)
		{
			if (child.CompareTag("PlayerAbilities"))
			{
				child.gameObject.SetActive(false);
			}
		}
		
		ObjectiveUI.Instance.SetObjective(InitialObjective);
		
		yield return new WaitUntil(() => Player.Dead);
		yield return new WaitWhile(() => Player.Dead);
		
		PopupAfterRespawn.OnActivate();
		
		yield return new WaitUntil(() => FinalPopup.State == 1);
		yield return new WaitUntil(() => FinalPopup.State == 0);
		
		ObjectiveUI.Instance.SetObjective(FinalObjective);
	}
}
