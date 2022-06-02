using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPosChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = gameObject.transform.position;
        if (PlayerController.facingRight)
        {
            pos.x = PlayerController.currentX + 0.851f;
            pos.y = PlayerController.currentY + 0.055f;
        }
        else
        {
            pos.x = PlayerController.currentX - 0.851f;
            pos.y = PlayerController.currentY - 0.055f;
        }
        gameObject.transform.position = pos;

    }
}
