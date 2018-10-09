using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPool : MonoBehaviour {

	[SerializeField]
	private GameObject prefabs;

	[SerializeField]
	private Vector3 startPos;

	private Arrow[] _arrows;

	// Use this for initialization
	void Start () {
		_arrows = new Arrow[5];
		for(int j = 0; j < _arrows.Length; j++)
		{
			GameObject arrow = Instantiate(prefabs);
			_arrows[j] = arrow.GetComponent<Arrow>();
			_arrows[j].Disable();
		}
	}
	
	// Update is called once per frame
	void Update () {
		Fire();
	}

	void Fire()
    {
        Arrow arrow = GetArrow();
        if (arrow != null)
        {
            arrow.Enable();
        }
    }

    Arrow GetArrow()
    {
        for (int i = 0; i < _arrows.Length; i++)
        {
            if (!_arrows[i].gameObject.activeSelf)
                return _arrows[i];
        }

        return null;
    }
}
