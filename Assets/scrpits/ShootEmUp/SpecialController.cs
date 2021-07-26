using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialController : MonoBehaviour {

	[SerializeField] private GameObject laser;
	[SerializeField] private GameObject shield;


	public void UnlockSpecial(PickupType pickupType){
		Debug.LogFormat ("Especial desbloqueado tipo {0}", pickupType);
		switch (pickupType) {
<<<<<<< Updated upstream
		case PickupType.Laser:
			laser.SetActive (true);
=======
		case PickupType.BigLaser:
			bigLaser.SetActive (true);
			fireBall.SetActive (false);
			break;
		case PickupType.FireBall:
			fireBall.SetActive (true);
			bigLaser.SetActive (false);
>>>>>>> Stashed changes
			break;
		case PickupType.Shield:
			shield.SetActive (true);
			break;
		default:
			break;
		}
	}
<<<<<<< Updated upstream
=======
		
>>>>>>> Stashed changes
}
