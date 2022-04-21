using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3[] locations;
    [SerializeField]
    private int index;

    [SerializeField]
    private float firstEnd;
    [SerializeField]
    private float secondEnd;

    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }
}