using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
	
	[SerializeField] private List <Shooter> shooter;
	[SerializeField] private SpecialController specialController;
	[SerializeField] private OnEnemyTriggerEnterDo triggerer;
	[SerializeField] private GameObject Escudo;
	[SerializeField] private List <Shooter> FireBall;
	[SerializeField] private List <Shooter> shooterBigLaser;
	[HideInInspector]public int weaponUp;

	void Start () {
		weaponUp = 0;
		/*....ESTO ES PARA CONVOCAR EL DISPARO....*/
		InputProvider.OnHasShoot += Instance_OnHasShoot;//Se llama directamente a la clase InputProvider y se iguala a nuestro disparo.
		/*.........................................*/
	}


	/*.....MÉTODO PARA INSTANCIAR EL DISPARO.......*/
	private void Instance_OnHasShoot(){
		foreach (var shoot in shooter) {
			if (shoot != null) {
				shoot.DoShoot ();
			}
		}
		foreach (var shoot in shooterBigLaser) {
			if (shoot.IsEnabled)
				shoot.DoShoot ();
		}
		foreach (var fire in FireBall) {
			if (fire.IsEnabled)
				fire.DoShoot ();
		}
	}
	/*..........................................*/
		
	/*.........MÉTODO PARA LOS PICUPS O POWERUPS............*/
	public void UnlockSpecial(PickupConfig pickupConfig){
		Debug.LogFormat ("Especial desbloqueado tipo {0}", pickupConfig.type);
		specialController.UnlockSpecial (pickupConfig.type);

		switch(pickupConfig.type){
		case PickupType.Shield:
			EnableCollider(false);
			break;
		case PickupType.BigLaser:
			limitUp (1);
			DisableNormalShoot (false);
			foreach(var fire in FireBall ){
				fire.IsEnabled = false;
			}
			switch (weaponUp) {
			case (1):
				foreach (var shoot in shooterBigLaser) {
					if (shoot.WeaponLevel == WeaponType.Level1) {
						shoot.IsEnabled = true;
						shoot.gameObject.SetActive (true);
					} else {
						shoot.IsEnabled = false;
						shoot.gameObject.SetActive (false);
					}
				}
				break;
			case (2 ):
				foreach (var shoot in shooterBigLaser) {
					if (shoot.WeaponLevel == WeaponType.Level2) {
						shoot.IsEnabled = true;
						shoot.gameObject.SetActive (true);
					} else {
						shoot.IsEnabled = false;
						shoot.gameObject.SetActive (false);
					}
				}
				break;
			default:
				break;
			}
			//FireBall.IsEnabled=false;
			break;
		case PickupType.FireBall:
			limitUp (1);
			DisableNormalShoot (false);
			foreach(var shoot in shooterBigLaser ){
				shoot.IsEnabled = false;
			}
			switch (weaponUp) {
			case (1):
				foreach (var fire in FireBall) {
					if (fire.WeaponLevel == WeaponType.Level1) {
						fire.IsEnabled = true;
						fire.gameObject.SetActive (true);
					} else {
						fire.IsEnabled = false;
						fire.gameObject.SetActive (false);
					}
				}
				break;
			case (2):
				foreach (var fire in FireBall) {
					if (fire.WeaponLevel == WeaponType.Level2) {
						fire.IsEnabled = true;
						fire.gameObject.SetActive (true);
					} else {
						fire.IsEnabled = false;
						fire.gameObject.SetActive (false);
					}
				}
				break;
			default:
				break;
			}
			break;
		default:
			break;
		}

	}
	/*......................................................*/


	/*.... MÉTODO PARA ACTIVAR Y DESACTIVAR EL COLLIDER DEL PLAYER CUANDO LLEVAMOS EL ESCUDO.......*/
	public void EnableCollider(bool shouldEnable){
		triggerer.IsEnabled = shouldEnable;
	}
	/*.............................................................................................*/
	/*.......MÉTODO PARA QUE EN CASO DE QUE NO TENGAMOS ESCUDO, SE VUELVA A ACTIVAR EL */
	void Update () {
		if (!Escudo.activeSelf) {
			EnableCollider (true);
		}
	}
	/*..........ESTO ES PARA DESACTIVAR EL ARMA NORMAL SI ALGÚN ARMA ESTÁ SELECCIONADA.........*/
	public void DisableNormalShoot(bool enabled){
		foreach(var shoot in shooter){
			shoot.IsEnabled = enabled;
		}
	}
	/*......................................................................*/

	/*...PARA QUE LOS POWER UPS NO REVASEN DEL NIVEL 2....*/
	public void limitUp(int numero){
		weaponUp += numero;
		if (weaponUp >= 2) weaponUp = 2;
	}
	/*.......................................................*/



}
