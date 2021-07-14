using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PrincipalHealthController : MonoBehaviour {

	public int life;
	private bool exit;
	[SerializeField] private List <HealthController> HealthParts;
	[SerializeField] private UnityEvent onZeroHealthActions;

	public void Start(){
		life=HealthParts.Count;
		exit = true;
	}

	public void Update(){
		for (int i = 0; i < HealthParts.Count; i++) {
			if (exit==false) {
				restLife ();
			}
			else if (HealthParts[i].health==0 && HealthParts[i]!=null) {
				exit = false;
				Destroy(HealthParts [i]);
			}
		}

		if (life == 0)
			OnZeroHealth ();
	}

	public void restLife(){
		life--;
		exit = true;
	}
	public void OnZeroHealth(){
		if (onZeroHealthActions != null) {
			onZeroHealthActions.Invoke ();
		}
	}
}
