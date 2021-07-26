using System.Collections;
using System.Collections.Generic;
using UnityEngine;


	
public class PlayerControl : MonoBehaviour {
	public float speed;//Para el movimiento del personaje
	public Mover moverComponente;//Para el movimiento del personaje
<<<<<<< Updated upstream
	[SerializeField] private List <Shooter> shooter;
	[SerializeField] private SpecialController specialController;
=======
	public WeaponController weapon;
>>>>>>> Stashed changes

	private void Start(){
		/*....Esto es para mover el personaje....*/
		moverComponente.speed = speed;
		/*.......................................*/
		/*.....ESTO ES PARA CONVOCAR LOS CONTROLES............*/
		InputProvider.OnDirection += Movement;
		/*....................................................*/
	}

	/*........MÉTODO PARA MOVER AL PERSONAJE.............*/
	private void Movement(Vector3 direction){
		moverComponente.direction = direction;
	}
	/*.................................................*/

<<<<<<< Updated upstream
	public void UnlockSpecial(PickupType pickupType){
		Debug.LogFormat ("Especial desbloqueado tipo {0}", pickupType);
		specialController.UnlockSpecial (pickupType);
	}

	public void OnPlayerDie(){
		GameController.Instance.OnPlayerDie ();
	}
		
	void Update () {

	}

=======
	public void OnPlayerDie(){
			GameController.Instance.OnPlayerDie ();
		weapon.limitUp (-weapon.weaponUp);
	}


>>>>>>> Stashed changes
}
