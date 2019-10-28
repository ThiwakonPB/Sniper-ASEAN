using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Good : MonoBehaviour {

	public GameObject boom;
	public float hitPoints = 50f;
	public int scoreValue;
	public int healthValue;

	private float othergod;
	private GameController gameController;

	void Start () {
		othergod = GameObject.Find ("Sphere").GetComponent<God> ().health ;
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("cannot");
		}

	}

	public void ReceiveDamage (float amt ) {
		othergod -= healthValue;
		gameController.AddScore (scoreValue);
		gameController.AddHealth (healthValue);
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