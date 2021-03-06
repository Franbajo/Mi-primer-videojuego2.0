using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public int salud = 100; //Vide de los enemigos
	public int enemyValue = 200;//Los puntos que te da un enemigo.


	public GameObject deathEffect; 
	AudioSource sound;
	public AudioClip destroyedFX;
	private Rigidbody2D rb2d;

	[HideInInspector]
	public bool enemyDead = false;

	StatsManager stats;  //Esto nos permite ver la puntuación en el juego.

	public bool hasParent = false;  //Para destruir todos los enemigos que tiene un Objeto Padre como el Pajaro Loco Rosa.
	public GameObject parentObject;

	public int damageValue = 1;


	void Start () {

	//sound = GameObject.FindGameObjectWithTag ("Effects").GetComponent<AudioSource>(); 
   	stats = GameObject.FindGameObjectWithTag ("GameController").GetComponent<StatsManager>();
		
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
		}
	}

	void Die ()
	{

		Instantiate (deathEffect, transform.position, Quaternion.identity);

		if (hasParent) {

			Destroy (parentObject); 
		} else {
			stats.UpdateScore (enemyValue);
			Destroy (gameObject);
		}


	}

	void OnTriggerEnter2D (Collider2D col)
	{
		saludManager Health = col.GetComponent<saludManager>();
		if (Health != null) 
		{
			Health.TakeDamage(damageValue);

		} 
	}
		
}