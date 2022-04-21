using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepdisappear : MonoBehaviour
{
    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            StartCoroutine(Disappear());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}