using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInventory : MonoBehaviour
{
	/*
	    Each string in the Inventory array is an item.
	    Items must have different names.
	 */
	private static readonly Dictionary<string, Sprite> _itemSprites = new Dictionary<string, Sprite>();
	public List<string> Inventory;

	public static void AddSprite(string name, Sprite sprite)
	{
		_itemSprites[name] = sprite;
	}

	public static Sprite GetSprite(string name)
	{
		if (_itemSprites.ContainsKey(name))
			return _itemSprites[name];
		else
			return null;
	}

	public Sprite GetSprite(int inventoryIndex)
	{
		if (inventoryIndex >= 0 && inventoryIndex < Inventory.Count)
			return GetSprite(Inventory[inventoryIndex]);
		else
			return null;
	}

	public void AddItem(string name)
	{
		Inventory.Add(name);
	}

	public void RemoveItem(string name)
	{
		Inventory.Remove(name);
	}

	public bool HasItem(string item)
	{
		return Inventory.Contains(item);
	}

	public void PrintInventory()
	{
		string result = "Inventory: ";
		for (int i = 0; i < Inventory.Count; i++)
		{
			result += Inventory[i] + ", ";
		}

		print(result);
	}
}