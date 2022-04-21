using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaMove : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public Vector3[] locations;
    public int index;
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
    }

}