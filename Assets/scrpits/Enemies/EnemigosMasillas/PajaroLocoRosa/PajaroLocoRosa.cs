using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PajaroLocoRosa : MonoBehaviour {

	public Transform[] navPoints;
	public float speed;
	public float runSpeed;
	public float nearDistance;  //Dice en que momento nuestro enemigo puede ir al proximo punto de navegación.
	int curPos= 0; //Nos dice donde se encuentra nuestro enemigo dentro de los puntos de navegación.

	public float turnDelay = 3f;
	float count;

	Rigidbody2D rb;
	Animator anim;

	RaycastHit2D ray;
	public Transform enemyEyes;
	public float sightDistance;
	bool lookingRight = true;

	bool isPatrolling = true;
	GameObject player;

	public float attackDistance;
	public float patrolCount;

	public float firingRate;
	public float shootingLapse;
	public float mainTimer;
	int shotCount = 0;

	public GameObject bullet;
	public Transform bulletSpawner;


	public GameObject chifarrazo;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag("player1");
	}
	

	void Update () {

		if (isPatrolling) {
			Patrol ();
			FlipMe ();
		}
		EnemySight ();

		anim.SetFloat ("Speed", Mathf.Abs (rb.velocity.x));


	}

	void Patrol(){
	
		Vector3 dir = navPoints [curPos].position - transform.position;
		Vector3 dirNorm = dir.normalized;  //Esto hace que el vector3 retorne a un valor de magnitud 1 y verificar que lejos o cerca está del próximo punto de navegación.

		rb.velocity = new Vector2 (dirNorm.x * speed, rb.velocity.y);
		if (dir.sqrMagnitude <= nearDistance) {
		
			count += Time.deltaTime;

			if (count >= turnDelay) {
			
				curPos++;

				if (curPos >= navPoints.Length) {

					curPos = 0;
				}

				count = 0;
			}
		
		}
	}	
	void FlipMe(){ //HE TENIDO QUE QUITAR EL FLIP ME este PQ si lo ponía no me hacía bien el Flipeo...  
	/*ESTO ES EL FLIPEO DEL PERSONAJE CUANDO ESTÁ PATRULLANDO... */
		
		if (navPoints [curPos].position.x - nearDistance > transform.position.x) {

			transform.localScale = new Vector3 (-1f, 1f, 1f);
			lookingRight = true; //Esto es para voltear los ojos

		} else if (navPoints [curPos].position.x + nearDistance < transform.position.x) {

			transform.localScale = new Vector3 (1f, 1f, 1f);
			lookingRight = false; //Esto es para voltear los ojos
		}
			
	}

	void EnemySight (){

		if (lookingRight) {

			ray = Physics2D.Raycast (enemyEyes.position, Vector2.right, sightDistance);

		} else {

			ray = Physics2D.Raycast (enemyEyes.position, Vector2.left, sightDistance);

		}
		if (ray.collider != null) //Esta linea quiere decir, SI el rayo está chocando con algún objeto que tenga algún collider
		{
			if (ray.collider.CompareTag ("player1")) {
				ChaseAndAttack ();

			}
		} else if (ray.collider == null || ray.collider.tag != "player1"){
			if (!isPatrolling) {
			
				patrolCount += Time.deltaTime;

				if (patrolCount >= turnDelay) {
				
					patrolCount = 0 ;
					isPatrolling = true;

				}
			}
		}
	}


	void ChaseAndAttack(){

		isPatrolling = false;

		Vector3 dir = player.transform.position; //- transform.position;
		Vector3 dirNorm = dir.normalized;

		rb.velocity = new Vector2(dirNorm.x * runSpeed, rb.velocity.y);
		if (dir.sqrMagnitude >= attackDistance) {

			rb.velocity = Vector2.zero;

			Attack ();
		}
	}

	void Attack(){
	
		mainTimer += Time.deltaTime;
		if (mainTimer >= shootingLapse) {

			count += Time.deltaTime;

			if (count >= firingRate && shotCount < 3) {

				anim.SetBool ("Attacking", true);
				GameObject newBullet = Instantiate (bullet, bulletSpawner.position, Quaternion.identity);

				newBullet.GetComponent<EnemyBulletManager> ().lookingRight = lookingRight;

				shotCount++;
				count = 0;
		
			} else if (count >= firingRate && shotCount >= 3) {

				mainTimer = 0;
				shotCount = 0;

				anim.SetBool ("Attacking", false);

			}
		}
			
	
	}


	/*ESTO ES PARA QUE SE VE EN EL EDITOR DE UNITY LA LÍNEA DE PATRULLA DEL ENEMIGO*/
	private void OnDrawGizmos(){

		if(navPoints == null || navPoints.Length <2){
			
			return; }
		{
			for (int i = 1; i < navPoints.Length; i++) {

				Debug.DrawLine (navPoints [i - 1].position, navPoints [i].position);
				
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
