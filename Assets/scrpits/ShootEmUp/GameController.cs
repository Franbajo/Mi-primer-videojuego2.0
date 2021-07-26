using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public static GameController Instance;

	private int playerscore;
	[SerializeField] private PlayerControl player;
	//[SerializeField] private PlayerControl player;


	[HideInInspector]
	public PlayerControl Player{
		get { 
			return player;
		}
	}

	private void Awake(){
		Instance = this;
	}

	public void OnDie(GameObject deadObject, int score=0){
		playerscore += score;
		Debug.LogFormat ("GameController: the object {0} has died! Adding score {1}, total {2}", deadObject.name, score, playerscore);
	}

	public void OnPickupPickedUp(PickupController pickup){
<<<<<<< Updated upstream
		player.UnlockSpecial (pickup.config.type);
=======
		player.weapon.UnlockSpecial (pickup.config);
>>>>>>> Stashed changes
	}


	public void OnPlayerDie(){
		Debug.Log ("**********************PLAYER DIED!!!***********************");
	}
}
