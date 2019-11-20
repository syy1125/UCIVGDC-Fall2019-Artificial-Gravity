using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
	// Start is called before the first frame update
	private PlayerInventory Inventory => Player.Instance == null ? null : Player.Instance.Inventory;
	private Image[] InventorySlots;
	public Sprite EmptySprite;

	void Start()
	{
		InventorySlots = GetChildren();
	}

	// Update is called once per frame
	void Update()
	{
		UpdateInventory();
	}

	void UpdateInventory()
	{
		for (int i = 0; i < InventorySlots.Length; i++)
		{
			Sprite sprite = Inventory != null ? Inventory.GetSprite(i) : null;
			if (sprite == null)
			{
				InventorySlots[i].sprite = EmptySprite;
			}
			else
			{
				InventorySlots[i].sprite = Inventory.GetSprite(i);
			}
		}
	}

	private Image[] GetChildren()
	{
		List<Image> imageList = new List<Image>();
		foreach (Transform child in transform)
		{
			imageList.Add(child.GetComponent<Image>());
		}

		return imageList.ToArray();
	}
}