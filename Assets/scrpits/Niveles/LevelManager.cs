using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	GameObject player;
	public CanvasGroup transPanel;
	public float transTime;
	public GameObject winText;


	public float loadDelay;
	public string levelToLoad;

	bool sequenceComplete =false;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("player1");
	}
	

	void Update () {

		if (sequenceComplete) {
		
			transPanel.alpha += transTime * Time.deltaTime;
			if (transPanel.alpha >= 1) {
				SceneManager.LoadScene (levelToLoad);
			}

		}

	}

	public void StartEndSequence(){
	
		StartCoroutine (EndLevelSequence ());
	
	
	}


	IEnumerator EndLevelSequence(){
	
		player.GetComponent<PlayerController> ().owner.quieto = true ;
		winText.GetComponent<TextMeshProUGUI> ().text = "Congratulations!";
		winText.SetActive(true);

		yield return new WaitForSeconds(loadDelay);
		//player1.GetComponent<Rigidbody2D> ().velocity = Vector2.right * player1.GetComponent<PlayerController> ().owner; 
		sequenceComplete = true;

	}



}


