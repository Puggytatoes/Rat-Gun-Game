using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    Rigidbody2D pf;

    // Start is called before the first frame update
    void Start()
    {
        pf = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals ("TestRat"))
        {
            PlatformManager.Instance.StartCoroutine("SpawnPlatform",
                new Vector2(transform.position.x, transform.position.y));
            Invoke("DropPlatform", 0.5f);
            Destroy(gameObject, 1f);
        }
    }

    void DropPlatform()
    {
        pf.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
