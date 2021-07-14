using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialController : MonoBehaviour {

	[SerializeField] private GameObject laser;
	[SerializeField] private GameObject shield;


	public void UnlockSpecial(PickupType pickupType){
		Debug.LogFormat ("Especial desbloqueado tipo {0}", pickupType);
		switch (pickupType) {
		case PickupType.Laser:
			laser.SetActive (true);
			break;
		case PickupType.Shield:
			shield.SetActive (true);
			break;
		default:
			break;
		}
	}
}
