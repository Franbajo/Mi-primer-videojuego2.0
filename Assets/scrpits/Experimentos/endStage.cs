using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endStage : MonoBehaviour {

	public float triggerCircle; //Esto va a ser el Radio de detección que tendrá nuestra puerta una vez se averque el personaje a la puerta.
	public LayerMask target; //El Layer Mask se utiliza para detectar el target del jugador, player1.

	bool targetLocated = false;//Esto sirve para si el jugador es detectado.

	private Rigidbody2D rb2d;

	GameObject mainCamera;


	StatsManager stats;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();



		stats = GameObject.FindGameObjectWithTag ("GameController").GetComponent<StatsManager> ();
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");

	}

	private void FixedUpdate (){      //Esta función se realiza para realizar esa constante revisión dentro del juego.

		targetLocated = Physics2D.OverlapCircle (transform.position, triggerCircle, target); //Esto es el ciruclo, su localización, radio y a quién detecta por el target.
	}

	/*void Update () {
	
		if (targetLocated) {
			Debug.Log ("PROTA DETECTADO");
		}
	
	}*/



	private void OnDrawGizmos(){   //Función que nos permite hacer visible un círculo en este caso de nuestra puerta de enemigos en nuestro editor de Unity.

		Gizmos.color = Color.black; //color de nuestro círculo.
		Gizmos.DrawWireSphere(transform.position,triggerCircle); //Le estamos diciendo que dibuje un circulo transparente, solo se ve el borde, en la posición de la puerta y el tamaño del radio.

	}

}
