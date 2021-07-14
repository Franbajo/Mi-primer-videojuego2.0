using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossManager : MonoBehaviour {

	public float targetRadius = 2f;
	public LayerMask target;
	bool targetLocated;

	public float minAttackDelay;
	public float maxAttackDelay;
	float attackDelay;

	public Transform[] eyes;
	public GameObject eyeflash;
	bool starAttack = false;
	public GameObject bullet;
	public Transform bulletSpawner;
	Transform playerPos;

	[HideInInspector]
	public Coroutine attack;

	Animator bossAnim;

	Boss_Health health;

	void Start () {

		attackDelay = Random.Range (minAttackDelay, maxAttackDelay);
		bossAnim = GetComponent<Animator> ();
		health = GetComponent<Boss_Health> ();


		playerPos = GameObject.FindGameObjectWithTag ("paraBoss").transform;

		
	}
	
	// Update is called once per frame
	void Update () {
		targetLocated = Physics2D.OverlapCircle (transform.position, targetRadius, target);

		if (targetLocated && !starAttack) {

			attack = StartCoroutine (Attacking());
			starAttack = true;
		}


	}


	IEnumerator Attacking(){
		yield return new WaitForSeconds (attackDelay);

		foreach (Transform eye in eyes) {
			Instantiate (eyeflash, eye.position, Quaternion.identity);
			bossAnim.SetTrigger("attacking");
		}
	

		yield return new WaitForSeconds (1.5f);

		//Enemy Attacking
	

		GameObject newBullet = Instantiate (bullet, bulletSpawner.position, Quaternion.identity);
		newBullet.GetComponent<bossBullet> ().targetLocation = playerPos.position;

			StartCoroutine (ResetForAttack ());
	
	}

	IEnumerator ResetForAttack(){
	
		yield return new WaitForSeconds (1.5f);

		attackDelay = Random.Range (minAttackDelay, maxAttackDelay);

		if(!health.bossDestroyed) 
			attack = StartCoroutine (Attacking ());
	}
	public void StopAttack(){
		StopCoroutine (attack);
	}

}
