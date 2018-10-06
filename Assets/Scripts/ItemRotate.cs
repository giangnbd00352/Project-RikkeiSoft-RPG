using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotate : MonoBehaviour {

	public float rotate;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, rotate * Time.deltaTime);
	}
}
