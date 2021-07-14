using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_canhion : MonoBehaviour {

	public float viewRadius;
	public LayerMask target;
	bool targetlocated;

	SpriteRenderer canhionImage;
	public Sprite leftSprite;
	public Sprite downSprite;
	public Sprite rightSprite;

	Transform playerPos;
	public float viewMargin;

	string whereToShoot;

	public GameObject bullet;
	public Transform leftSpawner;
	public Transform rightSpawner;
	public Transform downSpawner;

	public float bulletLife = 1f;
	public Vector2 leftDir;
	public Vector2 rightDir;
	public Vector2 downDir;
	public float bulletSpeed;

	public float mainTimer;
	float count;
	public float shootingLapse = 1f;
	public float firingRate;
	public int shootCount;

	// Use this for initialization
	void Start () {
		canhionImage = GetComponent<SpriteRenderer> ();
		playerPos = GameObject.FindGameObjectWithTag("player1").transform;



	}

	private void FixedUpdate (){
	
		targetlocated = Physics2D.OverlapCircle(transform.position, viewRadius, target);

		if (targetlocated) {
		
			TargetPlayer ();
			CanhionShooting ();
		
		
		}
	
	
	
	}

	//LO QUE VIENE AHORA ES PARA VERIFICAR QUE EL CANION CAMBIA DE SPRITE, SEGUN EL PLAYER ESTÉ COLOCADO A LA IZQUIERDA O A LA DERECHA.

	void TargetPlayer(){ 
	
		if (playerPos.position.x < transform.position.x - viewMargin) {
		
			canhionImage.sprite = leftSprite;
			whereToShoot = "left";
		
		} else if (playerPos.position.x > transform.position.x + viewMargin) {
		
			canhionImage.sprite = rightSprite;
			whereToShoot = "right";
		
		} else if (playerPos.position.x > transform.position.x - viewMargin && playerPos.position.x < transform.position.x + viewMargin) {
			canhionImage.sprite = downSprite;
			whereToShoot = "down";
		
		}

	}

	void SetTheCanion(string where){
	
		switch (where) {
		case "left":
			GameObject leftBullet = Instantiate (bullet, leftSpawner.position, Quaternion.identity);
			leftBullet.GetComponent<CanhionBullet> ().directionX = leftDir.x + (-bulletSpeed);
			leftBullet.GetComponent<CanhionBullet> ().directionY = leftDir.y + (-bulletSpeed);
			leftBullet.GetComponent<CanhionBullet> ().lifeTime = bulletLife;

			break;
		
		case "right":
			GameObject rightBullet = Instantiate (bullet, rightSpawner.position, Quaternion.identity);

			rightBullet.GetComponent<CanhionBullet> ().directionX = rightDir.x + bulletSpeed;
			rightBullet.GetComponent<CanhionBullet> ().directionY = rightDir.y + (-bulletSpeed);
			rightBullet.GetComponent<CanhionBullet> ().lifeTime = bulletLife;



			break;
		
		case "down":
			GameObject donwBullet = Instantiate (bullet, downSpawner.position, Quaternion.identity);

			donwBullet.GetComponent<CanhionBullet> ().directionX = downDir.x;
			donwBullet.GetComponent<CanhionBullet> ().directionY = downDir.y + (-bulletSpeed);
			donwBullet.GetComponent<CanhionBullet> ().lifeTime = bulletLife;

			break;
		}
	
	}

	void CanhionShooting(){
	
		mainTimer += Time.deltaTime;
		if (mainTimer >= shootingLapse) {
		
			count += Time.deltaTime;

			if (count >= firingRate && shootCount < 3) {
				shootCount++;

				SetTheCanion (whereToShoot);

				count = 0;
			
			}else if (count >= firingRate && shootCount >= 3) {

				mainTimer = 0;
				count = 0;
				shootCount = 0;
			}
		
		} 
	
	}


	void OnDrawGizmos(){
	
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, viewRadius);
	
	}
}
