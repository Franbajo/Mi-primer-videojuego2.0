using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraposition2 : MonoBehaviour {

	public float triggerCircle;
	public LayerMask target; //El Layer Mask se utiliza para detectar el target del jugador, player1.

	bool targetLocated = false;//Esto sirve para si el jugador es detectado.

	private Rigidbody2D rb2d;

	GameObject EndStage;
	//public GameObject MascaraFinal;

	public float posicionInicialX;//Aquí tendríamos que copiar la posición inicial en X que le asignamos a la camara al empezar
	public float posicionInicialy;//Aquí tendríamos que copiar la posición inicial en Y que le asignamos a la camara al empezar
	public float posicionInicialz;//Aquí tendríamos que copiar la posición inicial en Z que le asignamos a la camara al empezar
	public float Movimiento_X=0.001F; //La fuerza con la que movemos la cámara.


	saludManager salud;

	//StatsManager stats;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		//MascaraFinal.gameObject.SetActive (false);
		//stats = GameObject.FindGameObjectWithTag ("GameController").GetComponent<StatsManager> ();
		EndStage = GameObject.FindGameObjectWithTag ("endStage");
		salud = GameObject.FindGameObjectWithTag ("player1").GetComponent<saludManager>();

	}
		
	private void FixedUpdate (){      //Esta función se realiza para realizar esa constante revisión dentro del juego.

		transform.Translate (/*Time.deltaTime*/Movimiento_X, 0, 0, Camera.main.transform);   //Esto es lo que mueve a la cámara en posición X
		targetLocated = Physics2D.OverlapCircle (transform.position,triggerCircle, target); //Esto es el ciruclo, su localización, radio y a quién detecta por el target.
	}
		


	void Update () {



		if (targetLocated) {
			Debug.Log ("Deeeeeeetectado");
			Movimiento_X = 0.0f;
		//	Instantiate (MascaraFinal, transform.position, Quaternion.identity);
		}
	
		if (salud.lives==-1){
			transform.position = new Vector3 (posicionInicialX, posicionInicialy, posicionInicialz);
		}



	}
	private void OnDrawGizmos(){   //Función que nos permite hacer visible un círculo en este caso de nuestra puerta de enemigos en nuestro editor de Unity.

		Gizmos.color = Color.blue; //color de nuestro círculo.
		Gizmos.DrawWireSphere(transform.position,triggerCircle); //Le estamos diciendo que dibuje un circulo transparente, solo se ve el borde, en la posición de la puerta y el tamaño del radio.

	}





}