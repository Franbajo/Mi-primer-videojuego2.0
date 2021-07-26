using System.Collections;
using System.Collections.Generic;
using UnityEngine;


	
public class PlayerControl : MonoBehaviour {
	public float speed;//Para el movimiento del personaje
	public Mover moverComponente;//Para el movimiento del personaje
	[SerializeField] private List <Shooter> shooter;
	[SerializeField] private SpecialController specialController;

	private void Start(){
		/*....Esto es para mover el personaje....*/
		moverComponente.speed = speed;
		/*.......................................*/
		/*....ESTO ES PARA CONVOCAR EL DISPARO....*/
		InputProvider.OnHasShoot += Instance_OnHasShoot;//Se llama directamente a la clase InputProvider y se iguala a nuestro disparo.
		/*.........................................*/
		/*.....ESTO ES PARA CONVOCAR LOS CONTROLES............*/
		InputProvider.OnDirection += Movement;
		/*....................................................*/
	
	}
	/*.....MÉTODO PARA INSTANCIAR EL DISPARO.......*/
	private void Instance_OnHasShoot(){
		foreach(var shoot in shooter){
			if (shoot != null) {
				shoot.DoShoot ();
			}
		}
	}
	/*............................................*/
	/*........MÉTODO PARA MOVER AL PERSONAJE.............*/
	private void Movement(Vector3 direction){
		moverComponente.direction = direction;
	}
	/*.................................................*/

	public void UnlockSpecial(PickupType pickupType){
		Debug.LogFormat ("Especial desbloqueado tipo {0}", pickupType);
		specialController.UnlockSpecial (pickupType);
	}

	public void OnPlayerDie(){
		GameController.Instance.OnPlayerDie ();
	}
		
	void Update () {

	}

}
