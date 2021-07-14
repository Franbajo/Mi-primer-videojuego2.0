using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner2 : MonoBehaviour {

	public float triggerCube; //Esto va a ser el Radio de detección que tendrá nuestra puerta una vez se averque el personaje a la puerta.
	public LayerMask target; //El Layer Mask se utiliza para detectar el target del jugador, player1.


	bool targetLocated = false;//Esto sirve para si el jugador es detectado.



	public GameObject enemy;
	public float spawnRate = 1;
	public int maxEnemySpawned = 10;
	float count;

	private Rigidbody2D rb2d;

	GameObject mainCamera;

	StatsManager stats;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	


		stats = GameObject.FindGameObjectWithTag ("GameController").GetComponent<StatsManager> ();
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");

	}

	private void FixedUpdate (){      //Esta función se realiza para realizar esa constante revisión dentro del juego.

		targetLocated = Physics2D.OverlapCircle (transform.position, triggerCube, target); //Esto es el ciruclo, su localización, radio y a quién detecta por el target.
	}


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
		

	private void OnDrawGizmos(){   //Función que nos permite hacer visible un círculo en este caso de nuestra puerta de enemigos en nuestro editor de Unity.

		Gizmos.color = Color.red; //color de nuestro círculo.
		Gizmos.DrawWireSphere(transform.position,triggerCube); //Le estamos diciendo que dibuje un circulo transparente, solo se ve el borde, en la posición de la puerta y el tamaño del radio.

	}

}

