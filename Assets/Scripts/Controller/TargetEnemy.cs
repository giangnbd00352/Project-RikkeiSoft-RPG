using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEnemy : MonoBehaviour {
	Collider[] resultTarget =new Collider[34];
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// if(Physics.OverlapBoxNonAlloc(5 * transform.forward + transform.position, new Vector3(5, 5, 2.5f), resultTarget,Quaternion.identity, 8,QueryTriggerInteraction.Ignore ) >0)
		// {
		// 	Debug.Log(resultTarget.Length);
		// }
	}


	void OnDrawGizmos()
	{
		// Gizmos.color = Color.red;
		// Gizmos.DrawWireCube(transform.position,new Vector3(1,5,5));
	}
}
