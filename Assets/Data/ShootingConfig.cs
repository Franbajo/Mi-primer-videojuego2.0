using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New ShootingConfig", menuName= "Enemies/ Shooting config", order=0)]
public class ShootingConfig : ScriptableObject {

	public float shootInitialWaitTime;
	//public float Tiempopausa;//Esta variable es diferente a la Cadencia en cuanto que lo que hace es frenar el tiempo de disparo
						//Esta variable se complemente en EnemyController en el método ShootForever
	//public int numeroAtaque;//Esto complementa a la variable pausa, lo que hace es que desde Unity podamos decirle cuantos ataques 
							//queremos y luego desde el EnemyController en el ShootForever 
							//le decimos que antes de hacer la pausa ejecute tantos ataques.
	public float shootCadence;
	public int damage;
	//public bool autoShooting=false;

}
