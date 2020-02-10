using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class koronavirus : MonoBehaviour {
	public float speed = 1;
	public float speedmoove = 4f;
	public GameObject lazer;
	public float CanFire;
    public float FireRate = 0.25f;
	public GameObject TripleShootPrefab;
	public bool canTripleShoot = true;
	public int health = 3;
	public GameObject Trusters;
	public bool shield;
	public static GameObject inst;
	public GameObject sheet;
	public GameObject[] HP;
	public IEnumerator TripleShootPowerDown ()
	{
		yield return new WaitForSeconds (10.0f);
		canTripleShoot = false;
		}
	public IEnumerator ShieldPowerDown ()
	{
		yield return new WaitForSeconds (10.0f);
		shield = false;
		sheet.SetActive(false);

	}
	public IEnumerator EnergyPowerDown ()
	{
		yield return new WaitForSeconds (10.0f);
		speed = 3f;
		speedmoove = 3f;
		Trusters.SetActive(false);
	}


	// Use this  for initialization
	void Start () {
		Trusters.SetActive(false);
		sheet.SetActive(false);
		speed = 3;
		speedmoove = 3f;
		
		if (!koronavirus.inst)
		{
			koronavirus.inst = gameObject;
		}
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("TripleShoot")) {
			canTripleShoot = true;
			Destroy (other.gameObject);
			StartCoroutine (TripleShootPowerDown ());
		}
		if (other.gameObject.CompareTag ("Energy")) {
		
				speed = 4;
				speedmoove = 4;
			

			Destroy (other.gameObject);
			Trusters.SetActive(true);
			StartCoroutine (EnergyPowerDown ());
		}
		if (other.gameObject.CompareTag ("Shield")) {
			shield = true;
			sheet.SetActive(true);
			StartCoroutine (ShieldPowerDown ());
			

		}
		if (other.gameObject.CompareTag ("HP") && health < 3)
		{
			health++;
			if (health == 3)
			{
				HP[3].SetActive(true);
				HP[2].SetActive(false);
				HP[1].SetActive(false);
				HP[0].SetActive(false);
			}
			if (health == 2)
			{
				HP[3].SetActive(false);
				HP[2].SetActive(true);
				HP[1].SetActive(false);
				HP[0].SetActive(false);
			}
			if (health == 1)
			{
				HP[3].SetActive(false);
				HP[2].SetActive(false);
				HP[1].SetActive(true);
				HP[0].SetActive(false);
			}
			if (health == 0)
			{
				HP[3].SetActive(false);
				HP[2].SetActive(false);
				HP[1].SetActive(false);
				HP[0].SetActive(true);
			}
		}
		if (other.gameObject.CompareTag ("Enemy") || other.gameObject.CompareTag ("EnemyLazer")) {
			if (!shield)
			{
				health--;
			}
			else
			{
				shield = false;
				sheet.SetActive(false);
			}
			
			if (health == 3)
			{
				HP[3].SetActive(true);
				HP[2].SetActive(false);
				HP[1].SetActive(false);
				HP[0].SetActive(false);
			}
			if (health == 2)
			{
				HP[3].SetActive(false);
				HP[2].SetActive(true);
				HP[1].SetActive(false);
				HP[0].SetActive(false);
			}
			if (health == 1)
			{
				HP[3].SetActive(false);
				HP[2].SetActive(false);
				HP[1].SetActive(true);
				HP[0].SetActive(false);
			}
			if (health == 0)
			{
				HP[3].SetActive(false);
				HP[2].SetActive(false);
				HP[1].SetActive(false);
				HP[0].SetActive(true);
			}
		}
		if (other.gameObject.CompareTag ("BOSS")) {
			if (!shield)
			{
				health -= 3;
			}
			else
			{
				shield = false;
				sheet.SetActive(false);
			}
			
			
		}

	}

	// Update is called once per frame
	void Update () {
		Mover ();

			if(health < 1){
				Destroy(gameObject);
			}
		if (transform.position.y < -4.34f) {
			transform.position = new Vector3 (transform.position.x, -4.34f, transform.position.z);
		}
		else if (transform.position.x < -8.5f) {
			transform.position = new Vector3 (8.5f, transform.position.y, transform.position.z);
		}
		else if (transform.position.x > 8.5f) {
			transform.position = new Vector3 (-8.5f, transform.position.y, transform.position.z);
		}
		if (Input.GetMouseButton(0)) 
		{
			if (Time.time > CanFire) 
			{
				if (canTripleShoot) 
				{
					Instantiate (TripleShootPrefab, transform.position, Quaternion.identity);
				}
				Instantiate (lazer, transform.position + new Vector3 (0f, 1f, 0f), Quaternion.identity);
			}
			CanFire = Time.time + FireRate;
		}
	}
	void Mover () {
		transform.Translate(new Vector3(speedmoove * Input.GetAxis("Horizontal") * Time.deltaTime,Input.GetAxis("Vertical") * speed * Time.deltaTime),0);

		if (transform.position.y > 0) {
			transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
		}
	}
}
