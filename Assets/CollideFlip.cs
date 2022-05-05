using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideFlip : MonoBehaviour
{
    public BoxCollider2D bc;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Enemy"))
        {
            Vector3 temp;
            temp = coll.transform.localScale;
            if (gameObject.tag == "LeftPoint")
                temp.x = -1f;
            else if (gameObject.tag == "RightPoint")
                temp.x = 1f;
            coll.transform.localScale = temp;
        }
            
    }
}
