using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter(Collision collisionInfo)
	{
		if (collisionInfo.transform.CompareTag("Sword"))
		{
			Debug.Log("Hit !!");
		}
	}
}
