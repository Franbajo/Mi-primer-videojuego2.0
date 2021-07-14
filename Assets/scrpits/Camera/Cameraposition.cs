using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraposition : MonoBehaviour {

	public GameObject follow;
	public Vector2 minCamPos, maxCampos;
	//Las dos siguientes lineas de código sirve para crear en la cámara algunos segundos de retraso o suavizado.
	public float smoothTime;
	private Vector2 velocity;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		float posX = Mathf.SmoothDamp(transform.position.x, follow.transform.position.x, ref velocity.x, smoothTime);
		float posY = Mathf.SmoothDamp(transform.position.y, follow.transform.position.y, ref velocity.y, smoothTime);

		transform.position = new Vector3 (
		
			Mathf.Clamp (posX, minCamPos.x, maxCampos.x),
			Mathf.Clamp (posY, minCamPos.y, maxCampos.y),
			transform.position.z);
		
	}
}
