using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedCoin : MonoBehaviour {

	public float jumpForce;
	Rigidbody2D rb;

	public float lifetime;

	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = Vector2.up * jumpForce;
		Destroy (gameObject, lifetime);

		
	}
	

}
