using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType{
	None,
	BigLaser,
	FireBall,
	Shield
}
public enum WeaponType{
	None,
	Level1,
	Level2
}

[CreateAssetMenu(fileName="New PickupConfig", menuName="Player/Pickups", order=1)]
public class PickupConfig : ScriptableObject {
	public PickupType type;
	public int score;
	public WeaponType level;
	//public float durationInSeconds;
}
