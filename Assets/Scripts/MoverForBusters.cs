using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverForBusters : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.down * 2 * Time.deltaTime);
		if (transform.position.y < -5.6) {
			Destroy (gameObject);
		}
	}
}
