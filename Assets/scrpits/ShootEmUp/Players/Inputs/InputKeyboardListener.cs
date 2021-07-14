using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyboardListener : MonoBehaviour, IInputeable {
	
	/*.............MÉTODOS PARA EL CONTROL...........*/
	public void GetDirection(Vector3 direction){
		InputProvider.TriggerDirection(direction);
	}
	/*..............................................*/
	/*.........ESTE ES EL MÉTODO QUE IMPLEMENTAMOS DE LA INTERFACE IINPUTEABLE.........*/
	public void ShootPressed(){
		InputProvider.TriggerOnHasShoot ();
	}
	/*...................................................................................*/
	/*.................................................................................*/
	private void Update(){
		/*...... ESTO SIRVE PARA CUANDO DISPARAMOS CON EL PLAYER.....*/
		if (Input.GetButtonDown ("ShootNave")) {
			ShootPressed ();
			}
		/*............................................................*/
		/*.............ESTO ES PARA LLAMAR A LOS EVENTOS DEL CONTROL DEL PLAYER..................*/
		GetDirection(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
		/*.......................................................................................*/
	}
}