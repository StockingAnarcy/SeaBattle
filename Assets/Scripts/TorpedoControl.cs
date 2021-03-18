using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoControl : MonoBehaviour {

	public float moveSpeed = 2f;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.y > 7)
			Destroy (gameObject);
	}


	void FixedUpdate () {
		rb.velocity = new Vector2 (0, moveSpeed);
	}
}
