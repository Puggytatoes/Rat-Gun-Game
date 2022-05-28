using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoootPos : PlayerController
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Crouch"))
        {
            Vector2 pos = transform.position;
            pos.y = -3.8f;
            transform.position = pos;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            Vector2 pos = transform.position;
            pos.y = -3f;
            transform.position = pos;
        }
    }
}
