using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour {

	[SerializeField]
	private float _speed;

	[SerializeField]
	private float _timeval;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private Vector3 startPos;


	
	private float _time;
	private float _lifeTime;
	private bool _isMove = true;

	void Start()
	{
		_time = Time.time;
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Move(_isMove);
		_lifeTime += Time.fixedDeltaTime;
		if (_lifeTime - _time >= _timeval)
		{
			_time = Time.time;
			animator.SetBool("isDead", true);
			_isMove = false;
			StartCoroutine(HideMonster());			
		}		
	}

	IEnumerator HideMonster()
	{
		yield return new WaitForSeconds(3);
		_isMove = true;
		transform.position = startPos;
		animator.SetBool("isDead", false);
	}

	void Move(bool isMove)
	{
		if (_isMove)
			transform.Translate(transform.right * _speed * Time.deltaTime);
	}
}
