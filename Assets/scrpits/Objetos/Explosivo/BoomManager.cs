using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomManager : MonoBehaviour {

	public int damage = 400;
	public Rigidbody2D rb;


	void OnTriggerEnter2D (Collider2D hitInfo)
	{

		Enemy enemy = hitInfo.GetComponent<Enemy> ();
		if (enemy != null) {
			enemy.TakeDamage (damage);
		}
		Destroy (gameObject);

		EnemyManager enemyManager = hitInfo.GetComponent<EnemyManager>();
		if (enemyManager != null) 
		{
			enemyManager.TakeDamage(damage);
		}
		Destroy (gameObject); 

		Destroce destroce  = hitInfo.GetComponent<Destroce>();
		if (destroce != null) 
		{
			destroce.TakeDamage(damage);
		}
		Destroy (gameObject);

		EnemySpawner spawner   = hitInfo.GetComponent<EnemySpawner>();
		if (spawner != null) 
		{
			spawner.TakeDamage(damage);
		}
		Destroy (gameObject);

		SaludCanhion SaludCanhion = hitInfo.GetComponent<SaludCanhion>();
		if (SaludCanhion != null) 
		{
			SaludCanhion.TakeDamage(damage);
		}
		Destroy (gameObject); 

		Explosivo Explosivo = hitInfo.GetComponent<Explosivo>();
		if (Explosivo != null) 
		{
			Explosivo.TakeDamage(damage);
		}
		Destroy (gameObject); 
	}

}
