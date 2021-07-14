using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletManager2 : MonoBehaviour {

	public float bulletSpeed = 3f;
	Rigidbody2D rb;
	public int damageValue = 1;
	public bool lookingRight;
	public float lifeTime = 1f;
	public GameObject chifarrazo;


	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = Vector2.right * bulletSpeed;
		//rb.velocity = lookingRight ? Vector2.right * bulletSpeed : Vector2.left * bulletSpeed;
		Destroy (gameObject, lifeTime);
	}

	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		saludManager Health = hitInfo.GetComponent<saludManager>();
		if (Health != null) 
		{
			Health.TakeDamage(damageValue);
		}

		Instantiate (chifarrazo, transform.position, transform.rotation);	
		Destroy (gameObject);


	}




}
