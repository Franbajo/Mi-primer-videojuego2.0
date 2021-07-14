using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBullet : MonoBehaviour {

	[HideInInspector]
	public Vector3 targetLocation;


	public float speed;
	//public float lifetime;

	public int damage=40;

	/*Animator bAnim;
	public AnimationClip explosionClip;*/


	public Rigidbody2D rb;
	public GameObject chifarrazo;

	// Use this for initialization
	void Start () {

		Destroy (gameObject, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		//Este código es para localizar al player y disparar justo a la dirección donde se encuetra el player.
		transform.position = Vector3.MoveTowards (transform.position, targetLocation, speed * Time.deltaTime);
		//Lo que viene ahora es para resolver un bug, y es que si el player saltaba y el bullet llegaba a la posición que habia grabado del player, se quedaba congelada en el aire
		//la solución que le he dado es que cuando localice al player y llege a su posición active la animación de explosión y luego se destrulla.
		if (targetLocation == transform.position) {
			Instantiate (chifarrazo, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D hitInfo)
	{
	
			Destroce destroce = hitInfo.GetComponent<Destroce> ();
			if (destroce != null) {
				destroce.TakeDamage (damage);
			}
			Instantiate (chifarrazo, transform.position, transform.rotation);
			Destroy (gameObject);

			saludManager player = hitInfo.GetComponent<saludManager> ();
			if (player != null) {
				player.TakeDamage (damage);
			}
			Instantiate (chifarrazo, transform.position, transform.rotation);
			Destroy (gameObject);

		
	}
}



