using UnityEngine;

public static class InputProvider {

	/*..........VARIABLES PARA EL DISPARO............*/
	public delegate void HasShoot(); 
	public static event HasShoot OnHasShoot;
	/*.............................................*/
	/*..........VARIABLES PARA LOS CONTROLES............*/
	public delegate void Direction(Vector3 direction);
	public static event Direction OnDirection;
	/*.............................................*/

	/*..........MÉTODO PARA EL DISPARO............*/
	public static void TriggerOnHasShoot(){
		if (OnHasShoot != null) {
			OnHasShoot.Invoke ();
		}
	}
	/*..............................................*/
	/*..........MÉTODOS PARA LOS CONTROLES............*/
	public static void TriggerDirection(Vector3 direction){
		if (OnDirection != null) {
			OnDirection.Invoke (direction);
		}
	}
	/*............................................*/


}
