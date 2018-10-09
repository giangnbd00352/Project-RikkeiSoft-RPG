using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	[SerializeField]
	private Rigidbody rigid;

	[SerializeField]
	private float _force;

	bool _stopVel ;

	private Vector3 _firstAngles;

	public Transform startPos;

	

	// Use this for initialization
	void Start () {
		_firstAngles = transform.eulerAngles;
		rigid.AddForce(transform.forward * _force);
	}
	
	// Update is called once per frame
	void Update () {
		if(!_stopVel)
			transform.rotation = Quaternion.LookRotation(rigid.velocity);
	}

	void OnCollisionEnter(Collision collisionInfo)
	{
		if (collisionInfo.transform.CompareTag("Ground"))
		{
			_stopVel = true;
			StartCoroutine(Enable());
		}
	}

	public void Disable()
	{
		gameObject.SetActive(false);
	}

	public IEnumerator Enable() 
	{
		yield return new WaitForSeconds(.5f);
		gameObject.SetActive(true);
		_stopVel = false;
		transform.eulerAngles = _firstAngles + new Vector3(Random.Range(2, 10), 0, 0);
		rigid.AddForce(transform.forward * (_force + Random.Range(-100, 200)));
		transform.position = startPos.position;
	}

}
