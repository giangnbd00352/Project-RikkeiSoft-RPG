using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour {

	[SerializeField]
	private GameObject target;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private float _maxHeal;

	[SerializeField]
	private Image _currentHeal;

	bool isAlive;
	// Use this for initialization
	void Start () {
		isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isAlive)
		{
			Vector3 directionToFace = target.transform.position - transform.position;
			if (distanceTarget() <= 30 && distanceTarget() > 10)
			{
				animator.SetBool("isTarget", true);
				transform.rotation = Quaternion.LookRotation(directionToFace);
			} else if (distanceTarget() > 30)
				animator.SetBool("isTarget", false);

			if (distanceTarget() < 10)
			{
				animator.SetBool("isAttack", true);
				transform.rotation = Quaternion.LookRotation(directionToFace);
			} else if (distanceTarget() > 10)
				animator.SetBool("isAttack", false);
		}
	}

	float distanceTarget()
	{
		 return (transform.position - target.transform.position).magnitude;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.CompareTag("Sword"))
		{
			other.enabled = false;
			if (_maxHeal > 0)
			{
				_maxHeal -= 50f;
				_currentHeal.transform.GetChild(0).GetComponent<Image>().fillAmount = _maxHeal/1000;
			} else {
				animator.SetBool("isDead", true);
				isAlive = false;
				_currentHeal.enabled = false;
			}
		}
	}

}
