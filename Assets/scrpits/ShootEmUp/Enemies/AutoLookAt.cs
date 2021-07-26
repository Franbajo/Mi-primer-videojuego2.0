using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AutoLookAt : MonoBehaviour {
	private Transform target;

	public void Start(){

			target = GameController.Instance.Player.transform;
		
	}


	public void Update(){
		//try {
		if(target!=null){
		var targetPosition = target.position;
		
		Vector3 direction = targetPosition - transform.position;
		direction.Normalize ();

		float rot_z = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0f,0f, rot_z-90);
		}
		//}catch (MissingReferenceException){
			//Debug.Log ("Soy un TryCatch!!!");
		//}

		//try{}catch(NullReferenceException e){}
	}
}
