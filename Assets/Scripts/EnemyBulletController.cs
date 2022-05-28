using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float speed;

    public PlayerController player;

    public GameObject enemyDeathEffect;

    public GameObject impactEffect;

    public float rotationSpeed;

    // public int damageToGive;

    private Rigidbody2D myrigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        myrigidbody2D = GetComponent<Rigidbody2D>();

        if (player.transform.position.x < transform.position.x)
        {
            speed = -speed;
            rotationSpeed = -rotationSpeed;
        }
        Destroy(gameObject, 1.5f);

    }

    // Update is called once per frame
    void Update()
    {
        myrigidbody2D.velocity = new Vector2(speed, myrigidbody2D.velocity.y);

        myrigidbody2D.angularVelocity = rotationSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "TestRat")
        {
            other.gameObject.GetComponent<RatHealth>().Hurt();
            Destroy(gameObject);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
    }
}
