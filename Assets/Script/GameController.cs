using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GUIText healthText;
	public GUIText scoreText;
	public GameObject GMover;
	private int score;
	private int health;
	// Use this for initialization
	void Start () {
		health = 10;
		score = 0;
			UpdateScore();
		UpdateHealth ();
	}
	


	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{
		scoreText.text = "Score:" + score;
	}


public void AddHealth (int newHealthValue)
{
	health -= newHealthValue;
	UpdateHealth ();
}

void UpdateHealth()
{
	healthText.text = "Health:" + health;
		if (health <= 0) {

			GaMover ();

		}
}

	void GaMover () {

	
		GMover.SetActive (true);

	}
}
