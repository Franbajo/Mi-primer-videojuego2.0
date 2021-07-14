using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaFalling : MonoBehaviour {

	public float fallDelay = 1f;
	public float RespawnDelay = 2f;
	private Rigidbody2D rb2d;
	private BoxCollider2D bc2d;
	private Vector3 start;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		bc2d = GetComponent<BoxCollider2D> ();
		start = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.CompareTag ("player1")) {
			Invoke ("Fall", fallDelay);
			Invoke ("Respawn", fallDelay + RespawnDelay);
		}
	
	}
	void Fall () {
		rb2d.isKinematic = false;
		bc2d.isTrigger = true;
	}
	void Respawn (){
		transform.position = start;
		rb2d.isKinematic = true;
		rb2d.velocity = Vector3.zero;
		bc2d.isTrigger = false;
	}
}
