using System.Collections;
using System.Collections.Generic;
using UnityEngine;
	
[CreateAssetMenu(fileName="New Item", menuName="Inventory/Item")]
public class Item : ScriptableObject {

	[SerializeField]
	new protected internal string name;
	[SerializeField]
	protected internal Sprite icon = null;
}
