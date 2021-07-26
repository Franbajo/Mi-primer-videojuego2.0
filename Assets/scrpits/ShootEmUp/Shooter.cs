using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
	[SerializeField]private Transform shootOrigin;
	[SerializeField]private GameObject shootPrefab;
	[SerializeField]private ShootingConfig config;

	public ShootingConfig ShootingConfig {
		get{ 
			return config;
		}

	}
	public bool IsEnabled=true;

	private void Start(){
		if (config == null) {
			return;
		}
	}


	/*.....MÉTODO PARA INSTANCIAR EL DISPARO.......*/
	public void DoShoot(){
		if(IsEnabled){
			Instantiate (shootPrefab, shootOrigin.position, shootOrigin.rotation); //Instantiate es un método de Unity Object.Instantiate(Object original, Transform, bool)
		}
	}
	/*............................................*/
	/*.......MÉTODO QUE SIRVE PARA CUANDO SE LE HACE DAÑO AL BOSS.....*/
	public void EnableShooter(bool shouldEnable){
		IsEnabled = shouldEnable;
	}
	/*.................................................................*/


}
