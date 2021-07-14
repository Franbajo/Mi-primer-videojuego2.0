using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int salud = 100;
	public GameObject deathEffect;
	public float maxSpeed = 1f;
	public float speed = 1f;

	public int damageValue = 1;
	private int damageValue2 = 0;
	public GameObject chifarrazo;

	private Rigidbody2D rb2d;

	StatsManager stats;
	public int enemyValue = 200;//Los puntos que te da un enemigo.

	//bool parpadeo = false;


	// Use this for initialization
	void Start () {
		
		rb2d = GetComponent<Rigidbody2D> ();
		stats = GameObject.FindGameObjectWithTag ("GameController").GetComponent<StatsManager>();
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


	}
		

	public void TakeDamage (int damage){

		salud -= damage;
		if (salud <= 0) {
			Die ();
		} 
	}

	void Die ()
	{
		
		Instantiate (deathEffect, transform.position, Quaternion.identity);
		stats.UpdateScore (enemyValue);
		Destroy (gameObject);
	}


	void OnTriggerEnter2D (Collider2D col)
	{
		saludManager Health = col.GetComponent<saludManager>();
		if (Health != null) 
		{
			Health.TakeDamage(damageValue);
			//StartCoroutine ("parpadeoFuncion");
		} if (col.CompareTag("player1")){
		Instantiate (chifarrazo, transform.position, transform.rotation);
		Debug.Log ("PUPAAAAAAAAAAAAAAAAAAA!!!");
		} /*if (col.gameObject.tag == "player1") {

			float yOffset = 0.1f;
			//float xOffset = 8f;

			if (transform.position.y + yOffset < col.transform.position.y) {
				col.SendMessage ("Jump");
				Health.TakeDamage (damageValue2);
				Destroy (gameObject);
			} else {
				col.SendMessage ("EnemyKnockBack", transform.position.x);
			}*/ //CODIGO PARA HACER EL SALTAR SOBRE UN ENEMIGO, NO FUNCIONA BIEN...
		
		
		}
			
	/*IEnumerator parpadeoFuncion(){
		parpadeo = true;
		if (parpadeo = true) {
			damageValue = 0;
		}
		yield return new WaitForSeconds (2f);

		parpadeo = false;

	}*/




	
	}




