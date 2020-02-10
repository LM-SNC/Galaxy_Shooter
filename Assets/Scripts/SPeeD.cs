using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SPeeD : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.up * 10 * Time.deltaTime);
		if (transform.position.y > 4.5) {
			Destroy (gameObject);
		}
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("BOSS"))
		{
			Destroy(gameObject);
		}
	}
}
