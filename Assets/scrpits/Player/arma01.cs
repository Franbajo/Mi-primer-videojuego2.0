using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arma01 : MonoBehaviour {
	
	//public float shootingRate;
	//float count;

	public Transform firePoint;
	public Transform FireDiag;
	public Transform FireUp;
	public Transform FireDiagDown;
	public GameObject BulletPrefab;
	public GameObject BulletPrefabDIAG;
	public GameObject BulletPrefabUP;
	public GameObject BulletPrefabDIAGDown;
	player1 playerprota; //Nuevo

	void Start (){                             //ESTO ES NUEVOOOOO
	
		playerprota = GetComponent<player1> (); //ESTO ES NUEVOOOOO
	}


	// Update is called once per frame
	void Update () {
		/*if (Input.GetButtonDown ("Fire1")) {
			if (!playerprota.diagLook) {
				Shoot ();
			} else if (playerprota.diagLook) {
				Shoot2 ();
			} 
		}*/ 
	
		if (Input.GetButtonDown ("Fire1")) {
			if (playerprota.firepoint && !playerprota.diagLook && !playerprota.downLook && !playerprota.UpLook) {
				Shoot ();
			}  if (playerprota.diagLook && !playerprota.firepoint && !playerprota.downLook && !playerprota.UpLook) {
				Shoot2 ();
			} if (playerprota.UpLook && !playerprota.firepoint && !playerprota.diagLook && !playerprota.downLook) {
			    Shoot3 ();
			}if (!playerprota.diagLook && !playerprota.firepoint  && !playerprota.UpLook && playerprota.downLook){
				Shoot4 ();
					} 
				
			}
		
	}
		
	void Shoot ()  {
			Instantiate (BulletPrefab, firePoint.position, firePoint.rotation);
		}
	void Shoot2 () {
		Instantiate (BulletPrefabDIAG, FireDiag.position, FireDiag.rotation);
	}
	void Shoot3 () { 
		//if (playerprota.vertical > 0) {                                  //Esta parte evita el bug de que dispare inclinado y hacia arriba al mismo tiempo
			Instantiate (BulletPrefabUP, FireUp.position, FireUp.rotation);
		//} 
	}
	void Shoot4 () {
		Instantiate (BulletPrefabDIAGDown, FireDiagDown.position, FireDiag.rotation);
	}
//A CONTINUACIÓN LO QUE VAMOS A HACER ES DESHABILITAR EL DISPARO CUANDO LLEGUE A LA ESCALERA... MOOOLA
private void OnTriggerStay2D (Collider2D collision) // Este primer void es para cuando el personaje toca la escalera... Con el tag escalera conseguimos que sea true  
{
	if (collision.gameObject.tag == "escalera") {
			BulletPrefab.SetActive (false);
			BulletPrefabDIAG.SetActive (false);
			BulletPrefabUP.SetActive (false);
			BulletPrefabDIAGDown.SetActive (false);
	}
}
//A CONTINUACIÓN LO QUE VAMOS A HACER ES HABILITAR EL DISPARO CUANDO SALGA DE LA ESCALERA... MOOOLA
private void OnTriggerExit2D(Collider2D collision)// Este segundo void es para cuando el personaje deja de tocar la escalera...  
{
	if (collision.gameObject.tag == "escalera") {
			BulletPrefab.SetActive (true);
			BulletPrefabDIAG.SetActive (true);
			BulletPrefabUP.SetActive (true);
			BulletPrefabDIAGDown.SetActive (true);
	} 
}
}
