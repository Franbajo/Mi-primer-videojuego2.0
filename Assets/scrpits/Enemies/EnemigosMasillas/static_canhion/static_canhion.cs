using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class static_canhion : MonoBehaviour {

	public float viewRadius; //Radio de la circunferencia para detectar al jugador
	public LayerMask target; //target que estamos buscando para identificar al jugador
	bool targetlocated = false;

	float maintimer;
	float count;
	public float shootingLapse;
	public float firingERate;
	int shotCount;

	/* PARA AÑADIR SONIDOS------
	AudioSource myAudio;
	public AudioClip;*/

	public GameObject bulletPrefab;
	public Transform bulletSpawner;

	public float bulletSpeed;
	public float bulletLifeTime;




	void Start () {

		// myAudio = GetComponent<AudioSource> ();////PARA EL SONIDO

	}

	void FixedUpdate(){

		targetlocated = Physics2D.OverlapCircle(transform.position, viewRadius, target);

		if (targetlocated ) {

			Attack ();

		}



	}
		
	
	// Update is called once per frame
	void Update () {
		
	}


	void Attack(){
	
		maintimer += Time.deltaTime;
		if(maintimer >= shootingLapse){
			count += Time.deltaTime;
			if (count >= firingERate && shotCount < 3) {
				
				GameObject newBullet = Instantiate (bulletPrefab, bulletSpawner.position, Quaternion.identity);
				newBullet.GetComponent<CanhionBullet> ().directionX = -bulletSpeed; //Esta es la direccion en el eje X de la balla... Esta en negativo para que vaya hacia la izquierda.
				newBullet.GetComponent<CanhionBullet> ().directionY = -bulletSpeed;//Esta es la direccion en el eje X de la balla... Esta en negativo para que vaya hacia abajo.
				newBullet.GetComponent<CanhionBullet> ().lifeTime = bulletLifeTime;

				shotCount++;
				//myAudio.PlayOneShot (shotSFX);  PARA SONIDO

				count = 0;

			} else if (count >= firingERate && shotCount >= 3) {
				maintimer = 0;
				count = 0;
				shotCount = 0;
			}
		}
	
	}

	void OnDrawGizmos(){
	
		Gizmos.color = Color.red;

		Gizmos.DrawWireSphere (transform.position, viewRadius);
	
	}

}
