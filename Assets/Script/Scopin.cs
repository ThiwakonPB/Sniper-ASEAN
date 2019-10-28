using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scopin : MonoBehaviour {

	public Animator animator;
	public GameObject ScopedOverlay;
	public GameObject weaponCamera;
	public Camera mainCamera;

	public float scopedFOV = 15.0f;
	private float normalFOV;
	private bool isScoped = false;

	void Update () {
		if (Input.GetButtonDown ("Fire2")) {
			isScoped = !isScoped;
			animator.SetBool ("Scoped", isScoped);
		
			if (isScoped)
				StartCoroutine (OnScoped ());
			else
				OnUnscoped ();
				
		}
	}
		void OnUnscoped () {

		ScopedOverlay.SetActive (false);
		weaponCamera.SetActive (true);
		mainCamera.fieldOfView = normalFOV;
		}

		IEnumerator OnScoped () {

		yield return new WaitForSeconds (.15f);

		ScopedOverlay.SetActive (true);
		weaponCamera.SetActive (false);
		normalFOV = mainCamera.fieldOfView;
		mainCamera.fieldOfView = scopedFOV;
		}

	






}

