using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour {

	public int Score;
	public int coinCount;
	public int lifeCount;
	public int continueCount =1;
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI cointext;

	public TextMeshProUGUI livesText;
	public GameObject GameOverAnim;
	public GameObject BlackGameOver;

	int highScore;
	public TextMeshProUGUI highScoreText;


	private void Start(){
		cointext.text = "x" + coinCount;

		scoreText.text = "Score: " + Score;

		Score = PlayerPrefs.GetInt ("highscore"); ////PlayerPrefs es una función de Unity que sirve para guardar datos... En esta parte lo que hacemos es CARGAR la puntuacion más alta al iniciar la partida.

		livesText.text = "x: " + lifeCount;

		GameOverAnim.gameObject.SetActive(false);
		BlackGameOver.gameObject.SetActive (false);




	}


	public void UpdateCoint(int coin){
		
		coinCount += coin;
		cointext.text = "x " + coinCount;

	
	}


	public void UpdateScore(int newScore){
		
			Score += newScore;
			scoreText.text = "Score: " + Score;
	

	}

	public void UpdateLives (int life){

		lifeCount += life;
		livesText.text = "x " + lifeCount;
		UpdateHighScore ();

	}

	void UpdateHighScore(){

		if (Score > highScore) {
			highScore = Score;
			highScoreText.text = "High: : " + highScore;

			PlayerPrefs.SetInt ("highscore", highScore); //PlayerPrefs es una función de Unity que sirve para guardar datos... En esta parte lo que hacemos es GUARDAR la puntuacion más alta.
			Score = 0;

		}
	}




	public void UpdateContinue (int continues){

		continueCount += continues;
		if (continueCount == 0) {
			livesText.text = "x " + 0;
			GameOverAnim.gameObject.SetActive(true);

			Instantiate (GameOverAnim, transform.position, Quaternion.identity);
			BlackGameOver.gameObject.SetActive (true);
			Instantiate (BlackGameOver, transform.position, Quaternion.identity);

		}


	}

}

