using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//Esta clase sirve para establecer los límites del player en pantalla
public class posiciones{
	public float izquierdaX, derechaX, arribaY, abajoY;
}

public class Limits : MonoBehaviour {
	
	public posiciones posi;

	
	// Update is called once per frame
	void Update () {
		/*...........PARA ESTABLECER LOS LÍMITES DEL PERSONAJE EN PANTALLA..........*/
		float ejeX = Mathf.Clamp (transform.position.x, posi.izquierdaX, posi.derechaX);
		float ejeY = Mathf.Clamp (transform.position.y, posi.abajoY, posi.arribaY);
		this.transform.position = new Vector3 (ejeX, ejeY, 0);
		/*............................................................................*/
	}
}
