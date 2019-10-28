using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_fire : MonoBehaviour {

	public float range = 100.0f;
		
	public float cooldown = 1.0f;
	float cooldownRemaining = 0;
	public GameObject debrisPrefab;
	public float ammo = 5f;
	public GameObject StartFlash;
	public GameObject MuzzleFlash;
	public float damage = 100f;
	// Use this for initialization
	void Start () {




	}
	
	// Update is called once per frame
	void Update () {
		cooldownRemaining -= Time.deltaTime;
		if (Input.GetMouseButtonDown(0) && cooldownRemaining <= 0 && ammo > 0) {
			
			Vector3 StartFlash = GameObject.Find ("FlashStart").transform.position; 
			Instantiate (MuzzleFlash, StartFlash, Quaternion.identity);
			ammo = ammo - 1;

			cooldownRemaining = cooldown;
			Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
			RaycastHit hitInfo;

			if (Physics.Raycast(ray , out hitInfo, range)) {
				Vector3 hitPoint= hitInfo.point;
				GameObject go = hitInfo.collider.gameObject;
				Debug.Log ("Hit Object: " + go.name);
				Debug.Log ("Hit Point: " + hitPoint);

				Health_enemy h = go.GetComponent<Health_enemy> ();
				Good n = go.GetComponent<Good> ();
				if (h != null) {
					h.ReceiveDamage (damage);
				}

				if (n != null) {
					n.ReceiveDamage (damage);
				}
				if (debrisPrefab != null) {
					Instantiate (debrisPrefab, hitPoint, Quaternion.identity);
				}
			}
		}



	}
}
