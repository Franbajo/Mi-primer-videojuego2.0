using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShieldHealthController : MonoBehaviour {

	public int health;
	[SerializeField] private UnityEvent onOneHealthActions;


	public void OnDamage(int danhioRecibido){
		health -= danhioRecibido;
		Debug.LogFormat ("OnDamage, current health is: {0}", health);
		if(health<=1){
			OnZeroHealth ();
		}
	}

	public void OnZeroHealth(){

		if (onOneHealthActions != null) {
			onOneHealthActions.Invoke ();
		}
	}

	public void Update(){
	}
}
