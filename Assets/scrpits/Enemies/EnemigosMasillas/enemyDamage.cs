using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour {


	Rigidbody2D rb;
	public int damageValue = 1;



	void Start () {
		rb = GetComponent<Rigidbody2D> ();

	}

	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		saludManager Health = hitInfo.GetComponent<saludManager>();
		if (Health != null) 
		{
			Health.TakeDamage(damageValue);
		}


	}

}
