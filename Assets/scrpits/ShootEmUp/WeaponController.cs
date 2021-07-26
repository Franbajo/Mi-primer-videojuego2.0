using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
	
	[SerializeField] private WeaponLevel level1;
	[SerializeField] private WeaponLevel level2;

	public void UnlockWeapon(WeaponType weaponType){
		Debug.LogFormat ("Especial desbloqueado tipo {0}", weaponType);
		switch (weaponType) {
		case WeaponType.Level1:
			level1.gameObject.SetActive(true);
			DiseableLevel2 (false);
			break;
		case WeaponType.Level2:
			level2.gameObject.SetActive (true);
			DiseableLevel1 (false);
			break;
		default:
			break;
		}
	}

	public void DiseableLevel1(bool enable){
		level1.gameObject.SetActive(enable);
	}
	public void DiseableLevel2(bool enable){
		level2.gameObject.SetActive(enable);
	}

}
