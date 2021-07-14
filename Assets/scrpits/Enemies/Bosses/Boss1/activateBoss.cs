using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateBoss : MonoBehaviour {

	public GameObject Boss;
	public Animator wallAnim;


	public GameObject lifeBar;

	void Start () {
		Boss.SetActive (false);

	}




	void OnTriggerEnter2D(Collider2D col){

		if(col.CompareTag("camaraCentro")){

			wallAnim.SetBool ("readyToExplode", true);
			StartCoroutine (ShowTheBoss());

		}

	}

	IEnumerator ShowTheBoss(){
	
		yield return new WaitForSeconds (wallAnim.GetCurrentAnimatorClipInfo(0)[0].clip.length);


		Boss.SetActive (true);
		lifeBar.SetActive (true);
	
	}



}