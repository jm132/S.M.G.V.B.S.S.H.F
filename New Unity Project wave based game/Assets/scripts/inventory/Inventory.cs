using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {

	private List<InventoryItem> items;
	private int MAX_ITEMS = 5;

    private int MAX_WEIGHT = 4;
    private int currentWeight = 0;

	public Inventory()
	{
		items = new List<InventoryItem>();
	}

	public bool addItem(GameObject obj)
	{
        if (currentWeight + obj.GetComponent<InventoryItem>().weight > MAX_WEIGHT) return false;

		if (items.Count < MAX_ITEMS)
		{
			items.Add(obj.GetComponent<InventoryItem>());
            currentWeight = currentWeight + obj.GetComponent<InventoryItem>().weight;
			return true;
		}
		else return false;
	}

	public GameObject removeItem(int index)
	{
		if (items.Count == 0) return null;
			
		InventoryItem item = items[index];
		items.RemoveAt(index);
        currentWeight = currentWeight - item.GetComponent<InventoryItem>().weight;
        return item.gameObject;
	} 

	public InventoryItem[] removeAllItems()
	{
		InventoryItem[] allItems = items.ToArray();
		items.Clear();
        currentWeight = 0;
		return allItems;
	}

	public Sprite[] getAllInventorySprites()
	{
		InventoryItem[] allItems = items.ToArray();
		Sprite[] sprites = new Sprite[allItems.Length];

		for (int i=0; i<allItems.Length; i++)
		{
			sprites[i] = allItems[i].GetComponent<InventoryItem>().sprite;
		}

		return sprites;
	}
    public bool hasAmmo(string gun)
    {
        if (gun == "ar")
        {
            for(int i=0; i<items.Count; i++) 
            {
                if (items[i] is asolt_riifel_ammo)
                    {
                        items.RemoveAt(i);
                        return true;
                    }
            }
        }



        return false;
    }
}
