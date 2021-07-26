using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnemyTriggerEnterDo : OnCollisionDo {


	[SerializeField] private UnityEvent unignoreActions;//ESTA ES LA CHICHA QUE PERMITE AÑADIR EVENTOS
	[SerializeField] List <string> tagsToIgnore;
	public GameObject collisionee;

	protected override void OnTriggerEnter2D (Collider2D collision){
		alwaysActions.Invoke ();
		foreach (var ignoreTag in tagsToIgnore) {
			if (collision.tag == ignoreTag) {
				return;
			}
		}
		unignoreActions.Invoke ();
	}

	public override void DestroyCollisionee(){
		if (collisionee != null) {
			Destroy (collisionee);
		}
	}

}
