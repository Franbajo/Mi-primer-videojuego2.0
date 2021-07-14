using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Temblor : MonoBehaviour {

	Vector3 camPos;

	public float minX, maxX;
	public float minY, maxY;
	public float minZ, maxZ;

	public float shakeDuration = 0.5f;

	bool canShake = false;

	void Start () {
		camPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (canShake) {
			CameraShake ();
		}
		
	}

	void CameraShake()
	{
		float rdmx = Random.Range (minX, maxX);
		float rdmY = Random.Range (minY, maxY);
		float rdmZ = Random.Range (minZ, maxZ);//Valores random para el movimiento de la camara


		transform.position += new Vector3 (rdmx, rdmY, rdmZ);
	}

	public void ActiveShake(){
	
		//GetComponent<Cameraposition> ().enabled = false;
		camPos = transform.position;

		canShake = true;

		StartCoroutine (Shaking ());

	}

	IEnumerator Shaking (){
	
		yield return new WaitForSeconds (shakeDuration);

		canShake = false;

		//transform.position = camPos;
		//GetComponent<Cameraposition> ().enabled = true;
	}
}
