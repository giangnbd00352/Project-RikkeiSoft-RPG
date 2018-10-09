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
				content.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = items[i].icon;
				content.transform.GetChild(i).GetChild(0).transform.gameObject.SetActive(true);
				content.transform.GetChild(i).GetChild(1).transform.gameObject.SetActive(true);
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
	public void Remove (Item item)
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
				content.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = items[i].icon;
				content.transform.GetChild(i).GetChild(0).transform.gameObject.SetActive(true);
				content.transform.GetChild(i).GetChild(1).transform.gameObject.SetActive(true);
			}	
		}


	}

	public void exitInventory()
	{
		 InventoryUI.SetActive(false);
	}
}
