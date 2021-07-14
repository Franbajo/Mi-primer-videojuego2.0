using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPrefabsDestroy : MonoBehaviour {

	public float lifetime= 4f;


	// Use this for initialization
	void Start () {

		Destroy (gameObject, lifetime);

		
	}
	

}
