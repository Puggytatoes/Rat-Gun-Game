using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    public int startingPoint;

    public Transform[] points;

    private int i;
    public Rigidbody2D rb;
    public SpriteRenderer sr;

    void Start()
    {
        transform.position = points[startingPoint].position;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    /*
    private void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log(coll + "Contact made");
        Vector3 temp;
        temp = transform.localScale;
        temp.x = -1f;
        transform.localScale = temp;
    }
    */

    /*
    [SerializeField]
    public static float speed;
    [SerializeField]
    private Vector3[] locations;
    [SerializeField]
    private int index;

    [SerializeField]
    private float firstEnd;
    [SerializeField]
    private float secondEnd;

    public SpriteRenderer sr;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, locations[index], Time.deltaTime * speed);

        if (transform.position == locations[index])
        {
            if (index == locations.Length - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }

        Vector3 temp;

        temp = transform.localScale;

        if (rb.position.x < firstEnd)
        {
            temp.x = -1f;

        }
        if (rb.position.x > secondEnd)
        {
            temp.x = 1f;
        }

        transform.localScale = temp;
    }*/
}