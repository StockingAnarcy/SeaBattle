using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInTime : MonoBehaviour {

	public float destroyTime = 0.5f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, destroyTime);
	}

}
