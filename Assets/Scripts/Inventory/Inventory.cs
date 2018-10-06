using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public static Inventory instance;

	[SerializeField]
	private GameObject content;
	[SerializeField]
	private GameObject InventoryUI;
	[SerializeField]
	private int space = 10;

	void Awake()
	{
		instance = this;
	}

	void Update() 
	{
		if (items.Count > 0)
		{
			for(int i = 0; i < items.Count; i++)
			{
				content.transform.GetChild(i).GetComponent<Image>().sprite = items[i].icon;
			}	
		}
	}

	[SerializeField]
	private List<Item> items = new List<Item>();

	[SerializeField]
	protected internal void Add (Item item)
	{

		if (items.Count >= space)
		{
			Debug.Log("Not enough room");
			return;
		} 	else 		
			items.Add(item);		
	}

	[SerializeField]
	protected internal void Remove (Item item)
	{
		items.Remove(item);
	}

	public void openInventory() 
	{
		InventoryUI.SetActive(true);
		if (items.Count > 0)
		{
			for(int i = 0; i < items.Count; i++)
			{
				content.transform.GetChild(i).GetComponent<Image>().sprite = items[i].icon;
			}	
		}
	}

	public void exitInventory()
	{
		 InventoryUI.SetActive(false);
	}
}
