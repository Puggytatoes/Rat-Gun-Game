using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : PlayerController
{
    public float shootSpeed, shootTimer;

    private bool isShooting;

    public Transform shootPos;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isShooting)
        {
            StartCoroutine(Shoot());
        }

        if (Input.GetButton("Crouch"))
        {
            Vector2 pos = shootPos.position;
            pos.y = -3.8f;
            shootPos.position = pos;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            Vector2 pos = shootPos.position;
            pos.y = -3f;
            shootPos.position = pos;
        }
    }

    IEnumerator Shoot()
    {
        int direction()
        {
            if(transform.localScale.x < 0f)
            {
                return -1;
            }
            else
            {
                return +1;
            }
        }

        isShooting = true;

        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * direction() * Time.fixedDeltaTime, 0f);
        newBullet.transform.localScale = new Vector2(newBullet.transform.localScale.x * direction(), newBullet.transform.localScale.y);

        yield return new WaitForSeconds(shootTimer);
        isShooting = false;

    }
}
