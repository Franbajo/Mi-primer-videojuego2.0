using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLookAtEnemy : MonoBehaviour {

	private Transform target;
	private bool couroutineStarted=false;
	[SerializeField] private float time;
	[SerializeField] private float fuerzaDeimpulso;

	public void Start(){
		if (GameController.Instance.Player) {
			target = GameController.Instance.Player.transform;
		} else {
			target = null;
		}

		if (!couroutineStarted) StartCoroutine (tiempoPersecucion (time));
	}
	public void Update(){
		if (target != null) {
			var targetPosition = target.position;
		if (target != null && couroutineStarted && this.transform.position.y>targetPosition.y) {
			

			Vector3 direction = targetPosition - transform.position;

			direction.Normalize ();


		//	float rot_z = Mathf.Atan2 (direction.y, direction.x)* Mathf.Rad2Deg;
			//transform.rotation = Quaternion.Euler (0f, 0f, rot_z - 90);
			transform.position = transform.position+ direction * Time.deltaTime*fuerzaDeimpulso;
		} 
		}
	}

	IEnumerator tiempoPersecucion(float seconds){
		couroutineStarted = true;
		yield return new WaitForSeconds (seconds);
		couroutineStarted = false;
	}
		

}