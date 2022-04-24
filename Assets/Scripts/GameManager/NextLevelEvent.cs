using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelEvent : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "portal")
        {
            Debug.Log(collision.collider.name);
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("2333333");
    }
}
