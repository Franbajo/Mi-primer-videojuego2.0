using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour {
	public EnemyConfig config;

	private Mover mover;
	private Shooter[] shooters;
	[SerializeField]private float zRotation;
	[SerializeField]private MultipleInstantiator multipleInstantiator;

	private void Start(){
		mover = GetComponent<Mover> ();
		if (mover != null) {
			mover.speed = config.moverSpeed;
		}
		//target = FindObjectOfType<PlayerController> ().transform;
		shooters =	GetComponentsInChildren<Shooter> ();
		if(shooters !=null && shooters.Length>0){
			foreach (var shooter in shooters) {
				StartCoroutine (ShootForever (shooter));
			}
		}
	}

	public void OnDie(){

		if(config!=null && multipleInstantiator!=null && config.ShouldThrowPickup()){
			multipleInstantiator.InstantiateInSequence ();
		}

		Debug.Log ("Hey! estoy muerto!");
		GameController.Instance.OnDie (this.gameObject, config.score);

	}

	private IEnumerator ShootForever(Shooter shooter){
		yield return new WaitForSeconds (shooter.ShootingConfig.shootInitialWaitTime);
		while (true && shooter!=null) {

			shooter.DoShoot ();
			yield return new WaitForSeconds (shooter.ShootingConfig.shootCadence);
		
			}
	}


	private void Update(){
		Quaternion rotacion = Quaternion.identity;
		if(config.zRotation != 0&& config!=null){
			rotacion.z = config.zRotation;
			transform.rotation = rotacion;
		}

	}


}
