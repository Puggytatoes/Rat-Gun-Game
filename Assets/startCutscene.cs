using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startCutscene : MonoBehaviour
{
    public static bool isCutsceneOn;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isCutsceneOn = true;
            PlayerController.speed = 0;
            
            Debug.Log("a");
            
        }
    }

    void StopCutscene()
    {
        isCutsceneOn = false;
    }
}
