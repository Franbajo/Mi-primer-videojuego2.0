using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;

public class InstantiaorEnemyTexture : MonoBehaviour {

	public GameObject prefab;

	public void DoInstantiate(){
		if(prefab!=null){
			Instantiate (prefab, transform.position, transform.rotation);
		}
	}

}
