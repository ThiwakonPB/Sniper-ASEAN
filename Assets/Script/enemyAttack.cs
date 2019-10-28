using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour {

	public GameObject targ;
	public float spd = 1.0f;
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, targ.transform.position, spd); 
		transform.LookAt (targ.transform);
	}
}
