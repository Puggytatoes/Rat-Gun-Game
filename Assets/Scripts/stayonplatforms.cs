using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stayonplatforms : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "movingplat")
        {
            transform.parent = other.transform;
            Debug.Log("We are on a moving platform");
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "movingplat")
        {
            transform.parent = null;
        }
    }
}