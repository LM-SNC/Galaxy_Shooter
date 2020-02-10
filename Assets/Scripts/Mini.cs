using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini : MonoBehaviour {
    public GameObject enemyLaserPrefab;
    public bool canShoot;
    public GameObject VZRIV;
    private int lazer;
    private float speed;
    private float Delay;
    private bool canfire;
    private bool collider;
    public int score;
    public IEnumerator laserEnemyUp () {
		
        yield return new WaitForSeconds (2.0f);
        canShoot = false;
    }
    public IEnumerator laserEnemyDown () {
        yield return new WaitForSeconds (0.1f);
        canShoot = true;
        StartCoroutine (laserEnemyUp ());
    }
    // Use this for initialization
    void Start ()
    {
        speed = 3f;
        Delay = 0.8f;

    }
	
    // Update is called once per frame
    void Update () {
		
        StartCoroutine (laserEnemyDown ());

        transform.Translate (Vector3.up * speed * Time.deltaTime);
        if (transform.position.y < -7)
        {
            Destroy(gameObject);
        }
		

    }
    void OnTriggerEnter2D (Collider2D other){
        if (other.gameObject.CompareTag ("laser")) {
            Destroy (gameObject);
            Instantiate (VZRIV, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
        if (other.gameObject.CompareTag ("Player")) {
            Destroy (gameObject);
            Instantiate (VZRIV, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
        if (other.gameObject.CompareTag ("Finish") && !collider)
        {
            canfire = true;
            collider = true;
            StartCoroutine(strike());
			
        }
    }
    void OnTriggerExit2D (Collider2D other){
        
        if (other.gameObject.CompareTag ("Finish"))
        {
            canfire = false;
            collider = false;

        }

    
    }
    public IEnumerator strike () {
        while (canfire)
        {
            yield return new WaitForSeconds(Delay);
            Instantiate(enemyLaserPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                Quaternion.identity);
            Delay = 1;



        }
       
    }
}