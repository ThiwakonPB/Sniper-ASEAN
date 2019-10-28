using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour {
	public float health = 10.0f;
	public float dmg = 2.0f;
	public GameObject boom;
	public GameObject nice;
	public GameObject dead;
	public GameController gameController;
	public int healthValue;
	public int scoreValue;
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("cannot");
		}

	}

	void Update () {
		if ( health <= 0)
		{
			Instantiate (dead, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter (Collider other)
	{


		if (other.tag == "enemy") {
			gameController.AddHealth (healthValue);
			health = health - dmg;
			Destroy (other.gameObject);
			Instantiate (boom, transform.position, transform.rotation);
		}
			if (other.tag == "enemy" && health <= 0) {
			Instantiate (dead, transform.position, transform.rotation);
				Destroy (gameObject);
			}
		if (other.tag == "good") {
			gameController.AddScore (scoreValue);

			Destroy (other.gameObject);
			Instantiate (nice, transform.position, transform.rotation);
		}
		}
	}

		
