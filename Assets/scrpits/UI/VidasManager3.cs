using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasManager3 : MonoBehaviour {


	public int coinCount = 1;


	StatsManager stats;
	saludManager salud;

	public GameObject vidasCoin;

	void Start () {

		stats = GameObject.FindGameObjectWithTag ("GameController").GetComponent<StatsManager>();
		salud = GameObject.FindGameObjectWithTag ("player1").GetComponent<saludManager>();


	}


	private void OnTriggerEnter2D(Collider2D col) {

		if(col.CompareTag("protaicons")){
			stats.UpdateLives(coinCount);
			salud.UpdateLives (coinCount);
			Instantiate (vidasCoin, transform.position, Quaternion.identity);

			Destroy (gameObject);
		}


	}
}
