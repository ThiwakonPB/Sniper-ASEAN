﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Self_destroy : MonoBehaviour {

	public float duration = 1f;
	
	// Update is called once per frame
	void Update () {
		duration -= Time.deltaTime;
		if(duration <= 0 ) {
			Destroy (gameObject);
	}
	}
}