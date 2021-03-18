using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineControl : MonoBehaviour {

	float dirX;
	public float moveSpeed = 5f;
	Rigidbody2D rb;
	public GameObject torpedo;
	float nextFire, fireRate = 2f;

	// Use this for initialization
	void Start () {
		nextFire = Time.time;
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		dirX = Input.GetAxis ("Horizontal");

		if (Input.GetButtonDown ("Fire1")) {
			LaunchTorpedo ();
		}
		
		transform.position = new Vector2 (Mathf.Clamp (transform.position.x, -7, 7),
			transform.position.y);
	}

	void FixedUpdate()
	{
		rb.velocity = new Vector2 (dirX * moveSpeed, 0);
	}

	void LaunchTorpedo()
	{
		if (Time.time >= nextFire) {
			Instantiate (torpedo, transform.position, Quaternion.identity);
			nextFire = Time.time + fireRate;
		}
	}

}
