using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour {
	public GameObject[] bonusPrefab;
	public GameObject EnemyPrefab;
	public GameObject[] HPOBJECT;
	public GameObject BOSS;
	public GameObject Mini;
	public bool DSP;
	Boss boss;
	
	public int hp;
	IEnumerator corstartenemy()
	{
		while (true)
		{
			int[] positionenemy = {0,0};
			positionenemy[0] = Random.Range(-7, 7);
			if (positionenemy[0] != positionenemy[1] && ! DSP)
			{
				Instantiate(EnemyPrefab, new Vector3(positionenemy[0], 9, 0), Quaternion.Euler(0, 0, 180));
			}

			positionenemy[1] = positionenemy[0];
			yield return new WaitForSeconds (Random.Range (2,4));
		}

	}
	IEnumerator bOSS()
	{
		while (true)
		{
			
			yield return new WaitForSeconds (Random.Range (35,70));
			GameObject HUI = Instantiate(BOSS, new Vector3(0, 9, 0), Quaternion.Euler(0, 0, 180));
			boss = HUI.GetComponent<Boss>();
			StartCoroutine (stop());
			StartCoroutine (mini());
			
			




		}
		

	}
	
	IEnumerator mini()
	{
		while (DSP)
		{
			Instantiate(Mini, new Vector3(Random.Range(-7, 7), 20, 0),
				Quaternion.Euler(0, 0, 180));
			Debug.Log("Spawned");
			yield return new WaitForSeconds (Random.Range (2,4));
		}

	}
	IEnumerator bonusspawn()
	{
		while (true)
		{
			
				Debug.Log("Spawned");
			yield return new WaitForSeconds (Random.Range (7,13));
			Instantiate(bonusPrefab[Random.Range(0, bonusPrefab.Length)], new Vector3(Random.Range(-6, 6), 6, 0),
				Quaternion.identity);
		}

	}
	IEnumerator stop()
	{
		while (true)
		{
			DSP = true;
			yield return new WaitForSeconds (30);
			DSP = false;
			
			yield break;
			
		}

	}



	// Use this for initialization
	void Start ()
	{
		StartCoroutine (corstartenemy());
		StartCoroutine (bOSS());
		StartCoroutine (bonusspawn());
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (DSP)
		{
			hp = boss.hp;
		
		 if (hp > 35)
            {
                HPOBJECT[0].SetActive(false);
                HPOBJECT[1].SetActive(false);
                HPOBJECT[2].SetActive(false);
                HPOBJECT[3].SetActive(false);
                HPOBJECT[4].SetActive(false);
                HPOBJECT[5].SetActive(true);
            }
            if (hp > 30 && hp < 35)
            {
                HPOBJECT[0].SetActive(false);
                HPOBJECT[1].SetActive(false);
                HPOBJECT[2].SetActive(false);
                HPOBJECT[3].SetActive(false);
                HPOBJECT[4].SetActive(true);
                HPOBJECT[5].SetActive(false);
            }
            if (hp > 25 && hp < 30)
            {
                HPOBJECT[0].SetActive(false);
                HPOBJECT[1].SetActive(false);
                HPOBJECT[2].SetActive(false);
                HPOBJECT[3].SetActive(true);
                HPOBJECT[4].SetActive(false);
                HPOBJECT[5].SetActive(false);
            }
            if (hp > 20 && hp < 25)
            {
                HPOBJECT[0].SetActive(false);
                HPOBJECT[1].SetActive(false);
                HPOBJECT[2].SetActive(true);
                HPOBJECT[3].SetActive(false);
                HPOBJECT[4].SetActive(false);
                HPOBJECT[5].SetActive(false);
            }
            if (hp > 15 && hp < 20)
            {
                HPOBJECT[0].SetActive(false);
                HPOBJECT[1].SetActive(true);
                HPOBJECT[2].SetActive(false);
                HPOBJECT[3].SetActive(false);
                HPOBJECT[4].SetActive(false);
                HPOBJECT[5].SetActive(false);
            }
            if (hp < 10)
            {
                HPOBJECT[0].SetActive(true);
                HPOBJECT[1].SetActive(false);
                HPOBJECT[2].SetActive(false);
                HPOBJECT[3].SetActive(false);
                HPOBJECT[4].SetActive(false);
                HPOBJECT[5].SetActive(false);
            }
            if (hp < 1)
            {
                HPOBJECT[0].SetActive(false);
                HPOBJECT[1].SetActive(false);
                HPOBJECT[2].SetActive(false);
                HPOBJECT[3].SetActive(false);
                HPOBJECT[4].SetActive(false);
                HPOBJECT[5].SetActive(false);
            }
		}
	}
}
