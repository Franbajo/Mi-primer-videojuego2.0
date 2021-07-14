using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject plataformainicial; //Aquí colocamos la plataforma con la que iniciamos.
	public GameObject destroce; 
	public GameObject particle;
	public GameObject particle2;


	public float triggerRadius; //Esto va a ser el Radio de detección que tendrá nuestra puerta una vez se averque el personaje a la puerta.
	public LayerMask target; //El Layer Mask se utiliza para detectar el target del jugador, player1.


	bool targetLocated = false;//Esto sirve para si el jugador es detectado.

	AudioSource doorAudio;
	public AudioClip alarmSFX;
	bool alarmActive = false;

	public GameObject enemy;
	public float spawnRate = 1;
	public int maxEnemySpawned = 10;
	float count;


	public int salud = 100;
	public int value = 400; //lo que vale en puntos destruir la puerta
	private Rigidbody2D rb2d;

	GameObject mainCamera;


	StatsManager stats;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		plataformainicial.gameObject.SetActive (true);
		destroce.gameObject.SetActive (false);
		particle.gameObject.SetActive (false);
		particle2.gameObject.SetActive (false);


		doorAudio = GetComponent<AudioSource> ();
		stats = GameObject.FindGameObjectWithTag ("GameController").GetComponent<StatsManager> ();
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");

	}

	private void FixedUpdate (){      //Esta función se realiza para realizar esa constante revisión dentro del juego.
	
		targetLocated = Physics2D.OverlapCircle (transform.position, triggerRadius, target); //Esto es el ciruclo, su localización, radio y a quién detecta por el target.
		if(targetLocated){

			doorAudio.clip = alarmSFX;
				doorAudio.loop = true;
			if (!alarmActive){

				doorAudio.Play();
				alarmActive = true;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (targetLocated) {
			count += Time.deltaTime;

			if (count >= spawnRate && maxEnemySpawned > 0) {
				Instantiate (enemy, transform.position, Quaternion.identity);

				maxEnemySpawned--;

				count = 0;
			
			}
		}

	}

	public void TakeDamage (int damage){


		salud -= damage;

		if (salud <= 1) {
			plataformainicial.gameObject.SetActive (false);
			destroce.gameObject.SetActive (true); //Y aquí una vez llegado a 0 de vida aparece el gráfico de destroce.
			//Instantiate (deathEffect, transform.position, Quaternion.identity);
			//deathEffect.gameObject.SetActive (true);
			particle.gameObject.SetActive (true);
			particle2.gameObject.SetActive (true);
			maxEnemySpawned = 0;
			GetComponent<BoxCollider2D> ().enabled = false; //Con esto podemos ignorar el Boxcollider
			stats.UpdateScore(value);
			doorAudio.Stop();
			mainCamera.GetComponent<Camera_Temblor> ().ActiveShake ();
		}
	}


	private void OnDrawGizmos(){   //Función que nos permite hacer visible un círculo en este caso de nuestra puerta de enemigos en nuestro editor de Unity.
	
		Gizmos.color = Color.red; //color de nuestro círculo.
		Gizmos.DrawWireSphere(transform.position, triggerRadius); //Le estamos diciendo que dibuje un circulo transparente, solo se ve el borde, en la posición de la puerta y el tamaño del radio.
	
	}

}
