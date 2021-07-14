using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New EnemyConfig", menuName= "Enemies/ Enemy config", order=0)]
public class EnemyConfig : ScriptableObject {
	public float moverSpeed;
	public float zRotation;
	public bool isShooter;
	public int score;
	public ShootingConfig shootingConfig;
	[Range(0, 1)]
	public float pickupChance;

	public bool ShouldThrowPickup(){
		return Dice.IsChanceSuccess (pickupChance);
	}

}
