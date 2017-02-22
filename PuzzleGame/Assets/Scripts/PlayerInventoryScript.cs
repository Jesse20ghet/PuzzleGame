using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Classes.InvetoryItems.Interface;

public static class PlayerInventoryScript
{
	private static List<IInventoryItem> inventoryItems;

	public static void AddInventoryItem(IInventoryItem inventoryItemToAdd)
	{
		if (inventoryItems.Contains(inventoryItemToAdd))
			return;

		inventoryItems.Add(inventoryItemToAdd);
	}

	public static void RemoveInventoryItem(IInventoryItem inventoryItemToRemove)
	{
		if (!inventoryItems.Contains(inventoryItemToRemove))
			return;

		inventoryItems.Remove(inventoryItemToRemove);
	}
}
