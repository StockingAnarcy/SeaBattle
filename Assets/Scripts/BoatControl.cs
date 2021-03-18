using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatControl : MonoBehaviour {

	Rigidbody2D rb;
	float moveSpeed;
	public GameObject explosion;
	Vector3 localScale;
	bool facingRight = true, moveAllowed = true;
	SpriteRenderer rend;
	Animator anim;

	// Use this for initialization
	void Start () {
		localScale = transform.localScale;
		rb = GetComponent<Rigidbody2D> ();
		rend = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
		moveSpeed = Random.Range (1f, 3f);
		FacingCheck ();
		SetOrderInLayer ();
	}

	void Update ()
	{
		if (transform.position.x < -13f || transform.position.x > 13f)
			Destroy (gameObject);
		}

	void FixedUpdate () {
		if (moveAllowed)
			MoveShip ();
		else
			rb.velocity = Vector2.zero;
	}

	void MoveShip ()
	{
		if (!facingRight)
			rb.velocity = new Vector2 (moveSpeed, 0);
		else if (facingRight)
			rb.velocity = new Vector2 (-moveSpeed, 0);
	}

	void FacingCheck()
	{
		if (transform.position.x < 0)
			facingRight = false;
		else
			facingRight = true;
		if (((facingRight) && (localScale.x < 0)) || ((!facingRight)
			&& (localScale.x > 0)))
			localScale.x *= -1;
		transform.localScale = localScale;
	}

	void SetOrderInLayer()
	{
		if (transform.position.y == 4.25f)
			rend.sortingOrder = 0;
		if (transform.position.y == 2.25f)
			rend.sortingOrder = 0;
		if (transform.position.y == -0.15f)
			rend.sortingOrder = 0;
		if (transform.position.y == -2.25f)
			rend.sortingOrder = 0;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag.Equals ("Torpedo")) {
			Vector2 explPos = new Vector2 (col.gameObject.transform.position.x,
											col.gameObject.transform.position.y + 1);
			HitsCounterControl.hitsCounter += 1;
			Instantiate (explosion, explPos, Quaternion.identity);
			Destroy (col.gameObject);
			moveAllowed = false;
			anim.enabled = false;
			gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			StartCoroutine ("Sinking");
		}
	}

	IEnumerator Sinking()
	{		
		for (int i = 0; i <= 90; i++) {
			transform.rotation = Quaternion.Euler(0,0,i);
			transform.position = new Vector2 (transform.position.x,
												transform.position.y - 0.05f);
			yield return new WaitForSeconds (Time.deltaTime*5f);
		}
		Destroy (gameObject);
	}

}
