using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludCanhion : MonoBehaviour {

	public int salud = 100; //Vide de los enemigos
	public int enemyValue = 200;//Los puntos que te da un enemigo.


	public GameObject deathEffect; 
	public GameObject particulaHumo;
	AudioSource sound;
	public AudioClip destroyedFX;
	private Rigidbody2D rb2d;

	SpriteRenderer SpriteRenderer;
	public Sprite damageCanhion;

	[HideInInspector]
	public bool enemyDead = false;




	//GameObject mainCamera;

	StatsManager stats;  //Esto nos permite ver la puntuación en el juego.


	void Start () {

		//		sound = GameObject.FindGameObjectWithTag ("Effects").GetComponent<AudioSource>(); 
		stats = GameObject.FindGameObjectWithTag ("GameController").GetComponent<StatsManager>();
		SpriteRenderer = GetComponent<SpriteRenderer> ();
		particulaHumo.gameObject.SetActive (false);
		//stats = GameObject.FindGameObjectWithTag ("GameController").GetComponent<StatsManager>();
		//mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
	}

	//----LO QUE VIENE AHORA ES PARA HACERLE PUPA AL ENEMIGO---//
	/*
	private void OnTriggerEnter2D(Collider2D col){
	
		if (col.CompareTag ("bullet")) {
			health -= col.GetComponent<arma01>().damageValue;
			if (health <= 0) {
			
				Instantiate (enemyExplosion, transform.position, Quaternion.identity);
				sound.PlayOneShot (destroyedFX);

				stats.UpdateScore (enemyValue);

				Destroy(gameObject);
			}
		
		}
	
	}*/

	public void TakeDamage (int damage){

		salud -= damage;
		if (salud <= 0) {
			Die ();
			particulaHumo.gameObject.SetActive (true);
		}
	}

	void Die ()
	{
		if (Instantiate (deathEffect, transform.position, Quaternion.identity)) {
			//mainCamera.GetComponent<Camera_Temblor> ().ActiveShake ();
			stats.UpdateScore (enemyValue);
			Destroy (gameObject);


		}
		SpriteRenderer.sprite = damageCanhion;

		}

	}
	
