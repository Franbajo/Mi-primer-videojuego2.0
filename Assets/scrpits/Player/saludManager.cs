using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class saludManager : MonoBehaviour {

	public int Health = 0;

	public int lives = 3;

	public int credits = 3;

	Vector3 originalPosition; //verifica donde estaba nuestro jugador al momento de ser atacado.


	public float shakeDuration = 0.5f; //Determina por cuanto tiempo va a estar nuestro jugador vibrando y sin poder moverse.
	Animator playerAnim; //tenemos que acceder al Hurt

	Animator transitionScreen;
	public GameObject vidasCoin;
	StatsManager stats;

	public GameObject SpawnPoint;

	public GameObject flechaIndicacion;


	public float delayForReset= 2f;


	private bool flashActive = false;
	int contador=0;


	private SpriteRenderer playerSprite;

	/*public float iniciotime=0f;
	float maxtime=3f;*/
	//public GameObject objectCollider;

	//private SpriteRenderer spr;


	void Start () {

			playerAnim = this.GetComponent<Animator>();
			stats = GameObject.FindGameObjectWithTag ("GameController").GetComponent<StatsManager>();//PARA LAS VIDAS QUE SALEN EN EL UI DEL PERSONAJE
			stats.UpdateLives (lives);
			playerSprite = GetComponent<SpriteRenderer> ();


	//spr = GetComponent<SpriteRenderer> ();



	}


	public void UpdateLives (int life){
		lives+=life;
		flechaIndicacion.gameObject.SetActive (false);
	
	}



	public void TakeDamage (int damage){

			Health -= damage; 
			originalPosition = transform.position;

	
		
		playerAnim.Play ("hurt");
		



		if (Health < 0) {
			lives--;
			Health = 0;
			playerAnim.Play ("die");
			flashActive = true;
			stats.UpdateLives (-1);
			GetComponent<CircleCollider2D> ().enabled = false;

			StartCoroutine (EnableCircleCollider2D ());
		}
		if (lives < 0){
			stats.UpdateLives(4);
			credits--;

			Die ();
		}
		if (credits < 0) {
			stats.UpdateContinue (-1);
			//stats.GameOver (GameOver);
			GameOver ();
		}
	}

	public void Die ()
	{
		
		transform.position = SpawnPoint.transform.position;
		Health = 0;
		lives = 3;


		}

	public void GameOver (){

		Destroy (gameObject);
	}



	IEnumerator EnableCircleCollider2D ()
	    {

		if (flashActive) {
			StartCoroutine (flashplayerr());
			} 
		flechaIndicacion.gameObject.SetActive (true);	
		yield return new WaitForSeconds(3f);
		GetComponent<CircleCollider2D> ().enabled = true;
		playerSprite.color = new Color (playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
		flechaIndicacion.gameObject.SetActive (false);
	
		//Color color = new Color (255/255f,255/255f,255/255f,255/255f);
			
		}


	IEnumerator flashplayerr (){

			playerSprite.color = new Color (playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0.4f);
			yield return new WaitForSeconds (0.5f); //Esta última linea esta pensada para continuarla con otra linea abajo que diga que el color sea 0, pero claro, no se hacer un bucle
			//playerSprite.color = new Color (playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
	}

}



