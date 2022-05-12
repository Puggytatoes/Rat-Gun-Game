using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    Rigidbody2D pf;
    private AudioSource source;


    // Start is called before the first frame update
    void Start()
    {

        pf = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("ContactCheck"))
        {
            PlatformManager.Instance.StartCoroutine("SpawnPlatform",
                new Vector2(transform.position.x, transform.position.y));
            source.Play();
            Invoke("DropPlatform", 3f);
            Destroy(gameObject, 1f);
        }
    }

    void DropPlatform()
    {
        pf.isKinematic = false;
    }
}
