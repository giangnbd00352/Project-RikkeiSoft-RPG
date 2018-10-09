using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHit : MonoBehaviour {

	[SerializeField]
	Image _currentHealth;

	[SerializeField]
	GameObject dropItem;

	private void Start()
	{
	}

	void Update()
	{
		if(_currentHealth.fillAmount == 0)
		{
			gameObject.SetActive(false);
			dropItem.SetActive(true);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.CompareTag("Sword"))
		{
			Debug.Log("Hit");
			other.enabled = false;
			_currentHealth.fillAmount -= 0.1f;
		}
	}
}
