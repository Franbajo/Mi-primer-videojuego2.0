using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;

public class DestroyEnemyTexture : MonoBehaviour {
	public string introTag;
	public void Update(){

			if ( GameObject.FindGameObjectWithTag (introTag)== null) {
				Destroy (this.gameObject);
			}

	}
}
