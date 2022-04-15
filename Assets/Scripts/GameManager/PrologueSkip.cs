using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologueSkip : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) //when P key is pressed, execute Resume and Pause functions depending on the boolan variable called "m_isPaused"
        {
            GameManager.skipping();
        }
    }
}
