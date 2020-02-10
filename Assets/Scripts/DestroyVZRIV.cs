using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyVZRIV : MonoBehaviour
{
    public IEnumerator VZRIV () {
        yield return new WaitForSeconds (5f);
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(VZRIV());
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
