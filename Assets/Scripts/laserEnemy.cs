using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class laserEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.down * 7 * Time.deltaTime);
		if (transform.position.y < -5.6) {
			Destroy (gameObject);
		}
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Destroy(gameObject);
		}
	}
}
