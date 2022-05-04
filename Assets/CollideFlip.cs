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
        Debug.Log(coll + "Contact made");
        Vector3 temp;
        temp = coll.transform.localScale;
        temp.x *= -1f;
        coll.transform.localScale = temp;
    }
}
