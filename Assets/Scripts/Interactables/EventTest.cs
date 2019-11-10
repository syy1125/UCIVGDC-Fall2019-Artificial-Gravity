using UnityEngine;

public class EventTest : PuzzleElement
{
	// Update is called once per frame
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			ToggleOthers();
		}
	}
}