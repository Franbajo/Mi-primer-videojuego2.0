using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	public float speed = 20f;
	public int damage = 40;
	public Rigidbody2D rb;
	public GameObject chifarrazo;

	// Use this for initialization

	void Start () {
		rb.velocity = transform.right * speed;
		Destroy (gameObject, 5f);

	}
	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		
		Enemy enemy = hitInfo.GetComponent<Enemy>();
		if (enemy != null) 
		{
			enemy.TakeDamage(damage);
		}
		Instantiate (chifarrazo, transform.position, transform.rotation);
		Destroy (gameObject);
	
		EnemyManager enemyManager = hitInfo.GetComponent<EnemyManager>();
		if (enemyManager != null) 
		{
			enemyManager.TakeDamage(damage);
		}
		Instantiate (chifarrazo, transform.position, transform.rotation);
		Destroy (gameObject); 

		Destroce destroce  = hitInfo.GetComponent<Destroce>();
		if (destroce != null) 
		{
			destroce.TakeDamage(damage);
		}
		Instantiate (chifarrazo, transform.position, transform.rotation);
		Destroy (gameObject);


		EnemySpawner spawner   = hitInfo.GetComponent<EnemySpawner>();
		if (spawner != null) 
		{
			spawner.TakeDamage(damage);
		}
		Instantiate (chifarrazo, transform.position, transform.rotation);
		Destroy (gameObject);

		SaludCanhion SaludCanhion = hitInfo.GetComponent<SaludCanhion>();
		if (SaludCanhion != null) 
		{
			SaludCanhion.TakeDamage(damage);
		}
		Instantiate (chifarrazo, transform.position, transform.rotation);
		Destroy (gameObject); 


		Explosivo Explosivo = hitInfo.GetComponent<Explosivo>();
		if (Explosivo != null) 
		{
			Explosivo.TakeDamage(damage);
		}
		Instantiate (chifarrazo, transform.position, transform.rotation);
		Destroy (gameObject); 

		Boss_Health Boss = hitInfo.GetComponent<Boss_Health> ();
		if (Boss != null) 
		{
			Boss.TakeDamage(damage);
		}
		Instantiate (chifarrazo, transform.position, transform.rotation);
		Destroy (gameObject); 



	}
}
