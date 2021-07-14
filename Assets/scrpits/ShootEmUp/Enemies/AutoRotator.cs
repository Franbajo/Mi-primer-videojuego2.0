using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotator : MonoBehaviour {
	public Vector3 rotationAxis;
	public float rotationSpeed;

	void Update () {
		this.transform.Rotate(rotationAxis*(rotationSpeed*Time.deltaTime));
		//this.transform.rotation=Quaternion.Euler(rotationAxis*(rotationSpeed*Time.deltaTime));
		//this.transform.rotation=Quaternion.FromToRotation(rotationAxis*(rotationSpeed*Time.deltaTime));
	}
}
