using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformmove : MonoBehaviour
{
    public float speed;

    public Vector3[] locations;

    public int index;

    

    public bool isFacingRight = true;

    


    // Update is called once per frame
    void FixedUpdate()
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
