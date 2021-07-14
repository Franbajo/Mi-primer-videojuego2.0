using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiatorexplosion : MonoBehaviour {
	public GameObject prefab;


	public void DoInstantiate(){
		if(prefab!=null){
			Instantiate (prefab, transform.position, transform.rotation);
		}

	}


}
