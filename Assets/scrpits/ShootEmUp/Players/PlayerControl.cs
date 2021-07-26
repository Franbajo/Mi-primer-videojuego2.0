using System.Collections;
using System.Collections.Generic;
using UnityEngine;


	
public class PlayerControl : MonoBehaviour {
	
	public float speed;//Para el movimiento del personaje
	public Mover moverComponente;//Para el movimiento del personaje
	[SerializeField] private List <Shooter> shooter;
	[SerializeField] private SpecialController specialController;
	//[SerializeField] private Collider2D playerCollider;
	[SerializeField] private OnEnemyTriggerEnterDo triggerer;
	[SerializeField] private GameObject Escudo;
	[SerializeField] private GameObject FireBall;
	//[SerializeField] private List <GameObject> Laser;
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

	/*.........MÉTODO PARA LOS PICUPS O POWERUPS............*/
	public void UnlockSpecial(PickupConfig pickupConfig){
		Debug.LogFormat ("Especial desbloqueado tipo {0}", pickupConfig.type);
		specialController.UnlockSpecial (pickupConfig.type);
		if (pickupConfig.type == PickupType.Shield) {
			EnableCollider(false);
		} 
		if (pickupConfig.type == PickupType.BigLaser) {
			EnabledBigLaser (false);
		}

	}
	/*......................................................*/

	/*.... MÉTODO PARA ACTIVAR Y DESACTIVAR EL COLLIDER DEL PLAYER CUANDO LLEVAMOS EL ESCUDO.......*/
	public void EnableCollider(bool shouldEnable){
		triggerer.IsEnabled = shouldEnable;
	}
	/*.............................................................................................*/


	public void OnPlayerDie(){
			GameController.Instance.OnPlayerDie ();

	}

	/*.......MÉTODO PARA QUE EN CASO DE QUE NO TENGAMOS ESCUDO, SE VUELVA A ACTIVAR EL */
	void Update () {
		if (!Escudo.activeSelf) {
			EnableCollider (true);
		}
	}

	/*..........ESTO ES UN CHANWEIS PARA CAMBIAR DE UN ARMA A OTRA..........*/
	public void EnabledBigLaser(bool enabled){
		foreach(var shoot in shooter){
			shoot.IsEnabled = enabled;
		}
		FireBall.SetActive(enabled);
	}
	/*......................................................................*/
}
