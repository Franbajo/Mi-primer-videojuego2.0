using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialController : MonoBehaviour {

	[SerializeField] private GameObject bigLaser;
	[SerializeField] private GameObject fireBall;
	[SerializeField] private GameObject shield;


	public void UnlockSpecial(PickupType pickupType){
		Debug.LogFormat ("Especial desbloqueado tipo {0}", pickupType);
		switch (pickupType) {
		case PickupType.BigLaser:
			bigLaser.SetActive (true);
			DisableFireball (false);
			break;
		case PickupType.FireBall:
			fireBall.SetActive (true);
			DisableBigLaser (false);
			break;
		case PickupType.Shield:
			shield.SetActive (true);
			break;
		default:
			break;
		}
	}

	/*.....METODOS PARA DESACTIVAR LAS DEMÁS ARMAS, MIENTRAS UNA ESTÁ ACTIVA....*/
	public void DisableFireball(bool enabled){
		fireBall.SetActive (enabled);
	}
	public void DisableBigLaser(bool enabled){
		bigLaser.SetActive (enabled);
	}
	/*...........................................................................*/
}
