using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {


	public int coinValue = 100;
	public int coinCount = 1;


	StatsManager stats;

	public GameObject pickedCoin;

	void Start () {

		stats = GameObject.FindGameObjectWithTag ("GameController").GetComponent<StatsManager>();

		
	}
	

	private void OnTriggerEnter2D(Collider2D col) {

		if(col.CompareTag("protaicons")){
			stats.UpdateScore(coinValue);
			stats.UpdateCoint(coinCount);


			Instantiate (pickedCoin, transform.position, Quaternion.identity);

			Destroy (gameObject);
		}

		
	}
}
