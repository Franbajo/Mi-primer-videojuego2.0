using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFather : MonoBehaviour {

	//public EnemyController enemigoPosicion;
	public string introTag;

	//public EnemyConfig config;
	//private Mover mover;


	public GameObject child;
	public Transform parent;

	public float velocidad;
	//public Vector3 direccion;

	void Start(){
	/*	mover = GetComponent<Mover> ();
		velocidad = config.moverSpeed;
		if (mover != null) {
			mover.speed = config.moverSpeed;
		}*/
	}


	void Update () {
		if (GameObject.FindGameObjectWithTag (introTag) != null) {
			/*this.posicion.transform.position = enemigoPosicion.posicionEnemigo();
			target.SetParent (posicion, true);*/
			child.transform.SetParent (parent);
			transform.Translate (child.transform.position * velocidad * Time.deltaTime);
		}
	}

}
