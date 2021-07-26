using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour {
	
	public int health;
	//public int saveHealth;
	[SerializeField] private UnityEvent onZeroHelathActions;


	public void OnDamage(int danhioRecibido){
			
			health -= danhioRecibido;
			Debug.LogFormat ("OnDamage, current health is: {0}", health);
		
		if(health<=0){
			OnZeroHealth ();
			//health = saveHealth;
		}
	}

	public void OnZeroHealth(){

		if (onZeroHelathActions != null) {
			onZeroHelathActions.Invoke ();

		}
	}


	public void resetHelath(int reset){
		health = reset;
	}
	public void Update(){

	}
}
