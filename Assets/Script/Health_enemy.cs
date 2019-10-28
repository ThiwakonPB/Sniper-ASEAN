using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_enemy : MonoBehaviour {

	public GameObject boom;
	public float hitPoints = 100f;
	public int scoreValue;
	private GameController gameController;

	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("cannot");
		}

	}

	public void ReceiveDamage (float amt ) {
		gameController.AddScore (scoreValue);
		hitPoints -= amt;
		if (hitPoints <= 0) {
			
			Die();
		}
	}

	void Die() {
		Instantiate (boom, transform.position, transform.rotation);

		Destroy (gameObject);
	
	}
}