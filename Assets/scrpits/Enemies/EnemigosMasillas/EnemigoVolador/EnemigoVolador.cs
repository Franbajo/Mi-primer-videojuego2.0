using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoVolador : MonoBehaviour {


	public float maxSpeed = 1f;
	public float speed = 1f;
	public LayerMask target;
	public bool targetLocated = false;
	public float vision = 1.5f;
	public Transform bulletSpawner;
	public GameObject bullet;
	public float firingRate = 0.3f; //velocidad de disparo del enemigo
	float mainTimer; //Varoble privada que va a estar contando el tiempo mientras el enemigo realiza el ataque.
	public float shootingLapse = 1f; //Tiempo de descanso que va a tener el enemigo entre los ataques.
	bool shotsFired = false; //indica si el enemigo disparo el set de balas o no
	float count; //conteo parecido al tiempo del disparo del enemigo.
	public int shotCount = 0;

	public GameObject chifarrazo;

	private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {

		rb2d = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		rb2d.AddForce (Vector2.right * speed);
		float limitedSpeed = Mathf.Clamp (rb2d.velocity.x, -maxSpeed, maxSpeed);
		rb2d.velocity = new Vector2 (limitedSpeed, rb2d.velocity.y);

		//Aquí viene el rotar del enemigo
		if (rb2d.velocity.x > -0.01f && rb2d.velocity.x< 0.01f){
			speed = -speed;
			rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);
		}

		if (speed > 0) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);

		} else if (speed < 0) {
			transform.localScale = new Vector3 (1f, 1f, 1f);

		}


		targetLocated = Physics2D.OverlapCircle (transform.position, vision, target);/*El transform.position está puesto ahí para indicarle donde va a crear el area circular del disparo del enemigo.
		                                                                       Por otro lado vision, es lo que ve nuestro enemigo, ver la variable float de arriba...PARANOYA
		                                                                       En cuanto al target, hace referencia a layer Mask que pusimos al inicio*/

		if (targetLocated) {

			Attack ();
		} else {
			
			shotCount = 0;
			mainTimer = 0;
			count = 0;
		}

	}


	void Attack()
	{

		mainTimer += Time.deltaTime;
		if (mainTimer >= shootingLapse) {

			count += Time.deltaTime;
			if (count >= firingRate && shotCount < 3) {

				GameObject newBullet = Instantiate (bullet, bulletSpawner.position, Quaternion.identity);
				newBullet.GetComponent<EnemyBulletManager2> ();
				shotCount++;
				// enemySound.PlayOneShot (shootingSE);
				count = 0;
			} else if (count >= firingRate && shotCount >= 3) {
				mainTimer = 0;
				shotCount = 0;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D hitInfo)
	{
	if (hitInfo.CompareTag("player1")){
			Instantiate (chifarrazo, transform.position, transform.rotation);	
		}
	}





}



		


