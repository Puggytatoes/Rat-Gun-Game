using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDie : MonoBehaviour
{
    public float dieTime;

    public GameObject diePEffect;

    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.name != "TestRat")
        {
            Die();
        }

        if (collision.transform.tag == "Enemy")
        {
            collision.gameObject.GetComponent<CockroachHealth>().TakeDamage(40);
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(dieTime);
        Die();
    }

    void Die()
    {
        if (diePEffect != null)
        {
            Instantiate(diePEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}