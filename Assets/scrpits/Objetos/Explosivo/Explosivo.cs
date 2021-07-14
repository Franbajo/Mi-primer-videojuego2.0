using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosivo : MonoBehaviour {

	public float salud;
	public GameObject explosion;

	GameObject mainCamera;
	public GameObject explosionRange;

	public float lifetime = 0.5f;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
	}



	public void TakeDamage (int damage){

		salud -= damage;
		if (salud <= 0) {
			Die ();
			}
		}

	void Die ()
	{

		Instantiate (explosion, transform.position, Quaternion.identity);
		GetComponent<SpriteRenderer> ().enabled = false; 
		GetComponent<BoxCollider2D> ().enabled = false;

		/* Aquí se activa el script que  Movimiento de la Cámara */
		mainCamera.GetComponent<Camera_Temblor> ().ActiveShake ();


		explosionRange.SetActive(true);

		Destroy (gameObject, lifetime);


	}

}