using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //ESTO ES PARA LA BARRA DE VIDA

public class Boss_Health : MonoBehaviour {

	public int salud = 50;
	int maxHealth; //ESTO ES PARA LA BARRA DE VIDA
	public int bossvalue = 1000;



	StatsManager stats;
	private Rigidbody2D rb2d;

	public GameObject deathEffect;

	public Image healthBar; //ESTO ES PARA LA BARRA DE VIDA

	[HideInInspector]
	public bool bossDestroyed = false;

	//public Transform []explosionLocations;
	public GameObject endExplosion;

	public GameObject bigExplosion;

	public GameObject boss;

	bossManager manager;
	public Animator bodyAnim; //Para detener el cuerpo del boss cuando muere
	public Animator headAnim;

	LevelManager levelManager;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		stats = GameObject.FindGameObjectWithTag ("GameController").GetComponent <StatsManager>();
		maxHealth = salud;
		manager = GetComponent<bossManager> ();
		levelManager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<LevelManager>();

	}


	public void TakeDamage (int damage){

		salud -= damage;

	
		healthBar.fillAmount = ((float)salud / (float)maxHealth);
	

		if (salud <= 0) {
			//stats.UpdateScore(bossvalue);
			bossDestroyed = true;
			manager.StopAttack ();
			bodyAnim.enabled=false;
			headAnim.enabled = false;

			Die ();
		} 
	}

	void Die ()
	{

		Instantiate (deathEffect, transform.position, Quaternion.identity);
	//	stats.UpdateScore (bossvalue);
		Destroy (gameObject, 4f);
		Instantiate (endExplosion, transform.position, Quaternion.identity);
		//Destroy (endExplosion, 4f);
		Instantiate (bigExplosion, transform.position, Quaternion.identity);	
		//levelManager.StartEndSequence ();
		Destroy (boss, 4f);

		//StartCoroutine(BossDefeated());
	}


	/*IEnumerator BossDefeated(){
	
		for (int i = 0; i < explosionLocations.Length; i++) {


			Instantiate (endExplosion, explosionLocations[i].position, Quaternion.identity);
			yield return new WaitForSeconds (0.4f);

		}

	}*/

}
