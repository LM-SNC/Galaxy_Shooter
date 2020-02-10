using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLazer : MonoBehaviour
{
    public bool right;
    // Start is called before the first frame update
    void Update () {
        transform.Translate (Vector3.down * 1.5f * Time.deltaTime);
        if (right)
        {
            transform.Translate(Vector3.right * 0.5f * Time.deltaTime);
        }

        if (!right)
        {
            transform.Translate(Vector3.left * 0.5f * Time.deltaTime);
        }

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
