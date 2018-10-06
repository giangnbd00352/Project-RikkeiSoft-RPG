using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {

	[SerializeField]
	private Item item;

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.CompareTag("Player"))
		{
			Debug.Log("Pick up: " + item.name);
			Inventory.instance.Add(item);
			Destroy(this.gameObject);
		}
	}
}
