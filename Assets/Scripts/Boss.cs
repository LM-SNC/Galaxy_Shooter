using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Boss : MonoBehaviour
{
    public GameObject enemyLaserPrefab;
    public bool canShoot;
    public GameObject VZRIV;
    private int lazer;
    public float speed = 1;
    public int Delay;
    public bool collider;
    public int hp = 5;
    public static Boss INSTT;
    public bool canfire;
    public int score;
    public float CanFire;
    public float FireRate = 0.001f;
    // Use this for initialization
    void Start ()
    {
        speed = 1;
        FireRate = 0.1f;
        Delay = 1;
        hp = 40;

        if (!Boss.INSTT)
        {
            Boss.INSTT = this;
        }
        
    }
	
    // Update is called once per frame
    void Update () {
		
       
        if (transform.position.y < 4.5f)
        {
            speed = 0.1f;
        }
        transform.Translate (Vector3.up * speed * Time.deltaTime);
        if (transform.position.y < -7)
        {
            Destroy(gameObject);
        }

        if (hp < 1)
        {
            Destroy (gameObject);
            Instantiate (VZRIV, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
		

    }
    void OnTriggerEnter2D (Collider2D other){
        if (other.gameObject.CompareTag ("laser")) {
           
            hp--;
        }
        if (other.gameObject.CompareTag ("Player")) {
           
            hp--;
            
        }
        if (other.gameObject.CompareTag ("ForBoss") && !collider)
            {
                
                canfire = true;
                collider = true;
                StartCoroutine(strike());

            }
    }

    void OnTriggerExit2D (Collider2D other){
        
        if (other.gameObject.CompareTag ("ForBoss"))
        {
            canfire = false;
            collider = false;

        }

    
    }

    public IEnumerator strike () {
        while (canfire)
        {
            yield return new WaitForSeconds(Delay);
            Delay = 6;
            Instantiate(enemyLaserPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                Quaternion.identity);
            
        }
       
    }
}
