using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	private float _speed;

	[SerializeField]
	private float _lookSensitivity;

	[SerializeField]
	private Rigidbody rb;
	[SerializeField]
	private Animator anim;

	private GameObject quest;

	void Start()
	{
		quest = GameObject.Find("Quest");
	}

	void FixedUpdate()
	{
		Movement();
		PlayerRotate();
		MoveByKey();
		shortCut();
	}

	void Movement() 
	{
		float _xMov = Input.GetAxis("Horizontal");
		float _zMov = Input.GetAxis("Vertical");

		if ( _xMov != 0 || _zMov != 0 || _zMov != 0 &&  _xMov != 0)
		{
			anim.SetBool("isWalk", true);
			Vector3 _moveToX = transform.right * _xMov;
			Vector3 _moveToZ = transform.forward * _zMov;

			Vector3 _velocity = (_moveToX + _moveToZ).normalized * _speed;
			rb.MovePosition(rb.position + _velocity * Time.deltaTime );
		} else 
			anim.SetBool("isWalk", false);

	}

	void PlayerRotate() 
	{
		float _yRot = Input.GetAxisRaw("Mouse X");

		Vector3 _rotation = new Vector3 (0, _yRot , 0) * _lookSensitivity;

		rb.MoveRotation(rb.rotation * Quaternion.Euler(_rotation));		
	}

	void MoveByKey()
	{
		//Run
		if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
		{
			_speed = 10;
			anim.SetBool("isRun", true);
		} else
		{
			_speed = 2;
			anim.SetBool("isRun", false);
		}
			

		//Jump
		if (Input.GetButtonDown("Jump"))
		{
			anim.SetBool("isJump", true);
		} else
			anim.SetBool("isJump", false);	

		//Attack
		if (Input.GetKey(KeyCode.F))
		{
			anim.SetBool("isAttack", true);
		} else
			anim.SetBool("isAttack", false);

		//Kick
		if (Input.GetKey(KeyCode.C))
		{
			anim.SetBool("isKick", true);
		} else
			anim.SetBool("isKick", false);	
	}


	void shortCut()
	{
		if (Input.GetKeyDown(KeyCode.B))
		{
			Inventory.instance.openInventory();
		}

		if (Input.GetKeyDown(KeyCode.Q))
		{
			quest.SetActive(true);
			quest.GetComponent<Animator>().Play("letterShow");
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Inventory.instance.exitInventory();
			quest.GetComponent<Animator>().Play("letterHide");
		}
	}
}
