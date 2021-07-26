using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollisionDo : MonoBehaviour {
	public bool IsEnabled = true;
	[SerializeField] protected UnityEvent alwaysActions;

	protected GameObject collisionee;

	protected virtual void OnTriggerEnter2D (Collider2D collision){
	if(!IsEnabled){
			return;
		}

		collisionee = collision.gameObject;
		alwaysActions.Invoke ();
	}
	public virtual void DestroyCollisionee(){
		if (collisionee != null) {
			Destroy (collisionee);
		}
	}
}
