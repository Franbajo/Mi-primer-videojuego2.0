using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanhionBullet : MonoBehaviour {


	Rigidbody2D rb;

	public int damageValue = 1;

	[HideInInspector]
	public float directionX;
	[HideInInspector]
	public float directionY;

	[HideInInspector]
	public float lifeTime;

	public GameObject chifarrazo;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();

		rb.velocity = new Vector2 (directionX, directionY);

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
